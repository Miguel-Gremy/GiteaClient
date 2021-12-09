using GiteaClient.Core.Data;
using GiteaClient.Core.ViewModels;
using IO.Swagger.Api;
using IO.Swagger.Client;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiteaClient.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<HomeViewModel>();

            Mvx.IoCProvider.RegisterSingleton<IAdminApi>(new AdminApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IIssueApi>(new IssueApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IMiscellaneousApi>(new MiscellaneousApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<INotificationApi>(new NotificationApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IOrganizationApi>(new OrganizationApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IRepositoryApi>(new RepositoryApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<ISettingsApi>(new SettingsApi(Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IUserApi>(new UserApi(Helper.s_GetConfiguration()));
        }
    }
}
