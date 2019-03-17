using System;
using System.Configuration;

namespace IS.SIP2.CS {
    public class ServiceSection : ConfigurationSection {
        public static string SectionName = "sip2.service";

        public static ServiceSection GetConfig => (ServiceSection)ConfigurationManager.GetSection(SectionName);

        [ConfigurationProperty("service", IsRequired = true)]
        public ParamsCollection Answers => (ParamsCollection)base["service"];
    }

}
