using IO.Swagger.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GiteaClient.Core.Data
{
    public class AppConfig
    {
        private static string s_configFileDirectory => @"config\";
        private static string s_configFileName => @"app.json";
        public static string s_configFilePath => s_configFileDirectory + s_configFileName;

        public string BasePath { get; set; } = string.Empty;
        public IDictionary<string, string> ApiKeys { get; set; } = new Dictionary<string, string>();
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public AppConfig()
        {

        }
        public AppConfig(string basePath)
        {

        }
        public AppConfig(string basePath, IDictionary<string, string> apiKeys)
        {

        }
        public AppConfig(string basePath, string userName, string password)
        {

        }

        public static AppConfig s_GetDefaultConfig()
        {
            return new AppConfig("http://localhost");
        }

        public static AppConfig s_GetConfig()
        {
            if (!File.Exists(s_configFilePath))
            {
                if (!Directory.Exists(s_configFileDirectory))
                    Directory.CreateDirectory(s_configFileDirectory);
                File.WriteAllText(s_configFilePath, JsonSerializer.Serialize(s_GetDefaultConfig()));
            }
            return JsonSerializer.Deserialize<AppConfig>(File.ReadAllText(s_configFilePath));
        }
    }

    public class Helper
    {
        #region Attribute
        public static string s_LogTemplate =>
    "{Timestamp:yyyy-MM-dd HH:mm:ss zzz} [{Level: u3}] [Context : {SourceContext}] => {Message: lj} {Exception} Properties ==> {Properties} {NewLine}{NewLine}";
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        private Helper()
        {

        }
        #endregion
        #region Method
        public static Configuration s_GetConfiguration()
        {
            var apiConfig = Configuration.Default;
            var appConfig = AppConfig.s_GetConfig();

            apiConfig.BasePath = appConfig.BasePath;
            apiConfig.ApiKey = appConfig.ApiKeys;
            apiConfig.Username = appConfig.UserName;
            apiConfig.Password = appConfig.Password;

            return apiConfig;
        }
        //public static Configuration s_GetConfiguration()
        //{
        //    var apiConfig = new Configuration
        //    {
        //        BasePath = "https://gitea.gremy.ovh/api/v1",
        //    };
        //    apiConfig.ApiKey.Add("token", "e0f5542a6570e3a9b5c188dbcff8f545030725f0");
        //    return apiConfig;
        //}
        #endregion
    }
}
