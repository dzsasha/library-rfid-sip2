using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic
{
	public sealed class DanishTypeImpl : TypeModelImpl<DanishModelImpl>, ITypeModel
	{
		public DanishTypeImpl(string id, IEnumerable<IField> param) : base(TypeModel.Danish, id)
		{
			_param = param;
		}
		/// <summary>
		/// Добавление модели к списку
		/// </summary>
		/// <param name="item">модель</param>
		public override void Add(IModel item)
		{
			if (Count == 0)
			{
				Log.For(this).Debug(String.Format("Model.id: {0}", item.Id));
				base.Add(item);
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
