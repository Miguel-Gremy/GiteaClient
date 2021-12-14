using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core.ViewModels.Issue
{
    public class IndexViewModel : MvxViewModel
    {
        #region Attribute
        protected ILogger<IndexViewModel> _logger { get; set; }
        #endregion
        #region Accessor
        #endregion
        #region Constructor
        public IndexViewModel(ILogger<IndexViewModel> logger)
        {
            _logger = logger;
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
