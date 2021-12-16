#region

using System.Threading.Tasks;
using GiteaClient.Core.Data;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core.ViewModels.About
{
    public class ApplicationSettingNavigationArgs
    {
        public AppConfig AppConfig { get; set; }
    }

    public class ApplicationSettingsViewModel : MvxViewModel<ApplicationSettingNavigationArgs>
    {
        #region Constructor

        public ApplicationSettingsViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #endregion

        #region Accessor

        public AppConfig AppConfig
        {
            get => _appConfig;
            private set => SetProperty(ref _appConfig, value);
        }

        #endregion

        #region Command

        public IMvxCommand ConfirmSaveConfig { get; private set; }

        #endregion

        #region Method

        private async Task OnConfirmSaveExec(ApplicationSettingNavigationArgs args)
        {
            await AppConfig.s_SaveConfigAsync(args.AppConfig);
            await NavigationService.Close(this);
        }

        #endregion

        #region Override_Method

        public override void Prepare(ApplicationSettingNavigationArgs args)
        {
            AppConfig = args.AppConfig;
            ConfirmSaveConfig = new MvxAsyncCommand(async () => await OnConfirmSaveExec(args));
        }

        #endregion

        #region Attribute

        private IMvxNavigationService NavigationService { get; set; }

        private AppConfig _appConfig;

        #endregion
    }
}