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

namespace GiteaClient.Core.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel
    {
        #region Attribute
        protected IMvxNavigationService _navigationService { get; set; }
        private bool _returnButtonVisibility = true;
        private bool _homeButtonVisibility = true;
        #endregion
        #region Accessor
        public bool ReturnButtonVisibility
        {
            get { return _returnButtonVisibility; }
            set => SetProperty(ref _returnButtonVisibility, value);
        }
        public bool HomeButtonVisibility
        {
            get { return _homeButtonVisibility; }
            set => SetProperty(ref _homeButtonVisibility, value);
        }
        #endregion
        #region Constructor
        protected ViewModelBase(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
        #region Command
        public IMvxCommand ReturnCommand { get; set; }
        public IMvxCommand ReturnHomeCommand { get; set; }
        #endregion
        #region Method
        protected static ObservableCollection<T> ListToObservable<T>(ICollection<T> list)
        {
            return new ObservableCollection<T>(list);
        }
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            ReturnCommand = new MvxAsyncCommand(() => Task.Run(() => _navigationService.Close(this)));
            ReturnHomeCommand = new MvxAsyncCommand(() => Task.Run(() => _navigationService.Navigate<HomeViewModel>()));
        }
        #endregion
    }
}
