using IO.Swagger.Client;
using MvvmCross;
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

        public bool IsUsingToken { get; set; } = false;
        public string BasePath { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public AppConfig()
        {

        }
        public AppConfig(string basePath)
        {
            BasePath = basePath;
        }
        public AppConfig(string basePath, string token)
        {
            BasePath = basePath;
            Token = token;
        }
        public AppConfig(string basePath, string userName, string password)
        {
            BasePath = basePath;
            UserName = userName;
            Password = password;
        }

        public static AppConfig s_GetDefaultConfig()
        {
            return new AppConfig("http://localhost");
        }

        public async static Task<AppConfig> s_GetConfig()
        {
            if (!File.Exists(s_configFilePath))
            {
                if (!Directory.Exists(s_configFileDirectory))
                    Directory.CreateDirectory(s_configFileDirectory);
                await File.WriteAllTextAsync(s_configFilePath, JsonSerializer.Serialize(s_GetDefaultConfig()));
            }
            return JsonSerializer.Deserialize<AppConfig>(File.ReadAllText(s_configFilePath));
        }

        public async static Task s_SaveConfig(AppConfig appConfig)
        {
            if (!File.Exists(s_configFilePath))
            {
                if (!Directory.Exists(s_configFileDirectory))
                    Directory.CreateDirectory(s_configFileDirectory);
            }
            await File.WriteAllTextAsync(s_configFilePath, JsonSerializer.Serialize(appConfig));
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
        public async static Task<Configuration> s_GetConfiguration()
        {
            var apiConfig = Configuration.Default;
            var appConfig = await AppConfig.s_GetConfig();

            apiConfig.BasePath = appConfig.BasePath;
            if (appConfig.IsUsingToken)
            {
                apiConfig.ApiKey.Remove("token");
                apiConfig.ApiKey.Add("token", appConfig.Token);
            }
            else
            {
                apiConfig.Username = appConfig.UserName;
                apiConfig.Password = appConfig.Password;
            }

            return apiConfig;
        }

        public async static Task s_SaveConfiguration(AppConfig appConfig)
        {
            await AppConfig.s_SaveConfig(appConfig);
        }
        #endregion
    }
}
