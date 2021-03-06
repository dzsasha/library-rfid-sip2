﻿using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using IS.Interface.RFID;

namespace IS.RFID.Service {
	/// <summary>
	/// Интерфейс сервиса для работы с RFID-устройствами
	/// </summary>
	[ServiceContract(Name = "IServiceRFID", Namespace = "http://informsystema.com/marc/service/")]
	public interface IServiceRFID {
		[WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
		void Options();
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		/// <returns>прочитанные метки</returns>
		[OperationContract(Name = "Read", Action = "Read")]
		[WebInvoke(Method = "*", UriTemplate = "Read")]
		[return: MessageParameter(Name = "result")]
		string[] Read();
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		/// <returns>прочитанные метки</returns>
		[OperationContract(Name = "GetItems", Action = "GetItems")]
		[WebInvoke(Method = "*", UriTemplate = "GetItems")]
		[return: MessageParameter(Name = "result")]
		string[] GetItems();
		/// <summary>
		/// Метка пришла из этого сервиса?
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>успешность</returns>
		[OperationContract(Name = "IsItem", Action = "IsItem")]
		[WebInvoke(Method = "POST", UriTemplate = "IsItem")]
		[return: MessageParameter(Name = "result")]
		bool IsItem(string item);
		/// <summary>
		/// Получить состояние противокражного бита
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>противокражный бит</returns>
		[OperationContract(Name = "GetEas", Action = "GetEas")]
		[WebInvoke(Method = "POST", UriTemplate = "GetEas")]
		[return: MessageParameter(Name = "result")]
		bool GetEas(string item);
		/// <summary>
		/// Установить противокражный бит
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="eas">противокражный бит</param>
		[OperationContract(Name = "SetEas", Action = "SetEas")]
		[WebInvoke(Method = "POST", UriTemplate = "SetEas")]
		void SetEas(string item, bool eas);
		/// <summary>
		/// Получение данных с модели метки
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>данные модели</returns>
		[OperationContract(Name = "GetModels", Action = "GetModels")]
		[WebInvoke(Method = "POST", UriTemplate = "GetModels")]
		[return: MessageParameter(Name = "result")]
		ModelImpl[] GetModels(string item);
		/// <summary>
		/// Получение поддерживаемых типов моделей данных на метке
		/// </summary>
		/// <param name="item">метка</param>
		/// <returns>массив поддерживаемых типов данных на метке</returns>
		[OperationContract(Name = "GetTypeModels", Action = "GetTypeModels")]
		[WebInvoke(Method = "POST", UriTemplate = "GetTypeModels")]
		[return: MessageParameter(Name = "result")]
		TypeModel[] GetTypeModels(string item);
		/// <summary>
		/// Записать модель на метку
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="index">номер модели</param>
		/// <param name="model">модель</param>
		[OperationContract(Name = "WriteModel", Action = "WriteModel")]
		[WebInvoke(Method = "POST", UriTemplate = "WriteModel")]
		void WriteModel(string item, int index, ModelImpl model);
		/// <summary>
		/// Модель по умолчанию, для типа модели
		/// </summary>
		/// <param name="item">метка</param>
		/// <param name="typeModel">тип модели</param>
		/// <returns>модель данных</returns>
		[OperationContract(Name = "Default", Action = "Default")]
		[WebInvoke(Method = "POST", UriTemplate = "GetDefault")]
		[return: MessageParameter(Name = "result")]
		ModelImpl GetDefault(string item, TypeModel typeModel);
	}
}
