using System;
using System.Runtime.Serialization;

namespace IS.RFID.Service
{
	/// <summary>
	/// Класс выдачи ошибки клиенту
	/// </summary>
	[DataContract(Name = "error", Namespace = "http://informsystema.com/marc/service/")]
	[Serializable]
	public struct ErrorImpl
	{
		/// <summary>
		/// Строка ошибки
		/// </summary>
		[DataMember(Name = "message", IsRequired = true)]
		public string ErrorMessage { get; set; }
	}
}
