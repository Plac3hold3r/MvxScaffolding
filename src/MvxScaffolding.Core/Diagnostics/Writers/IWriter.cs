//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvxScaffolding.Core.Diagnostics.Writers
{
    public interface IWriter
    {
        Task WriteTraceAsync(TraceEventType eventType, string message, Exception ex = null);

        Task WriteExceptionAsync(Exception ex, string message = null);
    }
}
