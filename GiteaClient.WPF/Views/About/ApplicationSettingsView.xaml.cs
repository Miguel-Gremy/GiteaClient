using GiteaClient.Core.ViewModels.About;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF.Views.About
{
    /// <summary>
    /// Logique d'interaction pour ApplicationSettingsView.xaml
    /// </summary>
    [MvxWindowPresentation(Modal = true)]
    [MvxViewFor(typeof(ApplicationSettingsViewModel))]
    public partial class ApplicationSettingsView : MvxWindow
    {
        public ApplicationSettingsView()
        {
            InitializeComponent();
        }
    }
}
