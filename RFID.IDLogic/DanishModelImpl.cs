﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using IS.Interface;
using IS.Interface.RFID;
using System.IO;

namespace IS.RFID.IDLogic {
	public sealed class DanishModelImpl : ModelImpl, IModelEx {
		public DanishModelImpl() : base(TypeModel.Danish) {
			IsInited = true;
			_fields.Add(new FieldImpl() { Name = "PartsinItem", Type = TypeField.String, Value = "1" });
			_fields.Add(new FieldImpl() { Name = "PartNumber", Type = TypeField.String, Value = "1" });
			_fields.Add(new FieldImpl() { Name = "PrimaryItemId", Type = TypeField.String, Value = "" });
			_fields.Add(new FieldImpl() { Name = "CountryLibrary", Type = TypeField.String, Value = "" });
			_fields.Add(new FieldImpl() { Name = "ISIL", Type = TypeField.String, Value = "" });
		}

		internal IField GetField(string name) {
			return _fields.FirstOrDefault(field => field.Name.Equals(name));
		}

		internal static DanishModelImpl Default(string id, IConfig config) {
			DanishModelImpl pRet = null;
			try {
				pRet = new DanishModelImpl() { Id = id, Type = TypeItem.Item, IsInited = false };
				(pRet as ModelImpl).Id = id;
				foreach(IField field in config.Fields) {
					switch(field.Name) {
						case "Country":
							pRet.SCountryLibrary = field.Value.ToString();
							break;
						case "ISIL":
							pRet.SIsil = field.Value.ToString();
							break;
					}
				}
			} catch(Exception ex) {
				Log.For(pRet).Error(pRet, ex);
			}
			return pRet;
		}

		/// <summary>
		/// Получение значения по типу метки
		/// </summary>
		/// <param name="type">тип метки</param>
		/// <returns>значение типа метки</returns>
		internal static string TypeToString(TypeItem type) {
			switch(type) {
				case TypeItem.Item:
					return "1";
				case TypeItem.Person:
					return "8";
				default:
					return "0";
			}
		}
		/// <summary>
		/// Получение типа метки по значению
		/// </summary>
		/// <param name="typeUsage">значение метки</param>
		/// <returns>тип метки</returns>
		internal static TypeItem StringToType(string typeUsage) {
			switch(typeUsage) {
				case "1":
					return TypeItem.Item;
				case "8":
					return TypeItem.Person;
				default:
					return TypeItem.Unknown;
			}
		}

		#region implementation interface IModelEx
		public new string Id {
			get { return GetField("PrimaryItemId").Value.ToString(); }
			set { GetField("PrimaryItemId").Value = value; }
		}
		public override void Write() {
			Externals.WriteModel((this as ModelImpl).Id, this);
		}
		#endregion

		public override ModelImpl[] Read(string id) {
			(this as ModelImpl).Id = id;
			return (new List<ModelImpl> { Externals.ReadModel(id, this) }).ToArray();
		}


		#region implementation interface IModel
		private readonly List<IField> _fields = new List<IField>();
		public IField[] Fields => _fields.ToArray();

		#endregion

		#region For external
		internal string STypeUsage {
			get { return TypeToString(Type); }
			set { Type = StringToType(value); }
		}

		internal string SPartsinItem {
			get { return GetField("PartsinItem").Value.ToString(); }
			set { GetField("PartsinItem").Value = value; }
		}

		internal string SPartNumber {
			get { return GetField("PartNumber").Value.ToString(); }
			set { GetField("PartNumber").Value = value; }
		}

		internal string SCountryLibrary {
			get { return GetField("CountryLibrary").Value.ToString(); }
			set { GetField("CountryLibrary").Value = value; }
		}
		internal string SIsil {
			get { return GetField("ISIL").Value.ToString(); }
			set { GetField("ISIL").Value = value; }
		}
		internal Boolean IsInited { get; set; }

		#endregion

		public override string ToString() {
			return String.Format("{0};{1};{2};{3};{4};{5}", TypeToString(Type), SPartsinItem, SPartNumber, Id, SCountryLibrary, SIsil);
		}
	}
}
