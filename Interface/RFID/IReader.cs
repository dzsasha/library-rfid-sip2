using System;
using System.IO;
using System.Runtime.InteropServices;

namespace IS.Interface.RFID
{
	/// <summary>
	/// Интрефейс реадера
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE290B")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IReader
	{
		/// <summary>
		/// Открыть реадер
		/// </summary>
		/// <param name="param">параметры для реадера</param>
		/// <returns>успешность открытия реадера</returns>
		bool InitReader(IField[] param);
		/// <summary>
		/// Закрыть реадер
		/// </summary>
		void CloseReader();
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		IItem[] Items { get; }
		/// <summary>
		/// Событие, если была ошибка
		/// </summary>
		event ErrorEventHandler OnError;
		/// <summary>
		/// Событие чтения новых меток
		/// </summary>
		event EventHandler OnChange;
	}
}
