#region

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using IO.Swagger.Client;

#endregion

namespace GiteaClient.Core.Data
{
    public class AppConfig
    {
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

        private static string SConfigFileDirectory => @"config\";
        private static string SConfigFileName => @"app.json";
        public static string SConfigFilePath => SConfigFileDirectory + SConfigFileName;

        public bool IsUsingToken { get; set; }
        public string BasePath { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static AppConfig s_GetDefaultConfig()
        {
            return new AppConfig("http://localhost");
        }

        public static async Task<AppConfig> s_GetConfigAsync()
        {
            if (!File.Exists(SConfigFilePath))
            {
                if (!Directory.Exists(SConfigFileDirectory))
                    Directory.CreateDirectory(SConfigFileDirectory);
                await File.WriteAllTextAsync(SConfigFilePath,
                    JsonSerializer.Serialize(s_GetDefaultConfig()));
            }

            return JsonSerializer.Deserialize<AppConfig>(await File.ReadAllTextAsync(SConfigFilePath));
        }

        public static async Task s_SaveConfigAsync(AppConfig appConfig)
        {
            if (!File.Exists(SConfigFilePath))
                if (!Directory.Exists(SConfigFileDirectory))
                    Directory.CreateDirectory(SConfigFileDirectory);
            await File.WriteAllTextAsync(SConfigFilePath, JsonSerializer.Serialize(appConfig));
        }
    }

    public static class Helper
    {
        #region Constructor
        #endregion

        #region Attribute

        public static string SLogTemplate =>
            "New log : {NewLine} [{Timestamp:yyyy-MM-dd HH:mm:ss zzz} {Level: u3}] {NewLine} [Context : {SourceContext}] => {Message: lj} {NewLine} [Properties] ==> {Properties} {NewLine} [Exception] ==> {Exception} End of log";

        #endregion

        #region Accessor

        #endregion

        #region Method

        public static async Task<Configuration> s_GetConfigurationAsync()
        {
            var apiConfig = IO.Swagger.Client.Configuration.Default;
            var appConfig = await AppConfig.s_GetConfigAsync();

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

        public static async Task s_SaveConfigurationAsync(AppConfig appConfig)
        {
            await AppConfig.s_SaveConfigAsync(appConfig);
        }

        #endregion
    }
}