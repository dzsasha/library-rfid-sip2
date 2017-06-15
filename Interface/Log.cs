using System;
using System.Reflection;
using log4net.Config;
using log4net;

namespace InformSystema.Interface
{
	/// <summary>
	/// Класс логгирования
	/// </summary>
	public class Log
	{
		static Log()
		{
			XmlConfigurator.Configure();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="loggedObject"></param>
		/// <returns></returns>
		public static ILog For(object loggedObject)
		{
			if (loggedObject != null)
				return For(loggedObject.GetType());
			else
				return For(null);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectType"></param>
		/// <returns></returns>
		public static ILog For(Type objectType)
		{
			if (objectType != null)
				return LogManager.GetLogger(Assembly.GetExecutingAssembly(), objectType.Name);
			else
				return LogManager.GetLogger(Assembly.GetExecutingAssembly(), string.Empty);
		}
	}
}
