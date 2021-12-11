using IO.Swagger.Api;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Admin.Users
{
    public class AddViewModel : ViewModelBase
    {
        #region Attribute
        private IAdminApi _adminApi { get; set; }
        private string _email;
        private string _fullName;
        private string _login;
        private string _userName;
        private string _password;
        private bool _mustChangePassword;
        private bool _sendNotify;
        #endregion
        #region Accessor
        public string Email
        {
            get { return _email; }
            set => SetProperty(ref _email, value);
        }
        public string FullName
        {
            get { return _fullName; }
            set => SetProperty(ref _fullName, value);
        }
        public string Login
        {
            get { return _login; }
            set => SetProperty(ref _login, value);
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
        public AddViewModel(IMvxNavigationService navigationService, IAdminApi adminApi) : base(navigationService)
        {
            _adminApi = adminApi;
        }
        #endregion
        #region Command
        public IMvxCommand ConfirmAddCommand { get; set; }
        #endregion
        #region Method
        private async void OnConfirmAddExec()
        {
            var createUserOption = new IO.Swagger.Model.CreateUserOption(Email, FullName, Login, MustChangePassword, Password, SendNotify, null, UserName, null);

            await _adminApi.AdminCreateUserAsync(createUserOption);
            await _navigationService.Navigate<IndexViewModel>();
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
            Email = string.Empty;
            FullName = string.Empty;
            Login = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            SendNotify = false;
            MustChangePassword = true;
        }
        #endregion
    }
}
