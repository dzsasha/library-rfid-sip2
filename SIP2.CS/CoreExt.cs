using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Interface;

namespace IS.SIP2.CS
{
	internal static class CoreExt
	{
		internal static Sip2FieldImpl GetFieldImpl<T>(this ISip2Fields<T> fields, String name)
		{
			Sip2FieldImpl result = null;
			foreach (IField field in fields)
			{
				if (field.Name.Equals(name))
				{
					result = field as Sip2FieldImpl;
				}
			}
			return result;
		}
	}
}
