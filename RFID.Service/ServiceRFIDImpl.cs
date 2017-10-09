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
using System.Net;

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
			(this as IServiceRfid).Options();
			try
			{
				_items.Clear();
				foreach (ReaderImpl reader in _readers)
				{
					_items.AddRange(Readers[reader.Name].Items);
				}
			}
			catch (Exception ex)
			{
				Log.For(this).Error("ServiceImpl:GetItems() - {0}", ex);
				throw new WebFaultException<String>(String.Format("{0} - {1}", "GetItems", ex.Message), HttpStatusCode.InternalServerError);
			}
			return _items.Select(item => item.Id).ToArray();
		}
        /// <summary>
        /// Метка пришла из этого сервиса?
        /// </summary>
        /// <param name="item">метка</param>
        /// <returns>успешность</returns>
        bool IServiceRfid.IsItem(string item)
        {
            (this as IServiceRfid).Options();
            if (item != null)
            {
                try
                {
                    IItem _item = GetItem(item);
                    return _item != null;
                }
                catch (Exception ex)
                {
                    Log.For(this).Error(String.Format("ServiceImpl:IsItem - {0}", ex.Message));
                    throw new WebFaultException<String>(String.Format("{0} - {1}", "IsItem", ex.Message), HttpStatusCode.InternalServerError);
                }
            }
            return false;
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
					throw new WebFaultException<String>(String.Format("{0} - {1}", "GetEas", ex.Message), HttpStatusCode.InternalServerError);
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
					throw new WebFaultException<String>(String.Format("{0} - {1}", "SetEas", ex.Message), HttpStatusCode.InternalServerError);
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
			long lTimer = Environment.TickCount;
			(this as IServiceRfid).Options();
			List<ModelImpl> lRet = new List<ModelImpl>();
			if (item != null)
			{
				try
				{
					IItem _item = GetItem(item);
					if (_item != null && _item.IsItemModel())
					{
						lRet.AddRange(from typeModel in (_item as IItemModel).Models from model in typeModel select new ModelImpl(model.Model) { Id = model.Id, Type = model.Type });
					}
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:GetModels - {0}", ex.Message));
					throw new WebFaultException<String>(String.Format("{0} - {1}", "GetModels", ex.Message), HttpStatusCode.InternalServerError);
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
			try
			{
				IItem _item = GetItem(item);
				if (_item != null && _item.IsItemModel())
				{
					foreach (ITypeModel model in (_item as IItemModel).Models.Where(model => model.Model == typeModel))
					{
						pRet = new ModelImpl(typeModel) { Id = model.Default.Id, Type = model.Default.Type };
					}
				}
			}
			catch (Exception ex)
			{
				Log.For(this).Error(String.Format("ServiceImpl:GetDefault - {0}", ex.Message));
				throw new WebFaultException<String>(String.Format("{0} - {1}", "GetDefault", ex.Message), HttpStatusCode.InternalServerError);
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
					Log.For(this).Debug(String.Format("ServiceImpl:GetTypeModels - {0}", lRet.Count));
				}
				catch (Exception ex)
				{
					Log.For(this).Error(String.Format("ServiceImpl:GetTypeModels - {0}", ex.Message));
					throw new WebFaultException<String>(String.Format("{0} - {1}", "GetTypeModels", ex.Message), HttpStatusCode.InternalServerError);
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
					try
					{
						foreach (ITypeModel typeModel in (_item as IItemModel).Models)
						{
							if (typeModel.Model == model.Model)
							{
								IModel addModel = typeModel.Default;
                                addModel.Id = model.Id;
                                addModel.Type = model.Type;
                                if (!typeModel.Any())
								{
									typeModel.Add(addModel);
								}
                                addModel.Write();
                                Log.For(this).Debug(String.Format("ServiceImpl:WriteModel - {0}", addModel.Id));
							}
						}
					}
					catch (Exception ex)
					{
						Log.For(this).Error(String.Format("ServiceImpl:WriteModel - {0}", ex.Message));
						throw new WebFaultException<String>(String.Format("{0} - {1}", "WriteModel", ex.Message), HttpStatusCode.InternalServerError);
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
