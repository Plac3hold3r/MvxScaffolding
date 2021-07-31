using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using MvxNative.Core;

namespace MvxNative.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override ILoggerFactory CreateLogFactory() => null;
        protected override ILoggerProvider CreateLogProvider() => null;
    }
}
