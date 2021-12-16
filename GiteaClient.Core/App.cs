#region

using GiteaClient.Core.Data;
using GiteaClient.Core.ViewModels;
using IO.Swagger.Api;
using MvvmCross;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core
{
    public class App : MvxApplication
    {
        public override async void Initialize()
        {
            base.Initialize();

            RegisterAppStart<HomeViewModel>();

            Mvx.IoCProvider.RegisterSingleton<IAdminApi>(
                new AdminApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<IIssueApi>(
                new IssueApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<IMiscellaneousApi>(
                new MiscellaneousApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<INotificationApi>(
                new NotificationApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<IOrganizationApi>(
                new OrganizationApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<IRepositoryApi>(
                new RepositoryApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<ISettingsApi>(
                new SettingsApi(await Helper.s_GetConfigurationAsync()));
            Mvx.IoCProvider.RegisterSingleton<IUserApi>(
                new UserApi(await Helper.s_GetConfigurationAsync()));
        }
    }
}