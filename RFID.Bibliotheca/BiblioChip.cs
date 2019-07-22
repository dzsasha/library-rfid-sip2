using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using IS.Interface.RFID;

namespace IS.RFID.Bibliotheca {
    public static class External {
        const string lib_name = "BiblioChip.dll";
        public static int ExternalError(int iValue) {
            if (iValue < 0) {
                string errorMessage = "";
                switch (iValue) {
                    case -1: errorMessage = "unknown error"; break;
                    case -100: errorMessage = "Reader DLL not found"; break;
                    case -101: errorMessage = "Reader DLL: function not found"; break;
                    case -102: errorMessage = "Reader DLL: error"; break;
                    case -103: errorMessage = "Reader DLL: ISO error"; break;
                    case -104: errorMessage = "write error"; break;
                    case -105: errorMessage = "itsTransponder is nil"; break;
                    case -106: errorMessage = "index out of range"; break;
                    case -200: errorMessage = "its DataModel is nil"; break;
                    case -201: errorMessage = "Datamodel not supported for this transponder type"; break;
                    case -300: errorMessage = "mirror check failed"; break;
                    case -400: errorMessage = "firstByte > lastByte (internal error)"; break;
                    case -401: errorMessage = "firstBit > lastBit (internal error)"; break;
                    case -402: errorMessage = "CRC check failed"; break;
                    case -403: errorMessage = "field not available"; break;
                    case -404: errorMessage = "illegal character"; break;
                    case -405: errorMessage = "illegal format"; break;
                    case -406: errorMessage = "illegal value"; break;
                    case -407: errorMessage = "too much data for tag"; break;
                    case -408: errorMessage = "XOR check failed in extension n"; break;
                }
                throw new RfidException(errorMessage, iValue);
            } else return iValue;
        }
        [DllImport(lib_name, EntryPoint = "BibOpenReader")]
        public static extern int _BibOpenReader();

        [DllImport(lib_name, EntryPoint = "BibCloseReader")]
        public static extern int _BibCloseReader();
        [DllImport(lib_name, EntryPoint = "BibInventory")]
        public static extern int _BibInventory();
        [DllImport(lib_name, EntryPoint = "BibGetTransponderUID")]
        private static extern int _BibGetTransponderUID(int trp, ref IntPtr uid);
        [DllImport(lib_name, EntryPoint = "BibGetIsItemLabel")]
        public static extern int _BibGetIsItemLabel(int trp);
        [DllImport(lib_name, EntryPoint = "BibInitItemLabel")]
        public static extern int _BibInitItemLabel(int trp);
        [DllImport(lib_name, EntryPoint = "BibGetIsUserCard")]
        public static extern int _BibGetIsUserCard(int trp);
        [DllImport(lib_name, EntryPoint = "BibInitUserCard")]
        public static extern int _BibInitUserCard(int trp);
        [DllImport(lib_name, EntryPoint = "BibGetItemCheckedOut")]
        public static extern int _BibGetItemCheckedOut(int trp);
        [DllImport(lib_name, EntryPoint = "BibWriteChangedPages")]
        public static extern int _BibWriteChangedPages(int trp);
        [DllImport(lib_name, EntryPoint = "BibGetDataModelID")]
        public static extern int _BibGetDataModelID(int trp);
        [DllImport(lib_name, EntryPoint = "BibSetItemCheckedOut")]
        public static extern int _BibSetItemCheckedOut(int trp, int flag);
        [DllImport(lib_name, EntryPoint = "BibGetItemID")]
        private static extern int _BibGetItemID(int trp, ref IntPtr id);
        [DllImport(lib_name, EntryPoint = "BibSetItemID")]
        public static extern int _BibSetItemID(int trp, string id);
        [DllImport(lib_name, EntryPoint = "BibSetUserID")]
        public static extern int _BibSetUserID(int trp, string id);
        [DllImport(lib_name, EntryPoint = "BibGetLibraryInstitutionID")]
        private static extern int _BibGetLibraryInstitutionID(int trp, ref IntPtr id);
        [DllImport(lib_name, EntryPoint = "BibSetLibraryInstitutionID")]
        public static extern int _BibSetLibraryInstitutionID(int trp, string id);
        [DllImport(lib_name, EntryPoint = "BibGetLibraryCountryID")]
        private static extern int _BibGetLibraryCountryID(int trp, ref IntPtr id);
        [DllImport(lib_name, EntryPoint = "BibSetLibraryCountryID")]
        public static extern int _BibSetLibraryCountryID(int trp, string id);
        public static int BibOpenReader() {
            return ExternalError(_BibOpenReader());
        }
        public static int BibCloseReader() {
            return ExternalError(_BibCloseReader());
        }
        public static int BibInventory() {
            return ExternalError(_BibInventory());
        }
        public static string BibGetTransponderUID(int trp) {
            IntPtr ptr = IntPtr.Zero;
            _BibGetTransponderUID(trp, ref ptr);
            return Marshal.PtrToStringAnsi(ptr);
        }
        public static int BibGetIsItemLabel(int trp) {
            return ExternalError(_BibGetIsItemLabel(trp));
        }
        public static int BibInitItemLabel(int trp) {
            return ExternalError(_BibInitItemLabel(trp));
        }
        public static int BibGetIsUserCard(int trp) {
            return ExternalError(_BibGetIsUserCard(trp));
        }
        public static int BibInitUserCard(int trp) {
            return ExternalError(_BibInitUserCard(trp));
        }
        public static int BibGetItemCheckedOut(int trp) {
            return ExternalError(_BibGetItemCheckedOut(trp));
        }
        public static int BibWriteChangedPages(int trp) {
            return ExternalError(_BibWriteChangedPages(trp));
        }
        public static int BibGetDataModelID(int trp) {
            return _BibGetDataModelID(trp);
        }
        public static int BibSetItemCheckedOut(int trp, int flag) {
            return ExternalError(_BibSetItemCheckedOut(trp, flag));
        }
        public static string BibGetItemID(int trp) {
            IntPtr ptr = IntPtr.Zero;
            ExternalError(_BibGetItemID(trp, ref ptr));
            return Marshal.PtrToStringAnsi(ptr);
        }
        public static int BibSetLibraryInstitutionID(int trp, string id) {
            return ExternalError(_BibSetLibraryInstitutionID(trp, id));
        }
        public static string BibGetLibraryInstitutionID(int trp) {
            IntPtr ptr = IntPtr.Zero;
            ExternalError(_BibGetLibraryInstitutionID(trp, ref ptr));
            return Marshal.PtrToStringAnsi(ptr);
        }
        public static int BibSetItemID(int trp, string id) {
            return ExternalError(_BibSetItemID(trp, id));
        }
        public static int BibSetUserID(int trp, string id) {
            return ExternalError(_BibSetUserID(trp, id));
        }
        public static string BibGetLibraryCountryID(int trp) {
            IntPtr ptr = IntPtr.Zero;
            ExternalError(_BibGetLibraryCountryID(trp, ref ptr));
            return Marshal.PtrToStringAnsi(ptr);
        }
        public static int BibSetLibraryCountryID(int trp, string id) {
            return ExternalError(_BibSetLibraryCountryID(trp, id));
        }
    }
}
