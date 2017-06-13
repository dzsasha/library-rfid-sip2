using System.Configuration;

namespace Marc.Service
{
	public class ServiceSection : ConfigurationSection
	{
		public static string SectionName = "marc.service";
		public ServiceSection() { }
		[ConfigurationProperty("readers")]
		public Readers Readers
		{
			get { return (Readers)base["readers"]; }
			set { base["readers"] = value; }
		}
	}
}
