using System;
using System.Globalization;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ServiceModel.Web;
using IS.Interface;
using IS.Interface.RFID;
using System.ServiceModel;

namespace IS.RFID.Service
{
	public partial class ServiceImpl : IServiceRfid
	{
		#region implementation IServiceRfid
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		/// <returns>прочитанные метки</returns>
		string[] IServiceRfid.GetItems()
		{
			try
			{
				List<string> lRet = new List<string>();
				foreach (ReaderImpl reader in _readers)
				{
					lRet.AddRange((this as IServiceRfid).GetItemsFrom(reader.Name));
				}
				return lRet.ToArray();
			}
			catch (Exception ex)
			{
				Log.For(this).Error("ServiceImpl:GetItems() - {0}", ex);
				throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
			}
		}
		/// <summary>
		/// Получение списка устройств
		/// </summary>
		/// <returns>список считывателей</returns>
		string[] IServiceRfid.GetReaders()
		{
			try
			{
				(this as IServiceRfid).Options();
				return _readers.Select(reader => reader.Name).ToArray();
			}
			catch (Exception ex)
			{
				Log.For(this).Error("ServiceImpl:GetReaders() - {0}", ex);
				throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
			}
		}
		
		/// <summary>
		/// Получить прочитанные метки с устройства
		/// </summary>
		/// <param name="objectName">имя устройства</param>
		/// <returns>прочитанные метки</returns>
		string[] IServiceRfid.GetItemsFrom(string objectName)
		{
			(this as IServiceRfid).Options();
			List<string> lRet = new List<string>();
			try
			{
				lRet.AddRange(Readers[objectName].Items.Select(item => item.Id));
			}
			catch (Exception ex)
			{
				Log.For(this).Error(String.Format("ServiceImpl:GetItemsFrom - {0}", ex.Message));
				throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
			}

			return lRet.ToArray();
		}
		/// <summary>
		/// Получить состояние противокражного бита
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>противиокражный бит</returns>
		bool IServiceRfid.GetEas(string item)
		{
			(this as IServiceRfid).Options();
			if (item != null)
			{
				try
				{
					IItem _item = GetItem(item);
					if (_item != null && _item.IsItemEx()) return (_item as IItemEx).Eas;
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:GetEas - {0}", ex.Message));
					throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
				}
			}
			return false;
		}
		/// <summary>
		/// Установить противокражный бит
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="eas">противокражный бит</param>
		void IServiceRfid.SetEas(string item, bool eas)
		{
			(this as IServiceRfid).Options();
			if (item != null)
			{
				try
				{
					IItem _item = GetItem(item);
					if (_item != null && _item.IsItemEx()) (_item as IItemEx).Eas = eas;
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:SetEas - {0}", ex.Message));
					throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
				}
			}
		}
		/// <summary>
		/// Получение данных с модели метки
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>данные модели</returns>
		ModelImpl[] IServiceRfid.GetModels(string item)
		{
			(this as IServiceRfid).Options();
			List<ModelImpl> lRet = new List<ModelImpl>();
			if (item != null)
			{
				try
				{
					IItem _item = GetItem(item);
					if (_item != null && _item.IsItemModel())
					{
						lRet.AddRange(from typeModel in (_item as IItemModel).Models from model in typeModel select new ModelImpl(model.Model) {Id = model.Id, Type = model.Type});
					}
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:GetModels - {0}", ex.Message));
					throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
				}
			}
			return lRet.ToArray();
		}

		/// <summary>
		/// Модель по умолчанию, для типа модели
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="typeModel">тип модели</param>
		/// <returns>модель данных</returns>
		ModelImpl IServiceRfid.GetDefault(string item, TypeModel typeModel)
		{
			(this as IServiceRfid).Options();
			ModelImpl pRet = null;
			if (typeModel != null)
			{
				try
				{
					IItem _item = GetItem(item);
					if (_item != null && _item.IsItemModel())
					{
						foreach (ITypeModel model in (_item as IItemModel).Models.Where(model => model.Model == typeModel))
						{
							pRet = new ModelImpl(typeModel) { Id = model.Default.Id, Type = model.Default .Type};
						}
					}
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:GetDefault - {0}", ex.Message));
					throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
				}
			}
			return pRet;
		}

		/// <summary>
		/// Получение поддерживаемых типов моделей данных на метке
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>массив поддерживаемых типов данных н аметке</returns>
		public TypeModel[] GetTypeModels(string item)
		{
			(this as IServiceRfid).Options();
			List<TypeModel> lRet = new List<TypeModel>();
			if (item != null)
			{
				try
				{
					IItem _item = GetItem(item);
					if (_item != null && _item.IsItemModel())
					{
						lRet.AddRange((_item as IItemModel).Models.Select(model => model.Model));
					}
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:GetTypeModels - {0}", ex.Message));
					throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
				}
			}
			return lRet.ToArray();
		}

		/// <summary>
		/// Записать модель на метку
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="index">номер модели</param>
		/// <param name="model">модель</param>
		void IServiceRfid.WriteModel(string item, int index, ModelImpl model)
		{
			(this as IServiceRfid).Options();
			if (item != null && model != null)
			{
				IItem _item = GetItem(item);
				if (_item != null && _item.IsItemModel())
				{
					try {
						foreach (ITypeModel typeModel in (_item as IItemModel).Models)
						{
							if (typeModel.Model == model.Model)
							{
								IModel addModel = typeModel.Default;
								if (!typeModel.Any())
								{
									addModel.Id = model.Id;
									addModel.Type = model.Type;
									typeModel.Add(addModel);
								}
								else
								{
									addModel = typeModel.ElementAt(index);
									addModel.Id = model.Id;
									addModel.Type = model.Type;
									addModel.Write();
								}
							}
						}
					}
					catch (Exception ex)
					{
						Log.For(this).Error(String.Format("ServiceImpl:WriteModel - {0}", ex.Message));
						throw new FaultException<ErrorImpl>(new ErrorImpl() { ErrorMessage = ex.Message }, new FaultReason(ex.Message));
					}
				}
			}
		}

		void IServiceRfid.Options()
		{
			if (WebOperationContext.Current != null)
			{
				WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
				WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin, Origin, X-Requested-With, Content-Type, Accept");
				WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "OPTIONS, POST, GET");
				WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Credentials", "false");
			}
		}

		#endregion
	}
}
