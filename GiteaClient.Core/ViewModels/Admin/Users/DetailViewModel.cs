#region

using System;
using System.Collections.Generic;
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
                Task<List<IO.Swagger.Model.User>> followersTask = UserApi.UserListFollowersAsync(User.Login);
                Task<List<IO.Swagger.Model.User>> followingTask = UserApi.UserListFollowersAsync(User.Login);
                Task<List<IO.Swagger.Model.Repository>> userRepositoriesTask = UserApi.UserListReposAsync(User.Login);
                Task<List<IO.Swagger.Model.Repository>> userSubscribedRepositoriesTask = UserApi.UserListSubscriptionsAsync(User.Login);

                Followers =
                    GlobalFunc.ListToObservable(await followersTask);
                Following =
                    GlobalFunc.ListToObservable(await followingTask);
                UserRepositories =
                    GlobalFunc.ListToObservable(await userRepositoriesTask);
                UserSubscribedRepositories =
                    GlobalFunc.ListToObservable(await userSubscribedRepositoriesTask);
            }
            catch (Exception e)
            {
                Logger.LogWarning(e, "An error occured : {e.Message}", e.Message);
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
        private ObservableCollection<IO.Swagger.Model.AccessToken> _userAccessTokens;

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