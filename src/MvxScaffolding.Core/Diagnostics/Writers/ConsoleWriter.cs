//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvxScaffolding.Core.Diagnostics.Writers
{
    public class ConsoleWriter : IWriter
    {
        public async Task WriteTraceAsync(TraceEventType eventType, string message, Exception ex = null)
        {
            var formattedMessage = $"{eventType.ToString()}\t{message}";
            if (ex != null)
            {
                formattedMessage = formattedMessage + $"\tException:\n\r{ex.ToString()}";
            }

            switch (eventType)
            {
                case TraceEventType.Critical:
                case TraceEventType.Error:
                    await CallAsync(() => Trace.TraceError(formattedMessage));
                    break;
                case TraceEventType.Warning:
                    await CallAsync(() => Trace.TraceWarning(formattedMessage));
                    break;
                case TraceEventType.Information:
                case TraceEventType.Verbose:
                    await CallAsync(() => Trace.TraceInformation(formattedMessage));
                    break;
                default:
                    await CallAsync(() => Trace.TraceInformation(formattedMessage));
                    break;
            }

            Debug.WriteLine(formattedMessage);
        }

        public async Task WriteExceptionAsync(Exception ex, string message = null)
        {
            await WriteTraceAsync(TraceEventType.Critical, "Exception Tracked", ex);
        }

        async Task CallAsync(Action action)
        {
            var task = Task.Run(() => action);
            await task;
        }
    }
}
