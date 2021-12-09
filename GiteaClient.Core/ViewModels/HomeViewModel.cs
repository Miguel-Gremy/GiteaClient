using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Attribute
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        public HomeViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }
        #endregion
        #region Command
        public IMvxCommand NavigationAdminCommand { get; set; }
        public IMvxCommand NavigationIssueCommand { get; set; }
        public IMvxCommand NavigationMiscellaneousCommand { get; set; }
        public IMvxCommand NavigationNotificationCommand { get; set; }
        public IMvxCommand NavigationOrganizationCommand { get; set; }
        public IMvxCommand NavigationRepositoryCommand { get; set; }
        public IMvxCommand NavigationSettingsCommand { get; set; }
        public IMvxCommand NavigationUserCommand { get; set; }
        #endregion
        #region Method
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();

            NavigationAdminCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Admin.IndexViewModel>());
            NavigationIssueCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Issue.IndexViewModel>());
            NavigationMiscellaneousCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Miscellaneous.IndexViewModel>());
            NavigationNotificationCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Notification.IndexViewModel>());
            NavigationOrganizationCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Organization.IndexViewModel>());
            NavigationRepositoryCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Repository.IndexViewModel>());
            NavigationSettingsCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<Settings.IndexViewModel>());
            NavigationUserCommand =
                new MvxAsyncCommand(() => _navigationService.Navigate<User.IndexViewModel>());
        }
        #endregion
    }
}
