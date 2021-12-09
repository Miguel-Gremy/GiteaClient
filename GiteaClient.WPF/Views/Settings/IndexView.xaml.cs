using GiteaClient.Core.ViewModels.Settings;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF.Views.Settings
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    [MvxContentPresentation]
    [MvxViewFor(typeof(IndexView))]
    public partial class IndexView : MvxWpfView
    {
        public IndexView()
        {
            InitializeComponent();
        }
    }
}
