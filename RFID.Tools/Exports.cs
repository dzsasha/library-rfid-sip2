using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;

namespace IS.RFID.Tools
{
    public static class Exports
    {
        [DllExport("FourFirstReverse", System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static string FourFirstReverse(IntPtr input, int length)
        {
            string sRet = "";
            byte[] data = new byte[length];
            Marshal.Copy(input, data, 0, length);
            for (int i = 3; i > -1; i--)
            {
                sRet += String.Format("{0:x2}", data[i]);
            }
            return sRet.ToUpper();
        }
    }
}
