using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel
    {
        #region Attribute
        protected IMvxNavigationService _navigationService { get; set; }
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        protected ViewModelBase(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
        #region Command
        #endregion
        #region Method
        #endregion
        #region Override_Method
        #endregion
    }
}
