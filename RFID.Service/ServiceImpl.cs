﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Web;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.Service
{
//	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
	[ServiceBehavior(Name = "Service", Namespace = "http://informsystema.com/marc/service/", AddressFilterMode = AddressFilterMode.Any, InstanceContextMode = InstanceContextMode.Single)]
	public partial class ServiceImpl : IDisposable
	{
		/// <summary>
		/// Список реадеров
		/// </summary>
		private readonly List<ReaderImpl> _readers = new List<ReaderImpl>();
		private List<IItem> _items = new List<IItem>();
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ServiceImpl()
		{
			foreach (ReaderImpl reader in Readers.Cast<ReaderImpl>().Where(reader => reader.InitReader(reader.Params)))
			{
				_readers.Add(reader);
				reader.OnError += new ErrorEventHandler(reader_OnError);
				Log.For(this).Debug(String.Format("ServiceImpl:ServiceImpl - Adding reader {0}", reader.GetReaderType()));
			}
		}

		void reader_OnError(object sender, ErrorEventArgs error)
		{
			Log.For(sender).Error(error.GetException().Message);
			throw new WebFaultException<String>(String.Format("{0} - {1}", "OnError", error.GetException().Message), HttpStatusCode.InternalServerError);
		}
		/// <summary>
		/// Список реадеров в конфигурации
		/// </summary>
		public static Readers Readers
		{
			get
			{
				try
				{
					ServiceSection section = (ServiceSection)ConfigurationManager.GetSection(ServiceSection.SectionName);
					return (section != null) ? section.Readers : null;
				}
				catch (Exception ex)
				{
					Log.For(null).Error(String.Format("ServiceImpl:reader_OnError - {0}", ex.Message));
					return null;
				}
			}
		}

		private IItem GetItem(String item)
		{
			return (from reader in _readers from i in _items where i.Id == item select i).FirstOrDefault();
		}

		/// <summary>
		/// Закрыть открытые реадеры
		/// </summary>
		public void CloseReaders()
		{
			foreach (ReaderImpl reader in _readers)
			{
				reader.CloseReader();
				reader.OnError -= reader_OnError;

			}
		}
		#region IDisposable
		public void Dispose()
		{
			CloseReaders();
		}
		#endregion
	}
}
