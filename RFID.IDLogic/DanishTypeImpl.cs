using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic {
    public sealed class DanishTypeImpl : TypeModelImpl<DanishModelImpl>, ITypeModel {
        public DanishTypeImpl(IConfig config, string id) : base(TypeModel.Danish, id) {
            _config = config;
        }
        private IConfig _config { get; set; }
        /// <summary>
        /// Добавление модели к списку
        /// </summary>
        /// <param name="item">модель</param>
        public override void Add(IModel item) {
            Log.For(this).Debug(String.Format("Add Model.id: {0}", item.Id));
            try {
                base.Add(item);
                if((item is DanishModelImpl) && !(item as DanishModelImpl).IsInited) {
                    Externals.InitModel(_id, item.Type);
                }
            } catch(Exception ex) {
                Log.For(this).Error(this, ex);
            }
        }
        public override bool Remove(IModel item) {
            Log.For(this).Debug(String.Format("Remove Model.id: {0}", item.Id));
            try {
                Externals.RemoveModel(_id);
                return true;
            } catch(Exception ex) {
                Log.For(this).Error(this, ex);
                return false;
            }
        }
        /// <summary>
        /// Модель по умолчанию
        /// </summary>
        public new IModel Default {
            get { return DanishModelImpl.Default(_id, _config); }
        }
    }
}
