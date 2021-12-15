using GiteaClient.Core.Data;
using Microsoft.Extensions.Logging;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.About
{
    public class ApplicationSettingNavigationArgs
    {
        public AppConfig AppCnfig { get; set; }
    }

    public class ApplicationSettingsViewModel : MvxViewModel<ApplicationSettingNavigationArgs>
    {
        #region Attribute
        public ILogger<ApplicationSettingsViewModel> _logger { get; set; }

        private AppConfig _appConfig;
        #endregion
        #region Accessor
        public AppConfig AppConfig
        {
            get { return _appConfig; }
            set => SetProperty(ref _appConfig, value);
        }
        #endregion
        #region Constructor
        public ApplicationSettingsViewModel(ILogger<ApplicationSettingsViewModel> logger)
        {
            _logger = logger;
        }
        #endregion
        #region Command
        #endregion
        #region Method
        #endregion
        #region Override_Method
        public override void Prepare(ApplicationSettingNavigationArgs args)
        {
            AppConfig = args.AppCnfig;
        }
        #endregion
    }
}
