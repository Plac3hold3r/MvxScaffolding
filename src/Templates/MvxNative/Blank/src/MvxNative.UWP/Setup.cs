using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Uap.Core;

namespace MvxNative.UWP
{
    public class Setup : MvxWindowsSetup<Core.App>
    {
        protected override ILoggerFactory CreateLogFactory() => null;
        protected override ILoggerProvider CreateLogProvider() => null;
    }
}
