#region

using System;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class AddViewModel : MvxViewModel
    {
        #region Constructor

        public AddViewModel(IMvxNavigationService navigationService, ILogger<AddViewModel> logger,
            IAdminApi adminApi)
        {
            NavigationService = navigationService;
            Logger = logger;
            AdminApi = adminApi;
        }

        #endregion

        #region Command

        public IMvxCommand ConfirmAddCommand { get; private set; }

        #endregion

        #region Method

        private async void OnConfirmAddExec()
        {
            var createUserOption = new CreateUserOption(User.Email, User.FullName, User.Login,
                MustChangePassword, Password, SendNotify, null, UserName);

            try
            {
                await AdminApi.AdminCreateUserAsync(createUserOption);
            }
            catch (Exception e)
            {
                Logger.LogWarning(e, "An error occured : {e.Message}", e.Message);
            }

            await NavigationService.Close(this);
        }

        #endregion

        #region Attribute

        private ILogger<AddViewModel> Logger { get; set; }
        private IMvxNavigationService NavigationService { get; set; }

        private IAdminApi AdminApi { get; }
        private IO.Swagger.Model.User _user;
        private string _userName;
        private string _password;
        private bool _mustChangePassword;
        private bool _sendNotify;

        #endregion

        #region Accessor

        public IO.Swagger.Model.User User
        {
            get => _user;
            private set => SetProperty(ref _user, value);
        }

        public bool MustChangePassword
        {
            get => _mustChangePassword;
            set => SetProperty(ref _mustChangePassword, value);
        }

        public bool SendNotify
        {
            get => _sendNotify;
            set => SetProperty(ref _sendNotify, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        #endregion

        #region Override_Method

        public override void Prepare()
        {
            base.Prepare();
            ConfirmAddCommand = new MvxAsyncCommand(() => Task.Run(OnConfirmAddExec));
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            User = new IO.Swagger.Model.User();
            UserName = string.Empty;
            Password = string.Empty;
            SendNotify = false;
            MustChangePassword = true;
        }

        #endregion
    }
}