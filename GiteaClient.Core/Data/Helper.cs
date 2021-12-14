using IO.Swagger.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.Data
{
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
            var apiConfig = new Configuration
            {
                BasePath = "https://gitea.gremy.ovh/api/v1",
            };
            apiConfig.ApiKey.Add("token", "e0f5542a6570e3a9b5c188dbcff8f545030725f0");
            return apiConfig;
        }
        #endregion
        #region Override_Method
        #endregion
    }
}
