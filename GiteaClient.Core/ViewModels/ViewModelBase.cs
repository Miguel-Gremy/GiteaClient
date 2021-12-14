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

namespace GiteaClient.Core.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel
    {
        #region Attribute
        protected ILogger<ViewModelBase> _logger { get; set; }
        protected IMvxNavigationService _navigationService { get; set; }
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        protected ViewModelBase(IMvxNavigationService navigationService, ILogger<ViewModelBase> logger)
        {
            _logger = logger;
            _navigationService = navigationService;
        }
        #endregion
        #region Command
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
        }
        #endregion
    }
}
