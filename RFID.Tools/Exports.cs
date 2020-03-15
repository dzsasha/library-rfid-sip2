using System;
using System.Runtime.InteropServices;

namespace IS.RFID.Tools {
    public static class Exports {
        [DllExport("FourFirstReverse", CallingConvention.StdCall)]
        public static string FourFirstReverse(IntPtr input, int length) {
            string sRet = "";
            byte[] data = new byte[length];
            Marshal.Copy(input, data, 0, length);
            for(int i = 3; i > -1; i--) {
                sRet += String.Format("{0:x2}", data[i]);
            }
            return sRet.ToUpper();
        }
        [DllExport("DecFourFirst", CallingConvention.StdCall)]
        public static string DecFourFirst(IntPtr input, int length) {
            string sRet = "0x";
            byte[] data = new byte[length];
            Marshal.Copy(input, data, 0, length);
            for(int i = 0; i < 4; i++) {
                sRet += String.Format("{0:x2}", data[i]);
            }
            return String.Format("{0}", Convert.ToInt64(sRet, 16));
        }
    }
}
