using GiteaClient.Core.ViewModels;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core
{
    public class MainWindowViewModel : MvxViewModel
    {
        protected ILogger<MainWindowViewModel> _logger { get; set; }
        public MainWindowViewModel(ILogger<MainWindowViewModel> logger)
        {
            _logger = logger;
        }
    }
}
