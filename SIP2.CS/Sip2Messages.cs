﻿using System.Collections.Generic;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
{
	public class Sip2Messages
	{
		private static readonly Dictionary<Sip2Request, List<Sip2FieldImpl>> RequestDictionary = new Dictionary<Sip2Request, List<Sip2FieldImpl>>
		{
			{
				Sip2Request.scPatronStatus, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "language", Description = "язык", Type = TypeField.String, Length = 3, Required = true},
					new Sip2FieldImpl {Name = "transaction date ", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Required = true, Identificator = "AC"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Required = true, Identificator = "AD"},
				}
			},
			{
				Sip2Request.scCheckout, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "SC renewal policy", Description = "политика возобновления системы SC", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "no block", Description = "отсутствие блокировки", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "nb due date", Description = "дата возврата nb", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Required = true, Identificator = "AC"},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee acknowledged", Description = "подтверждение взноса", Type = TypeField.Boolean, Identificator = "BO", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "cancel", Description = "отмена", Type = TypeField.Boolean, Identificator = "BI", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scCheckin, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "no block", Description = "отсутствие блокировки", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "return date", Description = "дата возврата", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "current location", Description = "текущее месторасположение", Type = TypeField.String, Required = true, Identificator = "AP"},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Required = true, Identificator = "AC"},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "cancel", Description = "отмена", Type = TypeField.Boolean, Identificator = "BI", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scBlockPatron, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "card retained", Description = "удержание карточки", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "blocked card msg", Description = "сообщение о блокировке карточки", Type = TypeField.String, Required = true, Identificator = "AL"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Required = true, Identificator = "AC"},
				}
			},
			{
				Sip2Request.scSCStatus, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "status code", Description = "код состояния", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "max print width", Description = "макс. печатная ширина", Type = TypeField.String, Required = true, Length = 3},
					new Sip2FieldImpl {Name = "protocol version", Description = "версия протокола", Type = TypeField.String, Required = true, Length = 4},
				}
			},
			{
				Sip2Request.scLogin, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "UID algorithm", Description = "алгоритм идент. польз.", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "PWD algorithm", Description = "алгоритм парол.", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "login user id", Description = "идентификатор пользователя для входа", Type = TypeField.String, Required = true, Identificator = "CN"},
					new Sip2FieldImpl {Name = "login password", Description = "пароль для входа", Type = TypeField.String, Required = true, Identificator = "CO"},
					new Sip2FieldImpl {Name = "location code", Description = "код места расположения", Type = TypeField.String, Required = true, Identificator = "CP"},
				}
			},
			{
				Sip2Request.scPatronInformation, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "language", Description = "язык", Type = TypeField.String, Length = 3, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "summary", Description = "сводка", Type = TypeField.String, Required = true, Length = 10, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
					new Sip2FieldImpl {Name = "start item", Description = "начальная единица", Type = TypeField.String, Identificator = "BP", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "end item", Description = "конечная единица", Type = TypeField.String, Identificator = "BQ", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scEndPatronSession, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
				}
			},
			{
				Sip2Request.scFeePaid, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "fee type", Description = "тип взноса", Type = TypeField.String, Required = true, Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "payment type", Description = "тип платежа", Type = TypeField.String, Required = true, Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "currency type", Description = "валюта", Type = TypeField.String, Required = true, Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee amount", Description = "сумма взноса", Type = TypeField.String, Required = true, Identificator = "BV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
					new Sip2FieldImpl {Name = "fee identifier", Description = "идентификатор взноса", Type = TypeField.String, Identificator = "CG", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction id", Description = "идентификатор операции", Type = TypeField.String, Identificator = "BK", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scItemInformation, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
				}
			},
			{
				Sip2Request.scItemStatusUpdate, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Required = true, Identificator = "CH", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scPatronEnable, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
				}
			},
			{
				Sip2Request.scHold, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "hold mode", Description = "режим удержания", Type = TypeField.Char, Required = true, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "expiration date", Description = "срок действия", Type = TypeField.DateTime, Identificator = "BW", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "pickup location", Description = "месторасположение раскладки", Type = TypeField.String, Identificator = "BS", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "hold type", Description = "тип удержания", Type = TypeField.Char, Identificator = "BY", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "fee acknowledged", Description = "подтверждение взноса", Type = TypeField.Boolean, Identificator = "BO", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scRenew, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "third party allowed", Description = "разрешение на присутствие третьей стороны", Type = TypeField.Boolean, Required = true, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "no block", Description = "отсутствие блокировки", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "nb due date", Description = "дата возврата nb", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee acknowledged", Description = "подтверждение взноса", Type = TypeField.Boolean, Identificator = "BO", Version = Sip2Version.V200},
				}
			},
			{
				Sip2Request.scRenewAll, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "patron password", Description = "пароль абонента", Type = TypeField.String, Identificator = "AD"},
					new Sip2FieldImpl {Name = "terminal password", Description = "окончательный пароль", Type = TypeField.String, Identificator = "AC"},
					new Sip2FieldImpl {Name = "fee acknowledged", Description = "подтверждение взноса", Type = TypeField.Boolean, Identificator = "BO", Version = Sip2Version.V200},
				}
			}
		};

		private static readonly Dictionary<Sip2Response, List<Sip2FieldImpl>> ResponseDictionary = new Dictionary<Sip2Response, List<Sip2FieldImpl>>
		{
			{
				Sip2Response.acPatronStatus, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "patron status", Description = "состояние абонента", Type = TypeField.String, Required = true, Length = 14},
					new Sip2FieldImpl {Name = "language", Description = "язык", Type = TypeField.String, Required = true, Length = 3},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "personal name", Description = "Ф.И.О.", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "valid patron", Description = "действительный абонент", Type = TypeField.Boolean, Identificator = "BL", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "valid patron password", Description = "действительный пароль абонента", Type = TypeField.Boolean, Identificator = "CQ", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "currency type", Description = "валюта", Type = TypeField.String, Identificator = "BH", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee amount", Description = "сумма взноса", Type = TypeField.String, Identificator = "BV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acCheckout, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "ok", Description = "разрешено", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "renewal ok", Description = "возобновление разрешено", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "magnetic media", Description = "магнитный носитель", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "desensitize", Description = "размагничивание", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Required = true, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "due date", Description = "дата возврата", Type = TypeField.String, Required = true, Identificator = "AH"},
					new Sip2FieldImpl {Name = "fee type", Description = "тип взноса", Type = TypeField.String, Identificator = "BT", Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "security inhibit", Description = "магнитный носитель", Type = TypeField.Boolean, Identificator = "CI", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "currency type", Description = "валюта", Type = TypeField.String, Identificator = "BH", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee amount", Description = "сумма взноса", Type = TypeField.String, Identificator = "BV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "media type", Description = "тип носителя", Type = TypeField.String, Identificator = "CK", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction id", Description = "идентификатор операции", Type = TypeField.String, Identificator = "BK", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acCheckin, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "ok", Description = "разрешено", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "resensitize", Description = "повторное намагничивание", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "magnetic media", Description = "магнитный носитель", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "alert", Description = "сигнализация", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "permanent location", Description = "постоянное месторасположение", Type = TypeField.String, Required = true, Identificator = "AQ"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "sort bin", Description = "сортировочная корзина", Type = TypeField.String, Identificator = "CL", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Identificator = "AA", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "media type", Description = "тип носителя", Type = TypeField.String, Identificator = "CK", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acACSStatus, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "on-line status", Description = "интерактивное состояние", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "checkin ok", Description = "возврат разрешен", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "checkout ok", Description = "получение разрешено", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "ACS renewal policy", Description = "политика возобновления ААС", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "status update ok", Description = "обновление состояния разрешено", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "off-line ok", Description = "переход в автономный режим разрешен", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "timeout period", Description = "время ожидания", Type = TypeField.String,  Required = true, Length = 3},
					new Sip2FieldImpl {Name = "retries allowed", Description = "разрешенных попыток", Type = TypeField.String, Required = true, Length = 3},
					new Sip2FieldImpl {Name = "date / time sync", Description = "дата/ время синхр", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "protocol version", Description = "время ожидания", Type = TypeField.String, Required = true, Length = 4},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "library name", Description = "название библиотеки", Type = TypeField.String, Identificator = "AM"},
					new Sip2FieldImpl {Name = "supported messages", Description = "поддерживаемые сообщения", Type = TypeField.String, Required = true, Identificator = "BX", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "terminal location", Description = "окончательное месторасположение", Type = TypeField.String, Identificator = "AN"},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acLogin, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "ok", Description = "разрешено", Type = TypeField.Char, Required = true},
				}
			},
			{
				Sip2Response.acPatronInformation, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "patron status", Description = "состояние абонента", Type = TypeField.String, Required = true, Length = 14},
					new Sip2FieldImpl {Name = "language", Description = "язык", Type = TypeField.String, Required = true, Length = 3},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "hold items count", Description = "число удерживаемых единиц", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "overdue items count", Description = "число просроченных единиц", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "charged items count", Description = "число оплаченных единиц", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fine items count", Description = "число проштрафленных единиц", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "recall items count", Description = "число отозванных единиц", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "unavailable holds count", Description = "число недоступных удержаний", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "personal name", Description = "Ф.И.О.", Type = TypeField.String, Required = true, Identificator = "AE"},
					new Sip2FieldImpl {Name = "hold items limit", Description = "ограничение удерживаемых единиц", Type = TypeField.String, Identificator = "BZ",Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "overdue items limit", Description = "ограничение просроченных единиц", Type = TypeField.String, Identificator = "CA",Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "charged items limit", Description = "ограничение оплачиваемых единиц", Type = TypeField.String, Identificator = "CB",Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "valid patron", Description = "действительный абонент", Type = TypeField.Boolean, Identificator = "BL", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "valid patron password", Description = "действительный пароль абонента", Type = TypeField.Boolean, Identificator = "CQ", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "currency type", Description = "валюта", Type = TypeField.String, Identificator = "BH", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee amount", Description = "сумма взноса", Type = TypeField.String, Identificator = "BV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee limit", Description = "ограничение взноса", Type = TypeField.String, Identificator = "CC", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "hold items", Description = "удерживаемых единиц", Type = TypeField.String, Identificator = "AS", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "overdue items", Description = "просроченных единиц", Type = TypeField.String, Identificator = "AT", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "charged items", Description = "оплаченных единиц", Type = TypeField.String, Identificator = "AU", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fine items", Description = "проштрафленных единиц", Type = TypeField.String, Identificator = "AV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "recall items", Description = "отозванных единиц", Type = TypeField.String, Identificator = "BU", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "unavailable hold items", Description = "недоступных удерживаемых единиц", Type = TypeField.String, Identificator = "CD", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "home address", Description = "адрес", Type = TypeField.String, Identificator = "BD", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "e-mail address", Description = "адрес электронной почты", Type = TypeField.String, Identificator = "BE", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "home phone number", Description = "домашний телефон", Type = TypeField.String, Identificator = "BF", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acEndSession, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "end session", Description = "завершение сеанса", Type = TypeField.Boolean, Required = true, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acFeePaid, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "payment accepted", Description = "прием платежа", Type = TypeField.Boolean, Required = true, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "transaction id", Description = "идентификатор операции", Type = TypeField.String, Identificator = "BK", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acItemInformation, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "circulation status", Description = "состояние выдачи на абонемент", Type = TypeField.String, Required = true, Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "security marker", Description = "маркер безопасности", Type = TypeField.String, Required = true, Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee type", Description = "тип взноса", Type = TypeField.String, Required = true, Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "hold queue length", Description = "длина очереди удержания", Type = TypeField.String, Identificator = "CF", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "due date", Description = "дата операции", Type = TypeField.DateTime, Identificator = "AH"},
					new Sip2FieldImpl {Name = "recall date", Description = "дата отзыва", Type = TypeField.DateTime, Identificator = "CJ", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "hold pickup date", Description = "дата отзыва", Type = TypeField.DateTime, Identificator = "CM", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Required = true, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "owner", Description = "владелец", Type = TypeField.String, Identificator = "BG", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "currency type", Description = "валюта", Type = TypeField.String, Identificator = "BH", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee amount", Description = "сумма взноса", Type = TypeField.String, Identificator = "BV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "media type", Description = "тип носителя", Type = TypeField.String, Identificator = "CK", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "permanent location", Description = "постоянное месторасположение", Type = TypeField.String, Identificator = "AQ", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "current location", Description = "текущее месторасположение", Type = TypeField.String, Identificator = "AP", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acItemStatusUpdate, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "item properties ok", Description = "свойства единицы разрешены", Type = TypeField.Char, Required = true, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acPatronEnable, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "patron status", Description = "состояние абонента", Type = TypeField.String, Required = true, Length = 14},
					new Sip2FieldImpl {Name = "language", Description = "язык", Type = TypeField.String, Required = true, Length = 3},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "personal name", Description = "Ф.И.О.", Type = TypeField.String, Required = true, Identificator = "AE"},
					new Sip2FieldImpl {Name = "valid patron", Description = "действительный абонент", Type = TypeField.Boolean, Identificator = "BL", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "valid patron password", Description = "действительный пароль абонента", Type = TypeField.Boolean, Identificator = "CQ", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acHold, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "ok", Description = "разрешено", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "available", Description = "доступно", Type = TypeField.Boolean, Required = true, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "expiration date", Description = "срок действия", Type = TypeField.DateTime, Identificator = "BW", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "queue position", Description = "место в очереди", Type = TypeField.String, Identificator = "BR", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "pickup location", Description = "месторасположение раскладки", Type = TypeField.String, Identificator = "BS", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acRenew, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "ok", Description = "разрешено", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "renewal ok", Description = "возобновление разрешено", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "magnetic media", Description = "магнитный носитель", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "desensitize", Description = "размагничивание", Type = TypeField.Boolean, Required = true},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "patron identifier", Description = "идентификатор абонента", Type = TypeField.String, Required = true, Identificator = "AA"},
					new Sip2FieldImpl {Name = "item identifier", Description = "идентификатор единицы", Type = TypeField.String, Required = true, Identificator = "AB"},
					new Sip2FieldImpl {Name = "title identifier", Description = "идентификатор названия", Type = TypeField.String, Required = true, Identificator = "AJ"},
					new Sip2FieldImpl {Name = "due date", Description = "дата возврата", Type = TypeField.String, Required = true, Identificator = "AH"},
					new Sip2FieldImpl {Name = "fee type", Description = "тип взноса", Type = TypeField.String, Identificator = "BT", Length = 2, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "security inhibit", Description = "магнитный носитель", Type = TypeField.Boolean, Identificator = "CI", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "currency type", Description = "валюта", Type = TypeField.String, Identificator = "BH", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "fee amount", Description = "сумма взноса", Type = TypeField.String, Identificator = "BV", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "media type", Description = "тип носителя", Type = TypeField.String, Identificator = "CK", Length = 3, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "item properties", Description = "свойства единицы", Type = TypeField.String, Identificator = "CH", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction id", Description = "идентификатор операции", Type = TypeField.String, Identificator = "BK", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			},
			{
				Sip2Response.acRenewAll, new List<Sip2FieldImpl>
				{
					new Sip2FieldImpl {Name = "ok", Description = "разрешено", Type = TypeField.Char, Required = true},
					new Sip2FieldImpl {Name = "renewed count", Description = "число возобновленных", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "unrenewed count", Description = "число невозобновленных", Type = TypeField.String, Required = true, Length = 4, Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "transaction date", Description = "дата операции", Type = TypeField.DateTime, Required = true},
					new Sip2FieldImpl {Name = "institution id", Description = "идентификатор учреждения", Type = TypeField.String, Required = true, Identificator = "AO"},
					new Sip2FieldImpl {Name = "renewed items", Description = "возобновленных единиц", Type = TypeField.String, Identificator = "BM", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "unrenewed items", Description = "невозобновленных единиц", Type = TypeField.String, Identificator = "BN", Version = Sip2Version.V200},
					new Sip2FieldImpl {Name = "screen message", Description = "экранное сообщение", Type = TypeField.String, Identificator = "AF"},
					new Sip2FieldImpl {Name = "print line", Description = "печатная строка", Type = TypeField.String, Identificator = "AG"},
				}
			}
		};
	}
}
