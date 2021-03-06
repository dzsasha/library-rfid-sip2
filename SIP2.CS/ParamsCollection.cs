﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using IS.Interface;
using IS.Interface.SIP2;

namespace IS.SIP2.CS {
    public class ParamsCollection : ConfigurationElementCollection, ISip2Config {
        public ParamsCollection() {
            Version = Sip2Version.V200;
        }
        List<IField> _result = new List<IField>();
        #region ConfigurationElementCollection
        protected override ConfigurationElement CreateNewElement() {
            return new ParamElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((ParamElement)element).Name;
        }
        #endregion

        public void Add(ParamElement element) {
            BaseAdd(element);
        }
        public void Clear() {
            BaseClear();
        }
        public int IndexOf(ParamElement element) {
            return BaseIndexOf(element);
        }
        public void Remove(ParamElement element) {
            if(BaseIndexOf(element) >= 0) {
                BaseRemove(element.Name);
            }
        }
        public void RemoveAt(int index) {
            BaseRemoveAt(index);
        }

        public void AddParam(IField field) {
            _result.Add(field);
        }

        public ParamElement this[int index] {
            get { return (ParamElement)BaseGet(index); }
            set {
                if(BaseGet(index) != null) {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        [ConfigurationProperty("object", IsKey = true, IsRequired = true)]
        public string Name {
            get { return (string)base["object"]; }
            set { base["object"] = value; }
        }
        [ConfigurationProperty("port", DefaultValue = 6001)]
        public int Port {
            get { return Convert.ToInt16(base["port"]); }
            set { base["port"] = value; }
        }
        [ConfigurationProperty("proto", DefaultValue = ProtocolType.Tcp)]
        public ProtocolType Proto {
            get { return (ProtocolType)base["proto"]; }
            set { base["proto"] = value; }
        }
        [ConfigurationProperty("address", DefaultValue = "0.0.0.0")]
        public string Address {
            get { return (string)base["address"]; }
            set { base["address"] = value; }
        }
        [ConfigurationProperty("debug", DefaultValue = true)]
        public Boolean isDebug {
            get { return Convert.ToBoolean(base["debug"]); }
            set { base["debug"] = value; }
        }
        [ConfigurationProperty("max", DefaultValue = 5)]
        public int MaxConnection {
            get { return (int)base["max"]; }
            set { base["max"] = value; }
        }
        [ConfigurationProperty("separator", DefaultValue = '|')]
        public Char Separator {
            get { return Convert.ToChar(base["separator"]); }
            set { base["separator"] = value; }
        }
        [ConfigurationProperty("encoding", DefaultValue = "65001")]
        private Int32 _encoding {
            get { return Convert.ToInt32(base["encoding"]); }
            set { base["encoding"] = value; }
        }
        public Encoding encoding => Encoding.GetEncoding(_encoding);
        public Sip2Version Version { get; set; }
        public IField[] param {
            get {
                List<IField> result = new List<IField>();
                result.AddRange(this.Cast<IField>().ToArray());
                result.AddRange(_result);
                return result.ToArray();
            }
        }
    }
}
