using System;
using System.Linq;
using System.ServiceModel.Web;
using IS.Interface.RFID;
using System.Net;

namespace IS.RFID.Service {
    public partial class ServiceImpl : IServiceRFID {
        #region implementation IServiceRfid
        string[] IServiceRFID.Read() {
            (this as IServiceRFID).Options();
            try {
                return Read().Select(item => item.Id).ToArray();
            } catch(Exception ex) {
                throw new WebFaultException<String>($"Read - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Получить прочитанные метки
        /// </summary>
        /// <returns>прочитанные метки</returns>
        string[] IServiceRFID.GetItems() {
            (this as IServiceRFID).Options();
            try {
                return GetItems().Select(item => item.Id).ToArray();
            } catch(Exception ex) {
                throw new WebFaultException<String>($"GetItems - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Метка пришла из этого сервиса?
        /// </summary>
        /// <param name="item">метка</param>
        /// <returns>успешность</returns>
        bool IServiceRFID.IsItem(string item) {
            (this as IServiceRFID).Options();
            try {
                return IsItem(item);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"IsItem - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Получить состояние противокражного бита
        /// </summary>
        /// <param name="item">метка</param>
        /// <returns>противиокражный бит</returns>
        bool IServiceRFID.GetEas(string item) {
            (this as IServiceRFID).Options();
            try {
                return GetEas(item);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"GetEas - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Установить противокражный бит
        /// </summary>
        /// <param name="item">метка</param>
        /// <param name="eas">противокражный бит</param>
        void IServiceRFID.SetEas(string item, bool eas) {
            (this as IServiceRFID).Options();
            try {
                SetEas(item, eas);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"SetEas - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Получение данных с модели метки
        /// </summary>
        /// <param name="item">метка</param>
        /// <returns>данные модели</returns>
        ModelImpl[] IServiceRFID.GetModels(string item) {
            (this as IServiceRFID).Options();
            try {
                return GetModels(item);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"GetModels - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Модель по умолчанию, для типа модели
        /// </summary>
        /// <param name="item">метка</param>
        /// <param name="typeModel">тип модели</param>
        /// <returns>модель данных</returns>
        ModelImpl IServiceRFID.GetDefault(string item, TypeModel typeModel) {
            (this as IServiceRFID).Options();
            try {
                return GetDefault(item, typeModel);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"GetDefault - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Получение поддерживаемых типов моделей данных на метке
        /// </summary>
        /// <param name="item">метка</param>
        /// <returns>массив поддерживаемых типов данных н аметке</returns>
        TypeModel[] IServiceRFID.GetTypeModels(string item) {
            (this as IServiceRFID).Options();
            try {
                return GetTypeModels(item);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"GetTypeModels - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Записать модель на метку
        /// </summary>
        /// <param name="item">метка</param>
        /// <param name="index">номер модели</param>
        /// <param name="model">модель</param>
        void IServiceRFID.WriteModel(string item, int index, ModelImpl model) {
            (this as IServiceRFID).Options();
            try {
                WriteModel(item, index, model);
            } catch(Exception ex) {
                throw new WebFaultException<String>($"WriteModel - {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        void IServiceRFID.Options() {
            if(WebOperationContext.Current != null) {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin, Origin, X-Requested-With, Content-Type, Accept");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "OPTIONS, POST, GET");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Credentials", "false");
            }
        }

        #endregion
    }
}
