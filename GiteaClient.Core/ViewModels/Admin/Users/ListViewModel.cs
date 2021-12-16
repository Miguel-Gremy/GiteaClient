#region

using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GiteaClient.Core.Assets;
using IO.Swagger.Api;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class ListViewModel : MvxViewModel
    {
        #region Constructor

        public ListViewModel(IMvxNavigationService navigationService, ILogger<ListViewModel> logger,
            IAdminApi adminApi)
        {
            NavigationService = navigationService;
            Logger = logger;
            AdminApi = adminApi;
        }

        #endregion

        #region Method

        private async Task UpdateUsersAsync()
        {
            try
            {
                Users = GlobalFunc.ListToObservable(await AdminApi.AdminGetAllUsersAsync());
            }
            catch (Exception e)
            {
                Logger.LogWarning(e, "An error occured : {e.Message}", e.Message);
            }
        }

        #endregion

        #region Attribute

        private ILogger<ListViewModel> Logger { get; set; }
        private IMvxNavigationService NavigationService { get; set; }

        private IAdminApi AdminApi { get; }
        private ObservableCollection<IO.Swagger.Model.User> _users;
        private IO.Swagger.Model.User _selectedUser;

        #endregion

        #region Accessor

        public IO.Swagger.Model.User SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public ObservableCollection<IO.Swagger.Model.User> Users
        {
            get => _users;
            private set => SetProperty(ref _users, value);
        }

        #endregion

        #region Command

        public IMvxCommand NavigationAddCommand { get; private set; }
        public IMvxCommand RefreshUsersCommand { get; private set; }
        private IMvxCommand NavigationDetailUser { get; set; }

        #endregion

        #region Override_Method

        public override void Prepare()
        {
            base.Prepare();
            NavigationAddCommand =
                new MvxCommand(() => NavigationService.Navigate<AddViewModel>());
            RefreshUsersCommand = new MvxAsyncCommand(async () => await UpdateUsersAsync());
            NavigationDetailUser = new MvxAsyncCommand(() => NavigationService
                .Navigate<DetailViewModel, DetailNavigationArgs>(new DetailNavigationArgs
                { User = SelectedUser }));
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await UpdateUsersAsync();
        }

        public override Task RaisePropertyChanged([CallerMemberName] string whichProperty = "")
        {
            switch (whichProperty)
            {
                case nameof(SelectedUser):
                    if (SelectedUser is not null) NavigationDetailUser.Execute();
                    break;
            }

            return base.RaisePropertyChanged(whichProperty);
        }

        #endregion
    }
}