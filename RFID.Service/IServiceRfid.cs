using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using IS.Interface.RFID;

namespace IS.RFID.Service
{
	/// <summary>
	/// Интерфейс сервиса для работы с RFID-устройствами
	/// </summary>
	[ServiceContract(Name = "ICoreRFID", Namespace = "http://informsystema.com/marc/service/")]
	public interface IServiceRfid
	{
		[WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
		void Options();
		/// <summary>
		/// Получение списка устройств
		/// </summary>
		/// <returns>список считывателей</returns>
		[OperationContract(Name = "GetReaders")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebGet(UriTemplate = "GetReaders")]
		[return: MessageParameter(Name = "result")]
		string[] GetReaders();
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		/// <returns>прочитанные метки</returns>
		[OperationContract(Name = "GetItems")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebGet(UriTemplate = "GetItems")]
		[return: MessageParameter(Name = "result")]
		string[] GetItems();
		/// <summary>
		/// Получить прочитанные метки с устройства
		/// </summary>
		/// <param name="objectName">имя устройства</param>
		/// <returns>прочитанные метки</returns>
		[OperationContract(Name = "GetItemsFrom")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebGet(UriTemplate = "GetItems?reader={objectName}")]
		[return: MessageParameter(Name = "result")]
		string[] GetItemsFrom(string objectName);
		/// <summary>
		/// Получить состояние противокражного бита
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>противокражный бит</returns>
		[OperationContract(Name = "GetEas")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebInvoke(Method = "POST", UriTemplate = "GetEas")]
		[return: MessageParameter(Name = "result")]
		bool GetEas(string item);
		/// <summary>
		/// Установить противокражный бит
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="eas">противокражный бит</param>
		[OperationContract]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebInvoke(Method = "POST", UriTemplate = "SetEas")]
		void SetEas(string item, bool eas);
		/// <summary>
		/// Получение данных с модели метки
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>данные модели</returns>
		[OperationContract(Name = "GetModels")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebInvoke(Method = "POST", UriTemplate = "GetModels")]
		[return: MessageParameter(Name = "result")]
		ModelImpl[] GetModels(string item);
		/// <summary>
		/// Получение поддерживаемых типов моделей данных на метке
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>массив поддерживаемых типов данных на метке</returns>
		[OperationContract(Name = "GetTypeModels")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebInvoke(Method = "POST", UriTemplate = "GetTypeModels")]
		[return: MessageParameter(Name = "result")]
		TypeModel[] GetTypeModels(string item);
		/// <summary>
		/// Записать модель на метку
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="index">номер модели</param>
		/// <param name="model">модель</param>
		[OperationContract(Name = "WriteModel")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebInvoke(Method = "POST", UriTemplate = "WriteModel")]
		void WriteModel(string item, int index, ModelImpl model);
		/// <summary>
		/// Модель по умолчанию, для типа модели
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="typeModel">тип модели</param>
		/// <returns>модель данных</returns>
		[OperationContract(Name = "Getdefault")]
		[FaultContract(typeof(ErrorImpl), Name = "error")]
		[WebInvoke(Method = "POST", UriTemplate = "GetDefault")]
		[return: MessageParameter(Name = "result")]
		ModelImpl GetDefault(string item, TypeModel typeModel);
	}
}
