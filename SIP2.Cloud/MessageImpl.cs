using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.Cloud
{
	[Guid("AEB3668D-B17A-40E7-8D44-BB1FE9813306")]
	[ComVisible(true)]
	[ProgId("SIP2.Cloud")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class MessageImpl : Collection<ISip2Command>, ISip2Answers
	{
		public MessageImpl()
		{
			// TODO: Заполнение массива возможными коммандами
		}
		public bool Init(IField[] paramsFields)
		{
			try
			{
				foreach (IField field in paramsFields)
				{
					// TODO: обработчик
				}
			}
			catch (Exception ex)
			{
				if (OnError != null) OnError(this, new ErrorEventArgs(ex));
				return false;
			}
			return true;
		}

		public ISip2Command[] Commands
		{
			get { return this.ToArray(); }
		}

		public event ErrorEventHandler OnError;
	}
}
