using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IS.RFID.SmartCard {
    public static class External {
        public enum SCardFunctionReturnCodes : uint {
            SCARD_S_SUCCESS = 0x0,
            //'Errors
            SCARD_E_CANCELLED = 0x80100002,
            SCARD_E_INVALID_HANDLE = 0x80100003,
            SCARD_E_INVALID_PARAMETER = 0x80100004,
            SCARD_E_INVALID_TARGET = 0x80100005,
            SCARD_E_NO_MEMORY = 0x80100006,
            SCARD_F_WAITED_TOO_LONG = 0x80100007,
            SCARD_E_INSUFFICIENT_BUFFER = 0x80100008,
            SCARD_E_UNKNOWN_READER = 0x80100009,
            SCARD_E_TIMEOUT = 0x8010000A,
            SCARD_E_SHARING_VIOLATION = 0x8010000B,
            SCARD_E_NO_SMARTCARD = 0x8010000C,
            SCARD_E_UNKNOWN_CARD = 0x8010000D,
            SCARD_E_CANT_DISPOSE = 0x8010000E,
            SCARD_E_PROTO_MISMATCH = 0x8010000F,
            SCARD_E_NOT_READY = 0x80100010,
            SCARD_E_INVALID_VALUE = 0x80100011,
            SCARD_E_SYSTEM_CANCELLED = 0x80100012,
            SCARD_E_INVALID_ATR = 0x80100015,
            SCARD_E_NOT_TRANSACTED = 0x80100016,
            SCARD_E_READER_UNAVAILABLE = 0x80100017,
            SCARD_E_PCI_TOO_SMALL = 0x80100019,
            SCARD_E_READER_UNSUPPORTED = 0x8010001A,
            SCARD_E_DUPLICATE_READER = 0x8010001B,
            SCARD_E_CARD_UNSUPPORTED = 0x8010001C,
            SCARD_E_NO_SERVICE = 0x8010001D,
            SCARD_E_SERVICE_STOPPED = 0x8010001E,
            SCARD_E_UNEXPECTED = 0x8010001F,
            SCARD_E_ICC_INSTALLATION = 0x80100020,
            SCARD_E_ICC_CREATEORDER = 0x80100021,
            SCARD_E_DIR_NOT_FOUND = 0x80100023,
            SCARD_E_FILE_NOT_FOUND = 0x80100024,
            SCARD_E_NO_DIR = 0x80100025,
            SCARD_E_NO_FILE = 0x80100026,
            SCARD_E_NO_ACCESS = 0x80100027,
            SCARD_E_WRITE_TOO_MANY = 0x80100028,
            SCARD_E_BAD_SEEK = 0x80100029,
            SCARD_E_INVALID_CHV = 0x8010002A,
            SCARD_E_UNKNOWN_RES_MNG = 0x8010002B,
            SCARD_E_NO_SUCH_CERTIFICATE = 0x8010002C,
            SCARD_E_CERTIFICATE_UNAVAILABLE = 0x8010002D,
            SCARD_E_NO_READERS_AVAILABLE = 0x8010002E,
            SCARD_E_COMM_DATA_LOST = 0x8010002F,
            SCARD_E_NO_KEY_CONTAINER = 0x80100030,
            SCARD_E_SERVER_TOO_BUSY = 0x80100031,
            SCARD_E_UNSUPPORTED_FEATURE = 0x8010001F,
            //'The F...not sure
            SCARD_F_INTERNAL_ERROR = 0x80100001,
            SCARD_F_COMM_ERROR = 0x80100013,
            SCARD_F_UNKNOWN_ERROR = 0x80100014,
            //'The W...not sure
            SCARD_W_UNSUPPORTED_CARD = 0x80100065,
            SCARD_W_UNRESPONSIVE_CARD = 0x80100066,
            SCARD_W_UNPOWERED_CARD = 0x80100067,
            SCARD_W_RESET_CARD = 0x80100068,
            SCARD_W_REMOVED_CARD = 0x80100069,
            SCARD_W_SECURITY_VIOLATION = 0x8010006A,
            SCARD_W_WRONG_CHV = 0x8010006B,
            SCARD_W_CHV_BLOCKED = 0x8010006C,
            SCARD_W_EOF = 0x8010006D,
            SCARD_W_CANCELLED_BY_USER = 0x8010006E,
            SCARD_W_CARD_NOT_AUTHENTICATED = 0x8010006F,
            SCARD_W_INSERTED_CARD = 0x8010006A,
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SCARD_READERSTATE {
            /// <summary>
            /// Reader
            /// </summary>
            public string szReader;
            /// <summary>
            /// User Data
            /// </summary>
            public IntPtr pvUserData;
            /// <summary>
            /// Current State
            /// </summary>
            public UInt32 dwCurrentState;
            /// <summary>
            /// Event State/ New State
            /// </summary>
            public UInt32 dwEventState;
            /// <summary>
            /// ATR Length
            /// </summary>
            public UInt32 cbAtr;
            /// <summary>
            /// Card ATR
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbAtr;
        }
        internal enum SCardState {
            /// <summary>
            /// Unware
            /// </summary>
            UNAWARE = 0x00000000,
            /// <summary>
            /// State Ignored
            /// </summary>
            IGNORE = 0x00000001,
            /// <summary>
            /// State changed
            /// </summary>
            CHANGED = 0x00000002,
            /// <summary>
            /// State Unknown
            /// </summary>
            UNKNOWN = 0x00000004,
            /// <summary>
            /// State Unavilable
            /// </summary>
            UNAVAILABLE = 0x00000008,
            /// <summary>
            /// State empty
            /// </summary>
            EMPTY = 0x00000010,
            /// <summary>
            /// Card Present
            /// </summary>
            PRESENT = 0x00000020,
            /// <summary>
            /// ATR mathched
            /// </summary>
            ATRMATCH = 0x00000040,
            /// <summary>
            /// In exclusive use
            /// </summary>
            EXCLUSIVE = 0x00000080,
            /// <summary>
            /// In use
            /// </summary>
            INUSE = 0x00000100,
            /// <summary>
            /// Mute State
            /// </summary>
            MUTE = 0x00000200,
            /// <summary>
            /// Card unpowered
            /// </summary>
            UNPOWERED = 0x00000400
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SCARD_IO_REQUEST {
            public UInt32 dwProtocol;
            public UInt32 cbPciLength;
        }

        [DllImport("WinScard.dll")]
        public static extern SCardFunctionReturnCodes SCardEstablishContext(uint dwScope, IntPtr notUsed1, IntPtr notUsed2, out IntPtr phContext);

        [DllImport("WinScard.dll")]
        public static extern SCardFunctionReturnCodes SCardReleaseContext(IntPtr phContext);

        [DllImport("WinScard.dll", EntryPoint = "SCardConnectA", CharSet = CharSet.Ansi)]
        public static extern SCardFunctionReturnCodes SCardConnect(IntPtr hContext, string cReaderName, uint dwShareMode, uint dwPrefProtocol, ref IntPtr phCard, ref IntPtr ActiveProtocol);

        [DllImport("WinScard.dll")]
        public static extern SCardFunctionReturnCodes SCardDisconnect(IntPtr hCard, int Disposition);

        [DllImport("WinScard.dll", CharSet = CharSet.Ansi, EntryPoint = "SCardListReadersA")]
        public static extern SCardFunctionReturnCodes SCardListReaders(IntPtr hContext, byte[] mszGroups, byte[] mszReaders, ref UInt32 pcchReaders);

        [DllImport("winscard.dll", CharSet = CharSet.Ansi, EntryPoint = "SCardGetStatusChangeA")]
        public static extern SCardFunctionReturnCodes SCardGetStatusChange(IntPtr hContext, int dwTimeout, [In, Out] SCARD_READERSTATE[] rgReaderStates, UInt32 cReaders);

        [DllImport("winscard.dll")]
        public static extern SCardFunctionReturnCodes SCardTransmit(IntPtr hCard, IntPtr pioSendRequest, byte[] SendBuff, UInt32 SendBuffLen, IntPtr pioRecvRequest, byte[] RecvBuff, ref UInt32 RecvBuffLen);

        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        public extern static void FreeLibrary(IntPtr handle);

        [DllImport("kernel32.dll")]
        public extern static IntPtr GetProcAddress(IntPtr handle, string procName);

        internal static IntPtr GetPciT0() {
            IntPtr handle = LoadLibrary("Winscard.dll");
            IntPtr pci = GetProcAddress(handle, "g_rgSCardT0Pci");
            FreeLibrary(handle);
            return pci;
        }
        internal static IntPtr GetPciT1() {
            IntPtr handle = LoadLibrary("Winscard.dll");
            IntPtr pci = GetProcAddress(handle, "g_rgSCardT1Pci");
            FreeLibrary(handle);
            return pci;
        }
    }
}
