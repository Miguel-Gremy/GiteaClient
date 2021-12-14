using IO.Swagger.Api;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class AddViewModel : MvxViewModel
    {
        #region Attribute
        protected ILogger<AddViewModel> _logger { get; set; }
        protected IMvxNavigationService _navigationService { get; set; }

        private IAdminApi _adminApi { get; set; }
        private IO.Swagger.Model.User _user;
        private string _userName;
        private string _password;
        private bool _mustChangePassword;
        private bool _sendNotify;
        #endregion
        #region Accessor
        public IO.Swagger.Model.User User
        {
            get { return _user; }
            set => SetProperty(ref _user, value);
        }
        public bool MustChangePassword
        {
            get { return _mustChangePassword; }
            set => SetProperty(ref _mustChangePassword, value);
        }
        public bool SendNotify
        {
            get { return _sendNotify; }
            set => SetProperty(ref _sendNotify, value);
        }
        public string UserName
        {
            get { return _userName; }
            set => SetProperty(ref _userName, value);
        }
        public string Password
        {
            get { return _password; }
            set => SetProperty(ref _password, value);
        }
        #endregion
        #region Constructor
        public AddViewModel(IMvxNavigationService navigationService, ILogger<AddViewModel> logger, IAdminApi adminApi)
        {
            _navigationService = navigationService;
            _logger = logger;
            _adminApi = adminApi;
        }
        #endregion
        #region Command
        public IMvxCommand ConfirmAddCommand { get; set; }
        #endregion
        #region Method
        private async void OnConfirmAddExec()
        {
            var createUserOption = new IO.Swagger.Model.CreateUserOption(User.Email, User.FullName, User.Login, MustChangePassword, Password, SendNotify, null, UserName, null);

            try
            {
                await _adminApi.AdminCreateUserAsync(createUserOption);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }
            await _navigationService.Close(this);
        }
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            ConfirmAddCommand = new MvxAsyncCommand(() => Task.Run(() => OnConfirmAddExec()));
        }
        public async override Task Initialize()
        {
            await base.Initialize();
            User = new();
            UserName = string.Empty;
            Password = string.Empty;
            SendNotify = false;
            MustChangePassword = true;
        }
        #endregion
    }
}
