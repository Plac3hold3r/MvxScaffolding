using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Platform;
using MvvmCross.Forms.Uwp;
using MvvmCross.Platform.Logging;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

namespace MvxFormsTemp.UWP
{
    public class Setup : MvxFormsWindowsSetup
    {
        public Setup(Frame rootFrame, LaunchActivatedEventArgs e) : base(rootFrame, e)
        {
        }

        protected override IMvxApplication CreateApp()
            => new Core.App();

        protected override MvxFormsApplication CreateFormsApplication()
            => new UI.App();

        protected override IEnumerable<Assembly> GetViewAssemblies() => new List<Assembly>(base.GetViewAssemblies())
        {
            typeof(UI.App).GetTypeInfo().Assembly
        };

        // https://github.com/MvvmCross/MvvmCross/issues/2333
        protected override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.None;
    }
}
