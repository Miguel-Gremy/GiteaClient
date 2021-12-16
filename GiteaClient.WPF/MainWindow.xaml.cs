using GiteaClient.Core;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace GiteaClient.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [MvxWindowPresentation(Identifier = nameof(MainWindow), Modal = false)]
    [MvxViewFor(typeof(MainWindowViewModel))]
    public partial class MainWindow : MvxWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}