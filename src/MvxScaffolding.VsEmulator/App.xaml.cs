//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace MvxScaffolding.VsEmulator
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            var testCuluture = new CultureInfo("en-ZA");
            Thread.CurrentThread.CurrentCulture = testCuluture;
            Thread.CurrentThread.CurrentUICulture = testCuluture;

            base.OnStartup(e);
        }

        [SuppressMessage("Major Code Smell",
            "S3885:\"Assembly.Load\" should be used",
            Justification = "Required to load assembly via file path",
            Scope = "member",
            Target = "~M:MvxScaffolding.VsEmulator.App.CurrentDomain_AssemblyResolve(System.Object,System.ResolveEventArgs)~System.Reflection.Assembly")]
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.ToUpper().StartsWith("MATERIALDESIGNTHEMES.WPF") || args.Name.ToUpper().StartsWith("MARKDIG.WPF"))
            {
                var asmLocation = Assembly.GetExecutingAssembly().Location;
                var debugDirectory = Path.GetDirectoryName(asmLocation);

                var asmName = args.Name.Substring(0, args.Name.IndexOf(','));
                var filename = Path.Combine(debugDirectory, asmName + ".dll");

                if (File.Exists(filename))
                {
                    return Assembly.LoadFrom(filename);
                }
            }

            return null;
        }
    }
}
