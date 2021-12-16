#region

using GiteaClient.Core.Data;
using GiteaClient.Core.ViewModels.About;
using GiteaClient.Core.ViewModels.Admin.Users;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        #region Constructor

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #endregion

        #region Override_Method

        public override void Prepare()
        {
            base.Prepare();

            NavigationAdminUserListCommand =
                new MvxAsyncCommand(() => NavigationService.Navigate<ListViewModel>());
            NavigationAdminUserAddCommand =
                new MvxAsyncCommand(() => NavigationService.Navigate<AddViewModel>());

            NavigationAboutApplicationSettingsCommand =
                new MvxAsyncCommand(async () => await NavigationService
                    .Navigate<ApplicationSettingsViewModel, ApplicationSettingNavigationArgs>(
                        new ApplicationSettingNavigationArgs
                            { AppConfig = await AppConfig.s_GetConfigAsync() }));
            NavigationAboutShowLogCommand =
                new MvxAsyncCommand(() => NavigationService.Navigate<ShowLogViewModel>());
        }

        #endregion

        #region Attribute

        private IMvxNavigationService NavigationService { get; set; }

        #endregion

        #region Accessor

        #endregion

        #region Command

        public IMvxCommand NavigationAdminUserListCommand { get; private set; }
        public IMvxCommand NavigationAdminUserAddCommand { get; private set; }

        public IMvxCommand NavigationAboutApplicationSettingsCommand { get; private set; }
        public IMvxCommand NavigationAboutShowLogCommand { get; private set; }

        #endregion

        #region Method

        #endregion
    }
}