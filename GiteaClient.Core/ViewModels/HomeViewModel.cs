using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        #region Attribute
        protected ILogger<HomeViewModel> _logger { get; set; }
        protected IMvxNavigationService _navigationService { get; set; }
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        public HomeViewModel(IMvxNavigationService navigationService, ILogger<HomeViewModel> logger)
        {
            _navigationService = navigationService;
            _logger = logger;
        }
        #endregion
        #region Command
        public IMvxCommand NavigationAdminUserListCommand { get; set; }
        public IMvxCommand NavigationAdminUserAddCommand { get; set; }
        //public IMvxCommand NavigationIssueCommand { get; set; }
        //public IMvxCommand NavigationMiscellaneousCommand { get; set; }
        //public IMvxCommand NavigationNotificationCommand { get; set; }
        //public IMvxCommand NavigationOrganizationCommand { get; set; }
        //public IMvxCommand NavigationRepositoryCommand { get; set; }
        //public IMvxCommand NavigationSettingsCommand { get; set; }
        //public IMvxCommand NavigationUserCommand { get; set; }
        public IMvxCommand NavigationAboutShowLogCommand { get; set; }
        #endregion
        #region Method
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();

            NavigationAdminUserListCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Admin.Users.ListViewModel>());
            NavigationAdminUserAddCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Admin.Users.AddViewModel>());

            NavigationAboutShowLogCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<About.ShowLogViewModel>());
        }
        #endregion
    }
}
