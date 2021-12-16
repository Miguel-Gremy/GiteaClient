using GiteaClient.Core.Data;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Wpf.Core;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

namespace GiteaClient.WPF
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"log\log-.log", rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 15,
                    retainedFileTimeLimit: new System.TimeSpan(15, 0, 0, 0),
                    outputTemplate: Helper.SLogTemplate,
                    shared: true)
                .WriteTo.File(new CompactJsonFormatter(new JsonValueFormatter("_typeTag")), @"log\json\log-.json",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 15,
                    retainedFileTimeLimit: new System.TimeSpan(15, 0, 0, 0),
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
