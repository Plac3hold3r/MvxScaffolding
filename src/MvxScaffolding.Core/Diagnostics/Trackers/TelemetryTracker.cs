//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Setup.Configuration;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Diagnostics.Writers;
using MvxScaffolding.Core.Template;

namespace MvxScaffolding.Core.Diagnostics.Trackers
{
    public class TelemetryTracker : IDisposable
    {
        private string _vsProductVersion = string.Empty;

        public TelemetryTracker()
        {
        }

        public TelemetryTracker(Config config)
        {
            RemoteWriter.SetConfiguration(config);
        }

        public async Task TrackWizardPageAsync(string pageName)
        {
            RemoteWriter.Current.SetContentVsProductVersionToContext(GetVsVersion());
            await RemoteWriter.Current.TrackPageViewAsync(pageName)
                .ConfigureAwait(false);
        }

        public async Task TrackLinkOpenAsync(string linkName)
        {
            var properties = new Dictionary<string, string>()
            {
                [TelemetryProperties.LinkName] = linkName,
            };

            RemoteWriter.Current.SetContentVsProductVersionToContext(GetVsVersion());
            await RemoteWriter.Current.TrackEventAsync(TelemetryEvents.OpenLink, properties)
                .ConfigureAwait(false);
        }

        public async Task TrackUpdateVersionAsync(bool hasShownReleaseNotes)
        {
            var properties = new Dictionary<string, string>()
            {
                [TelemetryProperties.SeenReleaseNotes] = hasShownReleaseNotes.ToStringLowerCase(),
            };

            RemoteWriter.Current.SetContentVsProductVersionToContext(GetVsVersion());
            await RemoteWriter.Current.TrackEventAsync(TelemetryEvents.UpdateVersion, properties)
                .ConfigureAwait(false);
        }

        public async Task TrackEndSessionAsync()
        {
            RemoteWriter.Current.SetContentVsProductVersionToContext(GetVsVersion());

            await RemoteWriter.Current.TrackEventAsync(TelemetryEvents.SessionEnd)
                .ConfigureAwait(false);

            await RemoteWriter.Current.FlushAsync()
                .ConfigureAwait(false);

            RemoteWriter.Reset();
        }

        public async Task TrackWizardCancelledAsync(double seconds)
        {
            var properties = new Dictionary<string, string>()
            {
                [TelemetryProperties.WizardStatus] = WizardStatus.Cancelled.ToString(),
                [TelemetryProperties.WizardType] = TelemetryProperties.NewProject,
            };

            var metrics = new Dictionary<string, double>
            {
                [TelemetryMetrics.TimeSpent] = seconds
            };

            RemoteWriter.Current.SetContentVsProductVersionToContext(GetVsVersion());
            await RemoteWriter.Current.TrackEventAsync(TelemetryEvents.WizardCancelled, properties, metrics)
                .ConfigureAwait(false);
        }

        public async Task TrackProjectGenAsync(ITemplateOptions options, double seconds)
        {
            var properties = new Dictionary<string, string>
            {
                [TelemetryProperties.ProjectType] = MvxScaffoldingContext.CurrentTemplateType.ToString(),
                [TemplateOptions.HasAndroidProject] = options.HasAndroid.ToStringLowerCase(),
                [TemplateOptions.HasIosProject] = options.HasIos.ToStringLowerCase(),
                [TemplateOptions.HasUwpProject] = options.HasUwp.ToStringLowerCase(),
                [TemplateOptions.HasCoreTestProject] = options.HasCoreUnitTestProject.ToStringLowerCase(),
                [TemplateOptions.HasAndroidTestProject] = options.HasAndroidUnitTestProject.ToStringLowerCase(),
                [TemplateOptions.HasIosTestProject] = options.HasIosUnitTestProject.ToStringLowerCase(),
                [TemplateOptions.HasUwpTestProject] = options.HasUwpUnitTestProject.ToStringLowerCase(),
                [TemplateOptions.HasUwpUITestProject] = options.HasUwpUiTestProject.ToStringLowerCase(),
                [TemplateOptions.HasEditorConfig] = options.HasEditorConfig.ToStringLowerCase(),
                [TemplateOptions.SolutionProjectGrouping] = options.SelectedProjectGrouping,
                [TemplateOptions.ScaffoldType] = options.SelectedScaffoldType.ScaffoldType.ToString(),
                [TemplateOptions.AppId] = options.AppId.HasValue(),
                [TemplateOptions.AppName] = options.AppName.HasValue(),
                [TemplateOptions.SolutionName] = options.SolutionName.HasValue(),
                [TemplateOptions.CanCreateSolutionDirectory] = options.CanCreateSolutionDirectory.ToStringLowerCase(),
                [TemplateOptions.NetStandardVersion] = options.SelectedNetStandard,
                [TemplateOptions.AndroidMinSdkVersion] = options.SelectedMinAndroidSDK,
                [TemplateOptions.IosMinSdkVersion] = options.SelectedMinIosSDK,
                [TemplateOptions.UwpMinSdkVersion] = options.SelectedMinUwpSDK,
                [TemplateOptions.UwpAppDescription] = options.UwpDescription.HasValue()
            };

            if (MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative)
                properties = AddNativeProjectProperties(properties, options);
            else
                properties = AddFormsProjectProperties(properties, options);

            var metrics = new Dictionary<string, double>
            {
                [TelemetryMetrics.TimeSpent] = seconds
            };

            await RemoteWriter.Current.TrackEventAsync(TelemetryEvents.ProjectGen, properties, metrics)
                .ConfigureAwait(false);
        }

        public string GetVsVersion()
        {
            if (string.IsNullOrEmpty(_vsProductVersion))
            {
                var configuration = new SetupConfiguration() as ISetupConfiguration;
                ISetupInstance instance = configuration.GetInstanceForCurrentProcess();
                _vsProductVersion = instance.GetInstallationVersion();
            }

            return _vsProductVersion;
        }

        private Dictionary<string, string> AddNativeProjectProperties(Dictionary<string, string> properties, ITemplateOptions options)
        {
            properties.Add(TemplateOptions.Native.HasAndroidUITestProject, options.HasAndroidUiTestProject.ToStringLowerCase());
            properties.Add(TemplateOptions.Native.HasIosUITestProject, options.HasIosUiTestProject.ToStringLowerCase());
            properties.Add(TemplateOptions.Native.AndroidLayoutType, options.SelectedAndroidLayoutType);
            properties.Add(TemplateOptions.Native.IosLayoutType, options.SelectedIosLayoutType);

            return properties;
        }

        private Dictionary<string, string> AddFormsProjectProperties(Dictionary<string, string> properties, ITemplateOptions options)
        {
            properties.Add(TemplateOptions.Forms.HasXamarinUITestProject, options.HasAndroidUiTestProject.ToStringLowerCase());

            return properties;
        }

        ~TelemetryTracker()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                RemoteWriter.Current.Dispose();
        }
    }
}
