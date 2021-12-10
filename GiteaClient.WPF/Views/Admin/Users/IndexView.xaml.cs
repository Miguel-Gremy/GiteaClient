using GiteaClient.Core.ViewModels.Admin.Users;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF.Views.Admin.Users
{
    /// <summary>
    /// Logique d'interaction pour IndexView.xaml
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
