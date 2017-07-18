using System.Configuration;

namespace IS.RFID.Service
{
	public class ParamsCollection : ConfigurationElementCollection
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
	}
}
