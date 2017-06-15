using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
{
	public class ParamsCollection : ConfigurationElementCollection, ISip2Answers
	{
		public ParamsCollection() { }
		#region ConfigurationElementCollection
		protected override ConfigurationElement CreateNewElement()
		{
			return new ParamElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ParamElement)element).Name;
		}
		#endregion

		public void Add(ParamElement element)
		{
			BaseAdd(element);
		}
		public void Clear()
		{
			BaseClear();
		}
		public int IndexOf(ParamElement element)
		{
			return BaseIndexOf(element);
		}
		public void Remove(ParamElement element)
		{
			if (BaseIndexOf(element) >= 0)
			{
				BaseRemove(element.Name);
			}
		}
		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}
		public ParamElement this[int index]
		{
			get { return (ParamElement)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}
		[ConfigurationProperty("object", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)base["object"]; }
			set { base["object"] = value; }
		}
		[ConfigurationProperty("port", IsRequired = true)]
		public int Port
		{
			get { return Convert.ToInt16(base["port"]); }
			set { base["port"] = value; }
		}
		[ConfigurationProperty("proto", IsRequired = true)]
		public string Proto
		{
			get { return (string)base["proto"]; }
			set { base["port"] = value; }
		}
		public IField[] Params
		{
			get
			{
				return this.Cast<IField>().ToArray();
			}
		}

		private ISip2Answers _answer = null;

		#region implementation ISip2Answers
		public bool Init(IField[] paramsFields)
		{
			if (_answer == null) _answer = (ISip2Answers)Activator.CreateInstance(Type.GetTypeFromProgID(Name));
			return (_answer != null && _answer.Init(paramsFields));
		}

		public ISip2Command[] Commands
		{
			get { return (_answer != null) ? _answer.Commands : new List<ISip2Command>().ToArray(); }
		}
		public event ErrorEventHandler OnError
		{
			add { if (_answer != null) _answer.OnError += value; }
			remove { if (_answer != null) _answer.OnError += value; }
		}
		#endregion
	}
}
