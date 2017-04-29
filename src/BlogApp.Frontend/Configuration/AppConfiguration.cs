using System.Configuration;

namespace BlogApp.Frontend.Configuration
{    
    public interface IAppConfiguration
    {
        string TenantId { get; set; }
        string BlogBaseUrl { get; set; }
        string Title { get; set; }
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

        [ConfigurationProperty("title")]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }

        public static IAppConfiguration Config
        {
            get { return ConfigurationManager.GetSection("appConfiguration") as IAppConfiguration; }
        }
    }
}
