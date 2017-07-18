using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using IS.Interface.RFID;

namespace IS.RFID.Service
{
	public static class CoreExtended
	{
		public static bool IsItemEx(this IItem item)
		{
			try
			{
				return (Marshal.GetComInterfaceForObject(item, typeof(IItemEx))) != null;
			}
			catch
			{
				return false;
			}
		}
		public static bool IsItemModel(this IItem item)
		{
			try
			{
				return (Marshal.GetComInterfaceForObject(item, typeof(IItemModel))) != null;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsModelEx(this IModel model)
		{
			try
			{
				return (Marshal.GetComInterfaceForObject(model, typeof(IModelEx))) != null;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public static string GetName(this IReader Reader)
		{
			foreach (ReaderImpl reader in ServiceImpl.Readers.Cast<ReaderImpl>().Where(reader => reader.GetReaderType() == Reader.GetType()))
			{
				return reader.Name;
			}
			return "";
		}
	}
}
