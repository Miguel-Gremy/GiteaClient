using GiteaClient.Core.ViewModels.About;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF.Views.About
{
    /// <summary>
    /// Logique d'interaction pour IndexView.xaml
    /// </summary>
    [MvxWindowPresentation(Modal = true)]
    [MvxViewFor(typeof(ShowLogViewModel))]
    public partial class ShowLogView : MvxWindow
    {
        public ShowLogView()
        {
            InitializeComponent();
        }
    }
}