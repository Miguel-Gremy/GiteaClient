using GiteaClient.Core.Assets;
using IO.Swagger.Api;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class ListViewModel : MvxViewModel
    {
        #region Attribute
        protected ILogger<ListViewModel> _logger { get; set; }
        protected IMvxNavigationService _navigationService { get; set; }

        private IAdminApi _adminApi { get; set; }
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
        public ListViewModel(IMvxNavigationService navigationService, ILogger<ListViewModel> logger, IAdminApi adminApi)
        {
            _navigationService = navigationService;
            _logger = logger;
            _adminApi = adminApi;
        }
        #endregion
        #region Command
        public IMvxCommand NavigationAddCommand { get; set; }
        public IMvxCommand RefreshUsersCommand { get; set; }
        public IMvxCommand NavigationDetailUser { get; set; }
        #endregion
        #region Method
        private async Task UpdateUsersAsync()
        {
            try
            {
                Users = GlobalFunc.ListToObservable(await _adminApi.AdminGetAllUsersAsync());
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }
        }
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            NavigationAddCommand = new MvxCommand(() => _navigationService.Navigate<AddViewModel>());
            RefreshUsersCommand = new MvxAsyncCommand(async () => await UpdateUsersAsync());
            NavigationDetailUser = new MvxAsyncCommand(() => _navigationService
                .Navigate<DetailViewModel, DetailNavigationArgs>(new DetailNavigationArgs { User = SelectedUser }));
        }
        public async override Task Initialize()
        {
            await base.Initialize();
            await UpdateUsersAsync();
        }
        public override Task RaisePropertyChanged([CallerMemberName] string whichProperty = "")
        {
            switch (whichProperty)
            {
                case nameof(SelectedUser):
                    if (SelectedUser is not null)
                    {
                        NavigationDetailUser.Execute();
                    }
                    break;
                default:
                    break;
            }
            return base.RaisePropertyChanged(whichProperty);
        }
        #endregion
    }
}
