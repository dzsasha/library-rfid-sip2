using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Имплементация настроек
    /// </summary>
    public class Sip2ConfigImpl : ISip2Config {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Sip2ConfigImpl(IField[] param, bool isDebug, Char Separator) {
            _param = new List<IField>();
            _param.AddRange(param);
            this.isDebug = isDebug;
            this.Separator = Separator;
            this.Version = Sip2Version.V200;
        }
        /// <summary>
        /// Добавить к параметрам
        /// </summary>
        /// <param name="field">параметр</param>
        public void AddParam(IField field) {
            _param.Add(field);
        }
        private List<IField> _param { get; set; }

        #region implemenets ISip2Config
        /// <summary>
        /// Различные параметры из конфигурации приложения
        /// </summary>
        public IField[] param => _param.ToArray();

        /// <summary>
        /// Текущая версия
        /// </summary>
        public Sip2Version Version { get; set; }
        /// <summary>
        /// Включать отладочную информацию
        /// </summary>
        public bool isDebug { get; set; }
        /// <summary>
        /// Символ-разграничитель для полей переменной длинны
        /// </summary>
        public char Separator { get; set; }

        #endregion
    }
}
