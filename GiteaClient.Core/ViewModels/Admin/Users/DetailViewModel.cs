#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GiteaClient.Core.Assets;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class DetailNavigationArgs
    {
        public IO.Swagger.Model.User User { get; init; }
    }

    public class DetailViewModel : MvxViewModel<DetailNavigationArgs>
    {
        #region Constructor

        public DetailViewModel(IMvxNavigationService navigationService,
            ILogger<DetailViewModel> logger, IUserApi userApi)
        {
            Logger = logger;
            UserApi = userApi;
        }

        #endregion

        #region Method

        private async Task UpdateUserData()
        {
            try
            {
                Followers =
                    GlobalFunc.ListToObservable(await UserApi.UserListFollowersAsync(User.Login));
                Following =
                    GlobalFunc.ListToObservable(await UserApi.UserListFollowingAsync(User.Login));
                UserRepositories =
                    GlobalFunc.ListToObservable(await UserApi.UserListReposAsync(User.Login));
                UserSubscribedRepositories =
                    GlobalFunc.ListToObservable(
                        await UserApi.UserListSubscriptionsAsync(User.Login));
            }
            catch (Exception e)
            {
                Logger.LogWarning("{e.Message}", e.Message);
            }
        }

        #endregion

        #region Attribute

        private ILogger<DetailViewModel> Logger { get; set; }
        private IUserApi UserApi { get; set; }

        private IO.Swagger.Model.User _user;
        private ObservableCollection<IO.Swagger.Model.User> _folowers;
        private ObservableCollection<IO.Swagger.Model.User> _folowing;
        private ObservableCollection<IO.Swagger.Model.Repository> _userRepositories;
        private ObservableCollection<IO.Swagger.Model.Repository> _userSubscribedRepositories;
        private ObservableCollection<AccessToken> _userAccessTokens;

        #endregion

        #region Accessor

        public IO.Swagger.Model.User User
        {
            get => _user;
            private set => SetProperty(ref _user, value);
        }

        public ObservableCollection<IO.Swagger.Model.User> Followers
        {
            get => _folowers;
            private set => SetProperty(ref _folowers, value);
        }

        public ObservableCollection<IO.Swagger.Model.User> Following
        {
            get => _folowing;
            private set => SetProperty(ref _folowing, value);
        }

        public ObservableCollection<IO.Swagger.Model.Repository> UserRepositories
        {
            get => _userRepositories;
            private set => SetProperty(ref _userRepositories, value);
        }

        public ObservableCollection<IO.Swagger.Model.Repository> UserSubscribedRepositories
        {
            get => _userSubscribedRepositories;
            private set => SetProperty(ref _userSubscribedRepositories, value);
        }

        public ObservableCollection<AccessToken> UserAccessTokens
        {
            get => _userAccessTokens;
            set => SetProperty(ref _userAccessTokens, value);
        }

        #endregion

        #region Command

        #endregion

        #region Override_Method

        public override void Prepare(DetailNavigationArgs args)
        {
            base.Prepare();
            User = args.User;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await UpdateUserData();
        }

        #endregion
    }
}