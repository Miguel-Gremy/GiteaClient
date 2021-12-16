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
        public async override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<HomeViewModel>();

            Mvx.IoCProvider.RegisterSingleton<IAdminApi>(new AdminApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IIssueApi>(new IssueApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IMiscellaneousApi>(new MiscellaneousApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<INotificationApi>(new NotificationApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IOrganizationApi>(new OrganizationApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IRepositoryApi>(new RepositoryApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<ISettingsApi>(new SettingsApi(await Helper.s_GetConfiguration()));
            Mvx.IoCProvider.RegisterSingleton<IUserApi>(new UserApi(await Helper.s_GetConfiguration()));
        }
    }
}
