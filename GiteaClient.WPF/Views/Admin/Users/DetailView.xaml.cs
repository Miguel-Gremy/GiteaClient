using GiteaClient.Core.ViewModels.Admin.Users;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GiteaClient.WPF.Views.Admin.Users
{
    /// <summary>
    /// Logique d'interaction pour DetailView.xaml
    /// </summary>
    [MvxWindowPresentation(Modal = true)]
    [MvxViewFor(typeof(DetailViewModel))]
    public partial class DetailView : MvxWindow
    {
        public DetailView()
        {
            InitializeComponent();
        }
    }
}