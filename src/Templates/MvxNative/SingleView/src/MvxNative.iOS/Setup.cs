using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvxNative.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace MvxNative.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.NSLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
