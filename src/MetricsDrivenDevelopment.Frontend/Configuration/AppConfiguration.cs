using System.Configuration;

namespace MetricsDrivenDevelopment.Frontend.Configuration
{    
    public interface IAppConfiguration
    {
        string TenantId { get; set; }
        string BlogBaseUrl { get; set; }
    }

    public class AppConfiguration: ConfigurationSection, IAppConfiguration
    {

        [ConfigurationProperty("tenantId")]
        public string TenantId
        {
            get { return (string)this["tenantId"]; }
            set { this["tenantId"] = value; }
        }

        [ConfigurationProperty("blogBaseUrl")]
        public string BlogBaseUrl
        {
            get { return (string)this["blogBaseUrl"]; }
            set { this["blogBaseUrl"] = value; }
        }
        
        public static IAppConfiguration Config
        {
            get { return ConfigurationManager.GetSection("appConfiguration") as IAppConfiguration; }
        }
    }
}
