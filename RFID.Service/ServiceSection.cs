using System.Configuration;

namespace InformSystema.RFID.Service
{
	public class ServiceSection : ConfigurationSection
	{
		public static string SectionName = "rfid.service";
		public ServiceSection() { }
		[ConfigurationProperty("readers")]
		public Readers Readers
		{
			get { return (Readers)base["readers"]; }
			set { base["readers"] = value; }
		}
	}
}
