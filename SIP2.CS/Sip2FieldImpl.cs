using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
{
	public class Sip2FieldImpl : FieldImpl
	{
		public Sip2FieldImpl() : base()
		{
			Required = false;
			Identificator = "";
			Version = Sip2Version.V100;
			Length = 0;
		}
		internal bool Required { get; set; }
		internal string Identificator { get; set; }
		internal Sip2Version Version { get; set; }
		internal int Length { get; set; }
		internal bool Verify(ISip2Answers answer)
		{
			return (answer.Version >= Version && ((Value != null && Required) || !Required));
		}
	}
}
