using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Web;
using IS.Interface;
using IS.Interface.RFID;
using WebSocketSharp.Server;

namespace IS.RFID.Service {
    //	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    [ServiceBehavior(Name = "Service", Namespace = "http://informsystema.com/marc/service/", AddressFilterMode = AddressFilterMode.Any, InstanceContextMode = InstanceContextMode.Single)]
    public partial class ServiceImpl : IDisposable {
        /// <summary>
        /// Список реадеров
        /// </summary>
        private readonly List<ReaderImpl> _readers = new List<ReaderImpl>();
        private List<IItem> _items = new List<IItem>();
        private WebSocketServer server = null;

        private ReaderImpl getReader(string item) {
            foreach (ReaderImpl reader in _readers) {
                if (reader.Items.Any(_item => _item.Id.Equals(item))) {
                    return reader;
                }
            }
            return null;
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ServiceImpl() {
            try {
                foreach (ReaderImpl reader in Readers.Cast<ReaderImpl>().Where(reader => reader.InitReader(reader.Params))) {
                    _readers.Add(reader);
                    reader.OnError += new ErrorEventHandler(reader_OnError);
                    Log.For(this).Debug($"ServiceImpl:ServiceImpl - Adding reader {reader.GetReaderType()}");
                }
                server = new WebSocketServer(Sockets.Port);
                foreach (WebSocketImpl socketImpl in Sockets) {
                    server.AddWebSocketService<WebSocketBehavior>($"/{socketImpl.Name}", () => getImpl(socketImpl));
                }
                server.Start();
            } catch (Exception ex) {
                Log.For(null).Error($"ServiceImpl:ServiceImpl - {ex.Message}");
            }
        }
        public static WebSocketBehavior getImpl(WebSocketImpl impl) {
            return (WebSocketBehavior)Activator.CreateInstance(impl.types, new object[] { impl });
        }

        void reader_OnError(object sender, ErrorEventArgs error) {
            Log.For(sender).Error(error.GetException());
            throw new WebFaultException<String>($"OnError - {error.GetException().Message}", HttpStatusCode.InternalServerError);
        }
        /// <summary>
        /// Список реадеров в конфигурации
        /// </summary>
        public static Readers Readers {
            get {
                try {
                    ServiceSection section = (ServiceSection)ConfigurationManager.GetSection(ServiceSection.SectionName);
                    return section?.Readers;
                } catch (Exception ex) {
                    Log.For(null).Error($"ServiceImpl:Readers - {ex.Message}");
                    return null;
                }
            }
        }
        /// <summary>
        /// Список обрабатываемых websocket-ов
        /// </summary>
        public static WebSockets Sockets {
            get {
                try {
                    ServiceSection section = (ServiceSection)ConfigurationManager.GetSection(ServiceSection.SectionName);
                    return section?.Sockets;
                } catch (Exception ex) {
                    Log.For(null).Error($"ServiceImpl:Sockets - {ex.Message}");
                    return null;
                }
            }
        }

        public IItem GetItem(String item) {
            return (from reader in _readers from i in _items where i.Id == item select i).FirstOrDefault();
        }

        /// <summary>
        /// Закрыть открытые реадеры
        /// </summary>
        public void CloseReaders() {
            foreach (ReaderImpl reader in _readers) {
                reader.CloseReader();
                reader.OnError -= reader_OnError;
            }
        }

        #region public function
        public IItem[] GetItems() {
            try {
                _items.Clear();
                foreach (ReaderImpl reader in _readers) {
                    _items.AddRange(Readers[reader.Name].Items);
                }
            } catch (Exception ex) {
                Log.For(this).Error("ServiceImpl:GetItems() - {0}", ex);
                throw ex;
            }
            return _items.ToArray();
        }

        public bool IsItem(string item) {
            try {
                return GetItem(item) != null;
            } catch (Exception ex) {
                Log.For(this).Error($"ServiceImpl:IsItem - {ex.Message}");
                throw ex;
            }
        }
        public bool GetEas(string item) {
            try {
                IItem _item = GetItem(item);
                if (_item != null && _item.IsItemEx()) return (_item as IItemEx).Eas;
            } catch (Exception ex) {
                Log.For(this).Error($"ServiceImpl:GetEas - {ex.Message}");
                throw ex;
            }
            return false;
        }

        public void SetEas(string item, bool eas) {
            try {
                IItem _item = GetItem(item);
                if (getReader(item).RevertEAS) {
                    if (_item != null && _item.IsItemEx()) (_item as IItemEx).Eas = !eas;
                } else {
                    if (_item != null && _item.IsItemEx()) (_item as IItemEx).Eas = eas;
                }
            } catch (Exception ex) {
                Log.For(this).Error($"ServiceImpl:SetEas - {ex.Message}");
                throw ex;
            }
        }
        public ModelImpl[] GetModels(string item) {
            List<ModelImpl> lRet = new List<ModelImpl>();
            if (item != null) {
                try {
                    IItem _item = GetItem(item);
                    if (_item != null && _item.IsItemModel()) {
                        lRet.AddRange(from typeModel in (_item as IItemModel).Models from model in typeModel select new ModelImpl(model.Model) { Id = model.Id, Type = model.Type });
                    }
                } catch (Exception ex) {
                    Log.For(this).Error($"ServiceImpl:GetModels - {ex.Message}");
                    throw ex;
                }
            }
            return lRet.ToArray();
        }
        public ModelImpl GetDefault(string item, TypeModel typeModel) {
            ModelImpl pRet = null;
            try {
                IItem _item = GetItem(item);
                if (_item != null && _item.IsItemModel()) {
                    foreach (ITypeModel model in (_item as IItemModel).Models.Where(model => model.Model == typeModel)) {
                        pRet = new ModelImpl(typeModel) { Id = model.Default.Id, Type = model.Default.Type };
                    }
                }
            } catch (Exception ex) {
                Log.For(this).Error($"ServiceImpl:GetDefault - {ex.Message}");
                throw ex;
            }
            return pRet;
        }
        public TypeModel[] GetTypeModels(string item) {
            List<TypeModel> lRet = new List<TypeModel>();
            try {
                IItem _item = GetItem(item);
                if (_item != null && _item.IsItemModel()) {
                    lRet.AddRange((_item as IItemModel).Models.Select(model => model.Model));
                }
                Log.For(this).Debug($"ServiceImpl:GetTypeModels - {lRet.Count}");
            } catch (Exception ex) {
                Log.For(this).Error($"ServiceImpl:GetTypeModels - {ex.Message}");
                throw ex;
            }
            return lRet.ToArray();
        }
        public void WriteModel(string item, int index, ModelImpl model) {
            IItem _item = GetItem(item);
            if (_item != null && _item.IsItemModel()) {
                try {
                    foreach (ITypeModel typeModel in (_item as IItemModel).Models) {
                        if (typeModel.Model == model.Model) {
                            IModel addModel = typeModel.Default;
                            addModel.Id = model.Id;
                            addModel.Type = model.Type;
                            if (!typeModel.Any()) {
                                typeModel.Add(addModel);
                            }
                            addModel.Write();
                            Log.For(this).Debug($"ServiceImpl:WriteModel - {addModel.Id}");
                        }
                    }
                } catch (Exception ex) {
                    Log.For(this).Error($"ServiceImpl:WriteModel - {ex.Message}");
                    throw ex;
                }
            }
        }
        #endregion

        #region IDisposable
        public void Dispose() {
            server?.Stop();
            CloseReaders();
        }
        #endregion
    }
}
