using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvxScaffolding.UI.Diagnostics.Writers
{
    public interface IWriter
    {
        Task WriteTraceAsync(TraceEventType eventType, string message, Exception ex = null);

        Task WriteExceptionAsync(Exception ex, string message = null);

        bool AllowMultipleInstances();
    }
}
