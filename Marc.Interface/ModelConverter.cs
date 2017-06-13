using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Marc.Interface
{
	/// <summary>
	/// Класс конвертор для модели метки
	/// </summary>
	public class ModelConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				MemoryStream stream1 = new MemoryStream(Encoding.Unicode.GetBytes(value.ToString()));
				DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ModelImpl));
				stream1.Position = 0;
				return (ModelImpl)ser.ReadObject(stream1);
			}
			catch (Exception ex)
			{
				Log.For(this).Error(String.Format("ModelConverter:ConvertFrom - {0}", ex.Message));
				return null;
			}
		}
	}
}
