using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marc.RFID.IDLogic
{
	public delegate void OnErrorDelegate(string errorMessage);
	public delegate void OnReadDelegate(IMarcLabelData pData);
}
