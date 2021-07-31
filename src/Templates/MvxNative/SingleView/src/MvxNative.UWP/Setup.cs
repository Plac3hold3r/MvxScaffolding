using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Uap.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace MvxNative.UWP
{
    public class Setup : MvxWindowsSetup<Core.App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
