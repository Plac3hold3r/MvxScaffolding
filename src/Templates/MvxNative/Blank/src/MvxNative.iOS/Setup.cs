using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvxNative.Core;

namespace MvxNative.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override ILoggerFactory CreateLogFactory() => null;
        protected override ILoggerProvider CreateLogProvider() => null;
    }
}
