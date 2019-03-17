using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace IS.RFID.IDLogic {
    class Externals {
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

        private static void ErrorExecute(int iError, string funcName = "") {
            if (iError != 1) {
                string errorMessage = "";
                switch (iError) {
                    case -100: errorMessage = "Ошибка конфиг файла"; break;
                    case -1: errorMessage = String.Format("Ошибка записи в функции: {0}", funcName); break;
                    case -2: errorMessage = "Не реализовано компанией IDLogic"; break;
                    case -3: errorMessage = "Не поддерживается в принципе данным оборудованием"; break;
                    case 2: errorMessage = "Не найдена метка"; break;
                    case 3: errorMessage = "Невалидная модель данных"; break;
                    case 0: errorMessage = "Ошибки команд КАШВ оборудования"; break;
                }
                throw new RfidException(errorMessage);
            }
        }

        public static bool IsReaderOnline() {
            int StateOK;
            lock (objLock) {
                ErrorExecute(_IsReaderOnline(out StateOK), "IsReaderOnline");
            }
            return Convert.ToBoolean(StateOK);
        }
        public static string RfidReadData() {
            lock (objLock) {
                StringBuilder pData = new StringBuilder(1025);
                int iCount;
                ErrorExecute(_RfidReadData(out iCount, pData, 1, 1), "RfidReadData");
                return pData.ToString();
            }
        }

        public static bool EasGet(string Id) {
            byte bRet = 0;
            lock (objLock) {
                ErrorExecute(_RfidEASGet(Id, ref bRet), "EasGet");
            }
            return Convert.ToBoolean(bRet);
        }
        public static void EasSet(string Id, bool eas) {
            lock (objLock) {
                ErrorExecute(_RfidEASSet(Id, Convert.ToByte(eas)), "EasSet");
            }
        }
        public static void InitModel(string Id, TypeItem Type) {
            lock (objLock) {
                ErrorExecute(_RfidDM15Init(Id, Convert.ToByte(DanishModelImpl.TypeToString(Type))), "InitModel");
            }
        }
        public static DanishModelImpl ReadModel(string Id, DanishModelImpl model) {
            lock (objLock) {
                StringBuilder sb = new StringBuilder(1025);
                ErrorExecute(_RfidDM15Read(Id, sb), "ReadModel");
                List<string> sReadModel = new List<string>(sb.ToString().Split(';'));
                if (sReadModel.Count > 0) model.Type = DanishModelImpl.StringToType(sReadModel[0].Trim());
                if (sReadModel.Count > 1) model.SPartsinItem = sReadModel[1].Trim();
                if (sReadModel.Count > 2) model.SPartNumber = sReadModel[2].Trim();
                if (sReadModel.Count > 3) model.Id = sReadModel[3].Trim();
                if (sReadModel.Count > 4) model.SCountryLibrary = sReadModel[4].Trim();
                if (sReadModel.Count > 5) model.SIsil = sReadModel[5].Trim();
                return model;
            }
        }
        public static void WriteModel(string Id, DanishModelImpl model) {
            lock (objLock) {
                ErrorExecute(_RfidDM15Write(Id, model.ToString()), "WriteModel");
            }
        }
        public static void RemoveModel(string Id) {
            lock (objLock) {
                ErrorExecute(_RfidDM15Erase(Id), "RemoveModel");
            }
        }
    }
}
