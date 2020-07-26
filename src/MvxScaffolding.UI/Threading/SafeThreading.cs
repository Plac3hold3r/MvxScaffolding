//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Threading;

namespace MvxScaffolding.UI.Threading
{
    public static class SafeThreading
    {
        public static JoinableTaskFactory JoinableTaskFactory { get; set; }

        static SafeThreading()
        {
            try
            {
                JoinableTaskFactory = ThreadHelper.JoinableTaskFactory;
            }
            catch (NullReferenceException)
            {
#pragma warning disable VSSDK005 // Avoid instantiating JoinableTaskContext
                var context = new JoinableTaskContext(System.Threading.Thread.CurrentThread);
#pragma warning restore VSSDK005 // Avoid instantiating JoinableTaskContext
                JoinableTaskCollection collection = context.CreateCollection();
                JoinableTaskFactory = context.CreateFactory(collection);
            }
        }
    }
}
