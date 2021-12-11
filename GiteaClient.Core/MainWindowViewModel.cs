using GiteaClient.Core.ViewModels;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {

        }
    }
}
