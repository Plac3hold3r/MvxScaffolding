//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvxScaffolding.Core.Configuration;
using MvxScaffolding.Core.Diagnostics.Writers;

namespace MvxScaffolding.Core.Diagnostics.Trackers
{
    public class TraceTracker
    {
        private readonly TraceEventType _traceEventType;

        public TraceTracker(TraceEventType eventType)
        {
            _traceEventType = eventType;
        }

        public async Task TrackAsync(string traceToTrack, Exception ex = null)
        {
            if (IsTraceEnabled())
            {
                foreach (IWriter writer in Logger.Writers)
                    await SafeTrackAsync(traceToTrack, ex, writer);
            }
        }

        private async Task SafeTrackAsync(string traceToTrack, Exception ex, IWriter writer)
        {
            try
            {
                if (writer != null)
                {
                    await writer.WriteTraceAsync(_traceEventType, traceToTrack, ex)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError($"Error writing event to listener {writer?.GetType().ToString()}. Exception:\r\n{exception.ToString()}");
            }
        }

        private bool IsTraceEnabled()
        {
            return _traceEventType <= Config.Current.DiagnosticsTraceLevel;
        }
    }
}
