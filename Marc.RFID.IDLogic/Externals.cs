using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Marc.Interface;

namespace Marc.RFID.IDLogic
{
	class Externals
	{
		private static object objLock = new object();
		const string lib_name = "IdLogicRFidLibrary.dll";
		[DllImport(lib_name, EntryPoint = "IsCardReaderOnline")]
		private static extern int _IsCardReaderOnline();
		[DllImport(lib_name, EntryPoint = "IsRfidReaderOnline")]
		private static extern int _IsRfidReaderOnline();
		[DllImport(lib_name, EntryPoint = "CardReaderRead")]
		private static extern int _CardReaderRead(StringBuilder uid);
		[DllImport(lib_name, EntryPoint = "RfidRead", CharSet = CharSet.Ansi)]
		private static extern int _RfidRead([MarshalAs(UnmanagedType.LPStr)] StringBuilder uid);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "EasGet")]
		private static extern int _EasGet(string uid);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "EasSet")]
		private static extern int _EasSet(string uid);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "EasReset")]
		private static extern int _EasReset(string uid);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "DM_BookLabel_Init")]
		private static extern int _DM_BookLabel_Init(string uid);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "DM_UserCard_Init")]
		private static extern int _DM_UserCard_Init(string uid);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "DM_Data_Read")]
		private static extern int _DM_Data_Read(string uid, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aTypeUsage, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aPartsinItem, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aPartNumber, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aPrimaryItemId, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aCountryLibrary, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aISIL);
		[DllImport(lib_name, CharSet = CharSet.Ansi, EntryPoint = "DM_Data_Write", CallingConvention = CallingConvention.StdCall)]
		private static extern int _DM_Data_Write(string uid, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aTypeUsage, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aPartsinItem, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aPartNumber, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aPrimaryItemId, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aCountryLibrary, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aISIL);

		public static int IsCardReaderOnline()
		{
			lock (objLock)
			{
				return _IsCardReaderOnline();
			}
		}
		public static int IsRfidReaderOnline()
		{
			lock (objLock)
			{
				return _IsRfidReaderOnline();
			}
		}
		public static string RfidRead()
		{
			lock (objLock)
			{
				StringBuilder sOut = new StringBuilder(1024);
				return (_RfidRead(sOut) > 0) ? sOut.ToString() : "";
			}
		}

		public static string CardReaderRead()
		{
			lock (objLock)
			{
				StringBuilder sOut = new StringBuilder(1024);
				return (_CardReaderRead(sOut) > 0) ? sOut.ToString() : "";
			}
		}
		public static int EasGet(string uid)
		{
			lock (objLock)
			{
				return _EasGet(uid);
			}
		}
		public static int EasSet(string uid)
		{
			lock (objLock)
			{
				return _EasSet(uid);
			}
		}
		public static int EasReset(string uid)
		{
			lock (objLock)
			{
				return _EasReset(uid);
			}
		}
		public static DanishModelImpl ReadModel(string uid, DanishModelImpl model)
		{
			lock (objLock)
			{
				StringBuilder aTypeUsage = new StringBuilder();
				StringBuilder aPartsinItem = new StringBuilder();
				StringBuilder aPartNumber = new StringBuilder();
				StringBuilder aPrimaryItemId = new StringBuilder();
				StringBuilder aCountryLibrary = new StringBuilder();
				StringBuilder aIsil = new StringBuilder();
				switch (_DM_Data_Read(uid, aTypeUsage, aPartsinItem, aPartNumber, aPrimaryItemId, aCountryLibrary, aIsil))
				{
					case -1: throw new RfidException("Oшибка чтения");
					case 0: throw new RfidException("RFID-ридер недоступен/не подключен");
					case 2: throw new RfidException("Метка не найдена");
					case 3: throw new RfidException("Данные некорректны");
					case 4: throw new RfidException("Некорректные входные параметры");
					default:
					{
						model.STypeUsage = aTypeUsage.ToString();
						model.SPartsinItem = aPartsinItem.ToString();
						model.SPartNumber = aPartNumber.ToString();
						model.SPrimaryItemId = aPrimaryItemId.ToString();
						model.SCountryLibrary = aCountryLibrary.ToString();
						model.SIsil = aIsil.ToString();
					}
					break;
				}
				return model;
			}
		}

		public static void WriteModel(string uid, DanishModelImpl model)
		{
			lock (objLock)
			{
				StringBuilder aTypeUsage = new StringBuilder(model.STypeUsage);
				StringBuilder aPartsinItem = new StringBuilder(model.SPartsinItem);
				StringBuilder aPartNumber = new StringBuilder(model.SPartNumber);
				StringBuilder aPrimaryItemId = new StringBuilder(model.SPrimaryItemId);
				StringBuilder aCountryLibrary = new StringBuilder(model.SCountryLibrary);
				StringBuilder aIsil = new StringBuilder(model.SIsil);
				switch (_DM_Data_Write(uid, aTypeUsage, aPartsinItem, aPartNumber, aPrimaryItemId, aCountryLibrary, aIsil))
				{
					case -1: throw new RfidException("Oшибка чтения");
					case 0: throw new RfidException("RFID-ридер недоступен/не подключен");
					case 2: throw new RfidException("Метка не найдена");
					case 3: throw new RfidException("Данные некорректны");
					case 4: throw new RfidException("Некорректные входные параметры");
				}
			}
		}

		public static void BookLabelInit(string uid)
		{
			lock (objLock)
			{
				switch (_DM_BookLabel_Init(uid))
				{
					case -1: throw new Exception("Oшибка записи");
					case 0: throw new Exception("RFID-ридер недоступен/не подключен");
					case 2: throw new Exception("Метка не найдена");
				}
			}
		}

		public static void UserCardInit(string uid)
		{
			lock (objLock)
			{
				switch (_DM_UserCard_Init(uid))
				{
					case -1: throw new Exception("Oшибка записи");
					case 0: throw new Exception("RFID-ридер недоступен/не подключен");
					case 2: throw new Exception("Метка не найдена");
				}
			}
		}
	}
}
