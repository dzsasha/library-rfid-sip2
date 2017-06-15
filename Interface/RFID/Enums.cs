using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace InformSystema.Interface.RFID
{
	/// <summary>
	/// Тип метки
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2901")]
	[ComVisible(true)]
	[DataContract(Namespace = "http://informsystema.com/marc/service/")]
	public enum TypeItem
	{
		/// <summary>
		/// Неизвестная
		/// </summary>
		[EnumMember]
		Unknown = -1,
		/// <summary>
		/// Книга
		/// </summary>
		[EnumMember]
		Item = 1,
		/// <summary>
		/// Читатель
		/// </summary>
		[EnumMember]
		Person = 2,
	}
	/// <summary>
	/// Тип поля для меток
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2902")]
	[ComVisible(true)]
	[DataContract(Namespace = "http://informsystema.com/marc/service/")]
	public enum TypeField
	{
		/// <summary>
		/// Пустое поле
		/// </summary>
		[EnumMember]
		Null,
		/// <summary>
		/// Целочисленное поле
		/// </summary>
		[EnumMember]
		Integer,
		/// <summary>
		/// Строковое поле
		/// </summary>
		[EnumMember]
		String,
		/// <summary>
		/// Логическое
		/// </summary>
		[EnumMember]
		Boolean,
	}
	/// <summary>
	/// Типы моделей данных
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2903")]
	[ComVisible(true)]
	[DataContract(Namespace = "http://informsystema.com/marc/service/")]
	public enum TypeModel
	{
		/// <summary>
		/// Датская модель
		/// </summary>
		[EnumMember]
		Danish = 0
	}
}
