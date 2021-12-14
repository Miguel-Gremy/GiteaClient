using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GiteaClient.Core.ViewModels.Settings
{
    public class IndexViewModel : MvxViewModel
    {
        protected ILogger<IndexViewModel> _logger { get; set; }
        public IndexViewModel(ILogger<IndexViewModel> logger)
        {
            _logger = logger;
        }
    }
}
