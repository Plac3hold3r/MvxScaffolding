using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Uap.Core;

namespace MvxFormsTemp.UWP
{
    public class Setup : MvxFormsWindowsSetup<Core.App, UI.App>
    {
        protected override ILoggerFactory CreateLogFactory() => null;
        protected override ILoggerProvider CreateLogProvider() => null;
    }
}
