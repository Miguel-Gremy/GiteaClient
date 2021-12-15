using GiteaClient.Core.Assets;
using IO.Swagger.Api;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class DetailNavigationArgs
    {
        public IO.Swagger.Model.User User { get; set; }
    }

    public class DetailViewModel : MvxViewModel<DetailNavigationArgs>
    {
        #region Attribute
        protected ILogger<ListViewModel> _logger { get; set; }
        protected IMvxNavigationService _navigationService { get; set; }
        protected IUserApi _userApi { get; set; }

        private IO.Swagger.Model.User _User;
        private ObservableCollection<IO.Swagger.Model.User> _folowers;
        private ObservableCollection<IO.Swagger.Model.User> _folowing;
        private ObservableCollection<IO.Swagger.Model.Repository> _userRepositories;
        private ObservableCollection<IO.Swagger.Model.Repository> _userSubscribedRepositories;
        private ObservableCollection<IO.Swagger.Model.AccessToken> _userAccessTokens;
        #endregion
        #region Accessor
        public IO.Swagger.Model.User User
        {
            get { return _User; }
            set => SetProperty(ref _User, value);
        }
        public ObservableCollection<IO.Swagger.Model.User> Followers
        {
            get { return _folowers; }
            set => SetProperty(ref _folowers, value);
        }
        public ObservableCollection<IO.Swagger.Model.User> Following
        {
            get { return _folowing; }
            set => SetProperty(ref _folowing, value);
        }
        public ObservableCollection<IO.Swagger.Model.Repository> UserRepositories
        {
            get { return _userRepositories; }
            set => SetProperty(ref _userRepositories, value);
        }
        public ObservableCollection<IO.Swagger.Model.Repository> UserSubscribedRepositories
        {
            get { return _userSubscribedRepositories; }
            set => SetProperty(ref _userSubscribedRepositories, value);
        }
        public ObservableCollection<IO.Swagger.Model.AccessToken> UserAccessTokens
        {
            get { return _userAccessTokens; }
            set => SetProperty(ref _userAccessTokens, value);
        }
        #endregion
        #region Constructor
        public DetailViewModel(IMvxNavigationService navigationService, ILogger<ListViewModel> logger, IUserApi userApi)
        {
            _navigationService = navigationService;
            _logger = logger;
            _userApi = userApi;
        }
        #endregion
        #region Command
        #endregion
        #region Method
        private async Task UpdateUserData()
        {
            try
            {
                Followers = GlobalFunc.ListToObservable(await _userApi.UserListFollowersAsync(User.Login));
                Following = GlobalFunc.ListToObservable(await _userApi.UserListFollowingAsync(User.Login));
                UserRepositories = GlobalFunc.ListToObservable(await _userApi.UserListReposAsync(User.Login));
                UserSubscribedRepositories = GlobalFunc.ListToObservable(await _userApi.UserListSubscriptionsAsync(User.Login));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }
        }
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
