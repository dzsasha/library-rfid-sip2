using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic
{
	public sealed class DanishTypeImpl : TypeModelImpl<DanishModelImpl>, ITypeModel
	{
		public DanishTypeImpl(string id, string dm, IEnumerable<IField> param) : base(TypeModel.Danish, id, false)
		{
			_param = param;
            if (!String.IsNullOrEmpty(dm)) Add(new DanishModelImpl(id, dm));
		}
		/// <summary>
		/// Добавление модели к списку
		/// </summary>
		/// <param name="item">модель</param>
		public override void Add(IModel item)
		{
			Log.For(this).Debug(String.Format("Model.id: {0}", item.Id));
			base.Add(item);
			if ((item is DanishModelImpl) && !(item as DanishModelImpl).IsInited)
			{
                Externals.InitModel(_id, item.Type);
			}
		}
		/// <summary>
		/// Модель по умолчанию
		/// </summary>
		public new IModel Default
		{
			get { return DanishModelImpl.Default(_id, _param); }
		}

		private readonly IEnumerable<IField> _param = null;
	}
}
