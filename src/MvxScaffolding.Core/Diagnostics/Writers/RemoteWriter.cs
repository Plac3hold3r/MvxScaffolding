//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.VisualStudio.Telemetry;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Contexts;
using MvxScaffolding.Core.Properties;

namespace MvxScaffolding.Core.Diagnostics.Writers
{
    public class RemoteWriter : IWriter, IDisposable
    {
        public bool IsEnabled { get; private set; }

        private readonly Config _currentConfig;
        private TelemetryClient _client;

        private static RemoteWriter _current;

        public static RemoteWriter Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new RemoteWriter(Config.Current);
                }

                return _current;
            }
            private set => _current = value;
        }

        public static void Reset()
        {
            _current.Dispose();
            _current = null;
        }

        private RemoteWriter(Config config)
        {
            _currentConfig = config ?? throw new ArgumentNullException(nameof(config));

            IntializeTelemetryClient();
        }

        public static void SetConfiguration(Config config)
        {
            _current = new RemoteWriter(config);
        }

        public async Task TrackEventAsync(string eventName, Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null)
        {
            await SafeExecuteAsync(() => _client.TrackEvent(eventName, properties, metrics))
                .ConfigureAwait(false);
        }

        public async Task TrackExceptionAsync(Exception ex, Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null)
        {
            await SafeExecuteAsync(() => _client.TrackException(ex, properties, metrics))
                .ConfigureAwait(false);
        }

        public async Task WriteTraceAsync(TraceEventType eventType, string message, Exception ex = null)
        {
            await Task.Run(() => { });
        }

        public async Task TrackPageViewAsync(string pageName)
        {
            await SafeExecuteAsync(() => _client.TrackPageView(pageName))
                .ConfigureAwait(false);
        }

        public async Task WriteExceptionAsync(Exception ex, string message = null)
        {
            var properties = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(message))
            {
                properties.Add("Additional info", message);
            }

            await Current.TrackExceptionAsync(ex, properties);
        }

        private void IntializeTelemetryClient()
        {
            try
            {
                _client = new TelemetryClient()
                {
                    InstrumentationKey = _currentConfig.RemoteTelemetryKey
                };

                if (VsTelemetryIsOptedIn() && RemoteKeyAvailable())
                {
                    SetSessionData();

                    _client.TrackEvent(TelemetryEvents.SessionStart);

                    IsEnabled = true;
#if DEBUG
                    TelemetryConfiguration.Active.TelemetryChannel.DeveloperMode = true;
#endif
                }
                else
                {
                    IsEnabled = false;
                    TelemetryConfiguration.Active.DisableTelemetry = true;
                }
            }
            catch (Exception ex)
            {
                IsEnabled = false;
                TelemetryConfiguration.Active.DisableTelemetry = true;

                Trace.TraceError($"Exception instantiating TelemetryClient:\n\r{ex.ToString()}");
            }
        }

        private bool VsTelemetryIsOptedIn()
        {
            try
            {
                Assembly.Load(new AssemblyName("Microsoft.VisualStudio.Telemetry"));
                return SafeVsTelemetryIsOptedIn();
            }
            catch (Exception ex)
            {
                Trace.TraceWarning($"Unable to load the assembly 'Microsoft.VisualStudio.Telemetry'. Visual Studio Telemetry OptIn/OptOut setting will not be considered. Details:\r\n{ex.ToString()}");
                return true;
            }
        }

        private bool SafeVsTelemetryIsOptedIn()
        {
            var result = false;
            var vsEdition = string.Empty;
            var vsVersion = string.Empty;
            var vsCulture = string.Empty;
            var vsManifestId = string.Empty;

            try
            {
                if (TelemetryService.DefaultSession != null)
                {
                    var isOptedIn = TelemetryService.DefaultSession.IsOptedIn;
                    Trace.TraceInformation($"Vs Telemetry IsOptedIn: {isOptedIn}");
                    vsEdition = TelemetryService.DefaultSession?.GetSharedProperty("VS.Core.SkuName");
                    vsVersion = TelemetryService.DefaultSession?.GetSharedProperty("VS.Core.ExeVersion");
                    vsCulture = TelemetryService.DefaultSession?.GetSharedProperty("VS.Core.Locale.ProductLocaleName");
                    vsManifestId = TelemetryService.DefaultSession?.GetSharedProperty("VS.Core.ManifestId");

                    result = isOptedIn;
                }
                else
                {
                    Trace.TraceInformation($"Checking VsTelemetry IsOptedIn value {nameof(TelemetryService.DefaultSession)} is Null.");
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceInformation($"Exception checking VsTelemetry IsOptedIn:\r\n" + ex.ToString());
                result = true;
            }

            _client.Context.Properties.Add(TelemetryProperties.VisualStudioEdition, vsEdition);
            _client.Context.Properties.Add(TelemetryProperties.VisualStudioExeVersion, vsVersion);
            _client.Context.Properties.Add(TelemetryProperties.VisualStudioCulture, vsCulture);
            _client.Context.Properties.Add(TelemetryProperties.VisualStudioManifestId, vsManifestId);
            return result;
        }

        private void SetSessionData()
        {
            if (Settings.Default.AiUserId == Guid.Empty)
            {
                Settings.Default.AiUserId = Guid.NewGuid();
                Settings.Default.Save();
            }

            if (Settings.Default.AiDeviceId == Guid.Empty)
            {
                Settings.Default.AiDeviceId = Guid.NewGuid();
                Settings.Default.Save();
            }

            var userToTrack = Settings.Default.AiUserId.ToString();
            var machineToTrack = Settings.Default.AiDeviceId.ToString();

            _client.Context.User.Id = userToTrack;
            _client.Context.User.AccountId = userToTrack;
            _client.Context.User.AuthenticatedUserId = userToTrack;

            _client.Context.Device.Id = machineToTrack;
            _client.Context.Device.OperatingSystem = Environment.OSVersion.VersionString;

            _client.Context.Cloud.RoleInstance = TelemetryProperties.RoleInstanceName;
            _client.Context.Cloud.RoleName = TelemetryProperties.RoleInstanceName;

            _client.Context.Session.Id = Guid.NewGuid().ToString();
            _client.Context.Component.Version = MvxScaffoldingContext.WizardVersion.ToString();
            _client.Context.Properties.Add(TelemetryProperties.WizardVersion, MvxScaffoldingContext.WizardVersion.ToString());
            _client.Context.Properties.Add(TelemetryProperties.ProjectType, MvxScaffoldingContext.CurrentTemplateType.ToString());
        }

        public void SetContentVsProductVersionToContext(string vsProductVersion)
        {
            if (!string.IsNullOrEmpty(vsProductVersion) && _client != null && _client.Context != null && _client.Context.Properties != null)
            {
                if (!_client.Context.Properties.ContainsKey(TelemetryProperties.VisualStudioProductVersion))
                {
                    _client.Context.Properties.Add(TelemetryProperties.VisualStudioProductVersion, vsProductVersion);
                }
                else
                {
                    _client.Context.Properties[TelemetryProperties.VisualStudioProductVersion] = vsProductVersion;
                }

                if (!_client.Context.Properties.ContainsKey(TelemetryProperties.ProjectType))
                {
                    _client.Context.Properties.Add(TelemetryProperties.ProjectType, MvxScaffoldingContext.CurrentTemplateType.ToString());
                }
            }
        }

        private async Task SafeExecuteAsync(Action action)
        {
            try
            {
                var task = Task.Run(action);

                await task;
            }
            catch (AggregateException aggEx)
            {
                foreach (Exception ex in aggEx.InnerExceptions)
                {
                    Trace.TraceError($"Error tracking telemetry: {ex}");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error tracking telemetry: {ex}");
            }
        }

        private async Task SafeExecuteAsync(Func<Task> action)
        {
            try
            {
                var task = Task.Run(action);

                await task;
            }
            catch (AggregateException aggEx)
            {
                foreach (Exception ex in aggEx.InnerExceptions)
                {
                    Trace.TraceError($"Error tracking telemetry: {ex}");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error tracking telemetry: {ex}");
            }
        }

        public async Task FlushAsync()
        {
            await SafeExecuteAsync(async () =>
            {
                if (_client != null)
                {
                    _client.Flush();
                    _client = null;
                }

                await Task.Delay(1000);
            });
        }

        public void Flush()
        {
            try
            {
                if (_client != null)
                {
                    _client.Flush();
                    System.Threading.Thread.Sleep(1000);

                    _client = null;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error tracking telemetry: {0}", ex.ToString());
            }
        }

        private bool RemoteKeyAvailable()
        {
            // Returns true if a valid AI key or tagged AI key exists
            var validGuid = Guid.TryParse(_currentConfig.RemoteTelemetryKey, out Guid auxA);
            var taggedGuid = Guid.TryParse(_currentConfig.RemoteTelemetryKey.Substring(4), out Guid auxB);
            return validGuid || taggedGuid;
        }

        ~RemoteWriter()
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
                Flush();
        }
    }
}
