using GiteaClient.Core.Data;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Wpf.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace GiteaClient.WPF
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"log\log-.txt", rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 15,
                    retainedFileTimeLimit: new System.TimeSpan(15, 0, 0, 0),
                    outputTemplate: Helper.SLogTemplate,
                    shared: true)
                .WriteTo.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }
    }
}
