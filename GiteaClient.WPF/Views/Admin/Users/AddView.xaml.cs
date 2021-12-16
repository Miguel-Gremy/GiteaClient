using GiteaClient.Core.ViewModels.Admin.Users;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF.Views.Admin.Users
{
    /// <summary>
    /// Logique d'interaction pour IndexView.xaml
    /// </summary>
    [MvxWindowPresentation(Modal = true)]
    [MvxViewFor(typeof(AddViewModel))]
    public partial class AddView : MvxWindow
    {
        public AddView()
        {
            InitializeComponent();
        }
    }
}