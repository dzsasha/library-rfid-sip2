using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using InformSystema.Interface.RFID;

namespace InformSystema.Interface
{
	/// <summary>
	/// Интерфейс поля метки
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2904")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IField
	{
		/// <summary>
		/// Имя поля
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Описание поля
		/// </summary>
		string Description { get; }
		/// <summary>
		/// Тип поля
		/// </summary>
		TypeField Type { get; }
		/// <summary>
		/// Значение
		/// </summary>
		object Value { get; set; }
		/// <summary>
		/// Событие изменения значения.
		/// </summary>
		event EventHandler OnChange;
	}
}
