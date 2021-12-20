#region

using GiteaClient.Core.Data;
using GiteaClient.Core.ViewModels;
using IO.Swagger.Api;
using MvvmCross;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

#endregion

namespace GiteaClient.Core
{
    public class App : MvxApplication
    {
        public override async void Initialize()
        {
            base.Initialize();

            Task<IO.Swagger.Client.Configuration> getConfigTask = Helper.s_GetConfigurationAsync();

            RegisterAppStart<HomeViewModel>();

            Mvx.IoCProvider.RegisterSingleton<IAdminApi>(
                new AdminApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<IIssueApi>(
                new IssueApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<IMiscellaneousApi>(
                new MiscellaneousApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<INotificationApi>(
                new NotificationApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<IOrganizationApi>(
                new OrganizationApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<IRepositoryApi>(
                new RepositoryApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<ISettingsApi>(
                new SettingsApi(await getConfigTask));
            Mvx.IoCProvider.RegisterSingleton<IUserApi>(
                new UserApi(await getConfigTask));
        }
    }
}