using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Marc.Interface
{
	/// <summary>
	/// Имплементация интерфейса ITypeModel
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TypeModelImpl<T> : Collection<IModel>, ITypeModel where T : ModelImpl, new()
	{
		/// <summary>
		/// Констурктор по умолчанию
		/// </summary>
		/// <param name="modelModel">Тип модели</param>
		/// <param name="id">идентификатор метки</param>
		public TypeModelImpl(TypeModel modelModel, string id)
		{
			_id = id;
			Model = modelModel;
			try
			{
				foreach (ModelImpl modelImpl in (new T() { Model = modelModel }).Read(id))
				{
					Add(modelImpl);
				}
			}
			catch (RfidException ex)
			{
			}
		}
		/// <summary>
		/// Идентификатор метки
		/// </summary>
		protected string _id = "";

		#region implementation interface ITypeModel
		/// <summary>
		/// Тип модели данных
		/// </summary>
		public TypeModel Model { get; private set; }
		/// <summary>
		/// Модель по умолчанию
		/// </summary>
		public IModel Default { get { return new T() {Id = _id, Type = TypeItem.Item, Model = Model}; }}
		/// <summary>
		/// Добавить модель
		/// </summary>
		/// <param name="item">модель</param>
		public new virtual void Add(IModel item)
		{
			base.Add(item);
		}
		#endregion
	}
}
