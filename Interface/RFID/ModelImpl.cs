using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace InformSystema.Interface.RFID
{
	/// <summary>
	/// Имплементация интерфейса IModel
	/// </summary>
	[DataContract(Name = "model", Namespace = "http://informsystema.com/marc/service/")]
	[Serializable]
	[TypeConverter(typeof(ModelConverter))]
	public class ModelImpl : IModel
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ModelImpl() {}
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		/// <param name="model">Тип модели</param>
		public ModelImpl(TypeModel model)
		{
			Model = model;
		}

		#region implementation interface IModel
		/// <summary>
		/// Тип модели
		/// </summary>
		[DataMember(Order = 3, Name = "model", IsRequired = true)]
		public TypeModel Model { get; internal set; }
		/// <summary>
		/// Идентификатор модели метки
		/// </summary>
		[DataMember(Order = 1, Name = "id", IsRequired = true)]
		public string Id { get; set; }
		/// <summary>
		/// Тип модели метки
		/// </summary>
		[DataMember(Order = 2, Name = "type", IsRequired = true)]
		public TypeItem Type { get; set; }
		/// <summary>
		/// Записать данные на метку
		/// </summary>
		public virtual void Write()
		{
		}
		/// <summary>
		/// Чтение модели данных
		/// </summary>
		/// <param name="id">идентификатор метки</param>
		/// <returns>Модель данных</returns>
		public virtual ModelImpl[] Read(string id)
		{
			return new List<ModelImpl>().ToArray();
		}

		#endregion
	}
}
