using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace InformSystema.Interface.RFID
{
	/// <summary>
	/// Интерфейс для модели данных
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2908")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IModel
	{
		/// <summary>
		/// Тип модели
		/// </summary>
		TypeModel Model { get; }
		/// <summary>
		/// Идентификатор модели метки
		/// </summary>
		string Id { get; set; }
		/// <summary>
		/// Тип модели метки
		/// </summary>
		TypeItem Type { get; set; }
		/// <summary>
		/// Записать данные на метку
		/// </summary>
		void Write();
	}
	/// <summary>
	/// Универсальный доступ к модели
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2909")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IModelEx : IModel
	{
		/// <summary>
		/// Поля модели данных
		/// </summary>
		IField[] Fields { get; }
	}
	/// <summary>
	/// Интерфейс типа модели
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE290A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ITypeModel : IEnumerable<IModel>
	{
		/// <summary>
		/// Тип модели данных
		/// </summary>
		TypeModel Model { get; }
		/// <summary>
		/// Модель по умолчанию
		/// </summary>
		IModel Default { get; }
		/// <summary>
		/// Добавить модель
		/// </summary>
		/// <param name="model">модель</param>
		void Add(IModel model);
	}
}
