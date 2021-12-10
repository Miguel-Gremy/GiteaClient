using IO.Swagger.Api;
using IO.Swagger.Client;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Admin
{
    public class IndexViewModel : ViewModelBase
    {
        #region Attribute
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        public IndexViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }
        #endregion
        #region Command
        public IMvxCommand NavigationCronCommand { get; set; }
        public IMvxCommand NavigationOrgsCommand { get; set; }
        public IMvxCommand NavigationUnadoptedCommand { get; set; }
        public IMvxCommand NavigationUsersCommand { get; set; }
        #endregion
        #region Method
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            NavigationUsersCommand = new MvxAsyncCommand(() => _navigationService.Navigate<Users.IndexViewModel>());
        }
        #endregion
    }
}
