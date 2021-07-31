using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Uap.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace MvxFormsTemp.UWP
{
    public class Setup : MvxFormsWindowsSetup<Core.App, UI.App>
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
