using System;
using System.Runtime.Serialization;

namespace IS.Interface {
    /// <summary>
    /// Класс имплементации интерфейса IField
    /// </summary>
    [DataContract(Name = "field", Namespace = "http://informsystema.com/marc/service/")]
    [Serializable]
    public class FieldImpl : IField {
        #region implementation IField
        /// <summary>
        /// Имя поля
        /// </summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }
        /// <summary>
        /// Описание поля
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Тип поля
        /// </summary>
        [DataMember(Name = "type")]
        public TypeField Type { get; set; }

        private object _value = null;
        /// <summary>
        /// Значение
        /// </summary>
        [DataMember(Name = "value")]
        public object Value {
            get { return _value; }
            set {
                SetValue(value);
                OnChange?.Invoke(this, new EventArgs());
            }
        }
        /// <summary>
        /// Событие изменения значения.
        /// </summary>
        public event EventHandler OnChange;
        #endregion
        /// <summary>
        /// Виртуальная функция для установки значения.
        /// </summary>
        public virtual void SetValue(object value) {
            _value = value;
        }
        /// <summary>
        /// Объект как строка
        /// </summary>
        /// <returns>строка</returns>
        public override string ToString() {
            return Value.ToString();
        }
    }
}
