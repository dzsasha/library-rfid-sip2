using System;
using System.Runtime.InteropServices;

namespace IS.RFID.SmartCard {
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public delegate string OnNumberReplace(IntPtr input, int length);
}
