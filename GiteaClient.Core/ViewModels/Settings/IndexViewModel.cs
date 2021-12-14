using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GiteaClient.Core.ViewModels.Settings
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel(IMvxNavigationService navigationService, ILogger<IndexViewModel> logger) : base(navigationService, logger) { }
    }
}
