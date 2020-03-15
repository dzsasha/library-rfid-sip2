using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.Service {
    public class ReaderImpl : ConfigurationElement, IReader {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ReaderImpl() {
        }
        /// <summary>
        /// Имя объекта для создания
        /// </summary>
        [ConfigurationProperty("object", IsKey = true, IsRequired = true)]
        public string Name {
            get { return ((string)(base["object"])); }
            set { base["object"] = value; }
        }
        /// <summary>
        /// Параметры для открытия реадера
        /// </summary>
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection, IsDefaultCollection = true, IsRequired = false)]
        public ParamsCollection ParamsReader {
            get { return (ParamsCollection)base[""]; }
            set { base[""] = value; }
        }
        public IField[] Params => ParamsReader.Cast<IField>().ToArray();

        /// <summary>
        /// Поменять значения для установки противокражного бита
        /// </summary>
        [ConfigurationProperty("revert", DefaultValue = false)]
        public bool RevertEAS {
            get { return Convert.ToBoolean(base["revert"]); }
            set { base["revert"] = value; }
        }
        /// <summary>
        /// Использовать только для одиночного чтения
        /// </summary>
        [ConfigurationProperty("disable", DefaultValue = false)]
        public bool Disable {
            get { return Convert.ToBoolean(base["disable"]); }
            set { base["disable"] = value; }
        }
        /// <summary>
        /// Всегда пытаться инициализировать считыватель перед получением меток
        /// </summary>
        [ConfigurationProperty("force", DefaultValue = false)]
        public bool Force {
            get { return Convert.ToBoolean(base["force"]); }
            set { base["force"] = value; }
        }
        public Type GetReaderType() {
            return Type.GetTypeFromProgID(Name);
        }

        #region Поддерживаемые интрефейсы
        /// <summary>
        /// Сам реадер
        /// </summary>
        private IReader Reader { get; set; }
        #endregion

        #region IReader
        /// <summary>
        /// Открыть реадер
        /// </summary>
        /// <param name="param">параметры для реадера</param>
        /// <returns>успешность открытия реадера</returns>
        public bool InitReader(IField[] param) {
            if(Reader == null) {
                Type readerType = GetReaderType();
                Log.For(this).Debug($"ReaderType: {readerType}");
                Reader = (readerType != null) ? (IReader)Activator.CreateInstance(readerType) : null;
            }
            Log.For(this).Debug($"InitReader: {Name}");
            return (Reader != null) && Reader.InitReader(param);
        }

        /// <summary>
        /// Закрыть реадер
        /// </summary>
        public void CloseReader() {
            Log.For(this).Debug("CloseReader");
            Reader?.CloseReader();
        }
        /// <summary>
        /// Получить прочитанные метки
        /// </summary>
        public IItem[] Items => (Reader != null) ? Reader.Items : new List<IItem>().ToArray();

        /// <summary>
        /// Событие ошибки
        /// </summary>
        public event ErrorEventHandler OnError {
            add { if(Reader != null) Reader.OnError += value; }
            remove { if(Reader != null) Reader.OnError -= value; }
        }

        public event EventHandler OnChange {
            add { if(Reader != null) Reader.OnChange += value; }
            remove { if(Reader != null) Reader.OnChange -= value; }
        }

        #endregion
    }
}
