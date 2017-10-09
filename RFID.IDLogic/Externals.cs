using IS.Interface.RFID;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IS.RFID.IDLogic
{
	class Externals
	{
		private static object objLock = new object();
		const string lib_name = "EasyBook_RFid.dll";
        [return: MarshalAs(UnmanagedType.I4)]
        [DllImport(lib_name, EntryPoint = "IsReaderOnline", CallingConvention = CallingConvention.StdCall)]
        private static extern int _IsReaderOnline(out int StateOK, int ReaderNo = 1);
        [DllImport(lib_name, EntryPoint = "RfidReadDataByCfgPtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidReadData(out int TagsCount, [MarshalAs(UnmanagedType.LPStr)] StringBuilder Data, int ReaderNo = 1, int AFullDM = 0, int AEAS = 0, int AReadTypeID = -1);
        [DllImport(lib_name, EntryPoint = "RfidDM15InitPtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidDM15Init([MarshalAs(UnmanagedType.LPStr)] string AUID, byte ATypeUsage, int ReaderNo = 1);
        [DllImport(lib_name, EntryPoint = "RfidDM15WritePtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidDM15Write([MarshalAs(UnmanagedType.LPStr)] string AUID, [MarshalAs(UnmanagedType.LPStr)] string ADM, int ReaderNo = 1);
        [DllImport(lib_name, EntryPoint = "RfidDM15ReadPtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidDM15Read([MarshalAs(UnmanagedType.LPStr)] string AUID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder ADM, int ReaderNo = 1);
        [DllImport(lib_name, EntryPoint = "RfidEASGetPtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidEASGet([MarshalAs(UnmanagedType.LPStr)] string AUID, ref byte Value, int ReaderNo = 1);
        [DllImport(lib_name, EntryPoint = "RfidEASSetPtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidEASSet([MarshalAs(UnmanagedType.LPStr)] string AUID, byte Value, int ReaderNo = 1);
        [DllImport(lib_name, EntryPoint = "RfidDM15ErasePtr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int _RfidDM15Erase([MarshalAs(UnmanagedType.LPStr)] string AUID, int ReaderNo = 1);

        public static bool IsReaderOnline()
        {
            int StateOK;
            lock (objLock)
            {
                _IsReaderOnline(out StateOK);
            }
            return Convert.ToBoolean(StateOK);
        }
        public static string RfidReadData()
        {
            lock(objLock)
            {
                StringBuilder pData = new StringBuilder(1025);
                int iCount;
                _RfidReadData(out iCount, pData, 1, 1);
                return pData.ToString();
            }
        }

        public static bool EasGet(string Id)
        {
            byte bRet = 0;
            lock(objLock)
            {
                _RfidEASGet(Id, ref bRet);
            }
            return Convert.ToBoolean(bRet);
        }
        public static void EasSet(string Id, bool eas)
        {
            lock (objLock)
            {
                _RfidEASSet(Id, Convert.ToByte(eas));
            }
        }
        public static void InitModel(string Id, TypeItem Type)
        {
            lock (objLock)
            {
                _RfidDM15Init(Id, Convert.ToByte(DanishModelImpl.TypeToString(Type)));
            }
        }
        public static void WriteModel(string Id, DanishModelImpl model)
        {
            lock (objLock)
            {
                StringBuilder sb = new StringBuilder(1025);
                _RfidDM15Read(Id, sb);
                RfidReadData();
                _RfidDM15Write(Id, model.ToString());
                RfidReadData();
            }
        }
    }
}
