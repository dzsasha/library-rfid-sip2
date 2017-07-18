using System.Configuration;

namespace IS.RFID.Service
{
	[ConfigurationCollection(typeof(ReaderImpl), AddItemName = "reader")]
	public class Readers : ConfigurationElementCollection
	{
		public Readers() { }
		#region ConfigurationElementCollection
		protected override ConfigurationElement CreateNewElement()
		{
			return new ReaderImpl();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ReaderImpl)element).Name;
		}
		#endregion

		public void Add(ReaderImpl element)
		{
			BaseAdd(element);
		}
		public void Clear()
		{
			BaseClear();
		}
		public int IndexOf(ReaderImpl element)
		{
			return BaseIndexOf(element);
		}
		public void Remove(ReaderImpl element)
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
		public ReaderImpl this[int index]
		{
			get { return (ReaderImpl)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}
		public new ReaderImpl this[string name]
		{
			get { return (ReaderImpl)BaseGet(name); }
		}
		protected override void BaseAdd(ConfigurationElement element)
		{
			BaseAdd(element, false);
		}

	}
}
