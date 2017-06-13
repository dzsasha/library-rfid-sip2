using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using Marc.Interface;
using System.ServiceModel;

namespace Marc.Service
{
	public class ReaderImpl : ConfigurationElement, IReader
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ReaderImpl() { }
		/// <summary>
		/// Имя объекта для создания
		/// </summary>
		[ConfigurationProperty("object", IsKey = true, IsRequired = true, DefaultValue = "Marc.IDLogic")]
		public string Name
		{
			get { return ((string)(base["object"])); }
			set { base["object"] = value; }
		}
		/// <summary>
		/// Параметры для открытия реадера
		/// </summary>
		[ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection, IsDefaultCollection = true, IsRequired = false)]
		public ParamsCollection ParamsReader
		{
			get { return (ParamsCollection)base[""]; }
			set { base[""] = value; }
		}
		public IField[] Params
		{
			get
			{
				return ParamsReader.Cast<IField>().ToArray();
			}
		}

		public Type GetReaderType() { return Type.GetTypeFromProgID(Name); }

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
		public bool InitReader(IField[] param)
		{
			Reader = (IReader)Activator.CreateInstance(GetReaderType());
			return (Reader != null) && Reader.InitReader(param);
		}

		/// <summary>
		/// Закрыть реадер
		/// </summary>
		public void CloseReader()
		{
			if (Reader != null) Reader.CloseReader();
		}
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		public IItem[] Items
		{
			get
			{
				return (Reader != null) ? Reader.Items : new List<IItem>().ToArray();
			}
		}
		/// <summary>
		/// Событие ошибки
		/// </summary>
		public event ErrorEventHandler OnError
		{
			add { if (Reader != null) Reader.OnError += value; }
			remove { if (Reader != null) Reader.OnError -= value; }
		}

		public event EventHandler OnChange
		{
			add { if (Reader != null) Reader.OnChange += value; }
			remove { if (Reader != null) Reader.OnChange -= value; }
		}

		#endregion
	}
}
