﻿using System;
using System.Runtime.Serialization;

namespace IS.Interface.RFID {
	/// <summary>
	/// Класс имплементации интерфейса IItem
	/// </summary>
	[DataContract(Name = "item", Namespace = "http://informsystema.com/marc/service/")]
	[Serializable]
	public class ItemImpl : IItem {
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		/// <param name="id">Идентификатор метки</param>
		public ItemImpl(string id) {
			Id = id;
		}

		#region implementation IItem
		/// <summary>
		/// Идентификатор метки
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; private set; }

		#endregion

		/// <summary>
		/// Определение оригинальности
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj) {
			return (obj is ItemImpl) ? Id.Equals((obj as ItemImpl).Id) : false;
		}
	}
}
