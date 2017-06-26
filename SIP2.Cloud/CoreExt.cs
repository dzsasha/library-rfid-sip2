using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InformSystema.Interface;

namespace InformSystema.SIP2.Cloud
{
	internal static class CoreExt
	{
		internal static IField GetField(this IField[] fields, String name)
		{
			IField result = null;
			foreach (IField field in fields.Where(field => field.Name.Equals(name)))
			{
				result = field;
			}
			return result;
		}
	}
}
