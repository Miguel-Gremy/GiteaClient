using IO.Swagger.Api;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class IndexViewModel : ViewModelBase
    {
        #region Attribute
        public IAdminApi _adminApi { get; set; }
        private ObservableCollection<IO.Swagger.Model.User> _users;
        private IO.Swagger.Model.User _selectedUser;
        #endregion
        #region Accessor
        public IO.Swagger.Model.User SelectedUser
        {
            get { return _selectedUser; }
            set => SetProperty(ref _selectedUser, value);
        }
        public ObservableCollection<IO.Swagger.Model.User> Users
        {
            get { return _users; }
            set => SetProperty(ref _users, value);
        }
        #endregion
        #region Constructor
        public IndexViewModel(IMvxNavigationService navigationService, IAdminApi adminApi) : base(navigationService)
        {
            _adminApi = adminApi;
        }
        #endregion
        #region Command
        public IMvxCommand NavigationAddCommand { get; set; }
        public IMvxCommand RefreshUsersCommand { get; set; }
        #endregion
        #region Method
        private async Task UpdateUsersAsync()
        {
            Users = ListToObservable(await Task.Run(() => _adminApi.AdminGetAllUsers()));
        }
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            NavigationAddCommand = new MvxCommand(() => _navigationService.Navigate<AddViewModel>());
            RefreshUsersCommand = new MvxAsyncCommand(async () => await UpdateUsersAsync());
        }
        public async override Task Initialize()
        {
            await base.Initialize();
            await UpdateUsersAsync();
        }
        public async override void ViewAppearing()
        {
            base.ViewAppearing();
            await UpdateUsersAsync();
        }
        #endregion
    }
}
