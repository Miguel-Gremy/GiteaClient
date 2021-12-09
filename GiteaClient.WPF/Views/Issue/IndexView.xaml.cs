using GiteaClient.Core.ViewModels.Issue;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF.Views.Issue
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    [MvxContentPresentation]
    [MvxViewFor(typeof(IndexViewModel))]
    public partial class IndexView : MvxWpfView
    {
        public IndexView()
        {
            InitializeComponent();
        }
    }
}
