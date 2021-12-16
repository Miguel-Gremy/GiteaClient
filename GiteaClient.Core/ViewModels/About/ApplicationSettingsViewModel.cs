using GiteaClient.Core.Data;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
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
        public AppConfig AppConfig { get; set; }
    }

    public class ApplicationSettingsViewModel : MvxViewModel<ApplicationSettingNavigationArgs>
    {
        #region Attribute
        public ILogger<ApplicationSettingsViewModel> _logger { get; set; }
        public IMvxNavigationService _navigationService { get; set; }

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
        public ApplicationSettingsViewModel(ILogger<ApplicationSettingsViewModel> logger, IMvxNavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
        }
        #endregion
        #region Command
        public IMvxCommand ConfirmSaveConfig { get; set; }
        #endregion
        #region Method
        private async Task OnConfirmSaveExec(ApplicationSettingNavigationArgs args)
        {
            await AppConfig.s_SaveConfig(args.AppConfig);
            await _navigationService.Close(this);
        }
        #endregion
        #region Override_Method
        public override void Prepare(ApplicationSettingNavigationArgs args)
        {
            AppConfig = args.AppConfig;
            ConfirmSaveConfig = new MvxAsyncCommand(async () => await OnConfirmSaveExec(args));
        }
        #endregion
    }
}
