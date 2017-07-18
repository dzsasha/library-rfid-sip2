using System.Runtime.InteropServices;

namespace IS.Interface.RFID
{
	/// <summary>
	/// Интерфейс метки
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2905")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IItem
	{
		/// <summary>
		/// Идентификатор метки
		/// </summary>
		string Id { get; }
	}
	/// <summary>
	/// Расширенный интерфейс для метки
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2906")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IItemEx : IItem
	{
		/// <summary>
		/// Противокражный бит
		/// </summary>
		bool Eas { get; set; }
	}
	/// <summary>
	/// Интерфейс данных для записи на метку
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2907")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IItemModel : IItem
	{
		/// <summary>
		/// Список существующих моделей на метке
		/// </summary>
		ITypeModel[] Models { get; }
	}
}
