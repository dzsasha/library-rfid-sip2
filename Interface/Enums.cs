using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace IS.Interface
{
	/// <summary>
	/// Типы полей
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
		/// <summary>
		/// Символ
		/// </summary>
		[EnumMember]
		Char,
		/// <summary>
		/// Дата и время
		/// </summary>
		[EnumMember]
		DateTime,
	}
}
