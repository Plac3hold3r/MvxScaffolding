//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.IO;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Tasks;

namespace MvxScaffolding.Core.Files
{
    public static class FileSystemUtils
    {
        public static FileDeleteStatus SafeDeleteDirectory(string dir)
        {
            try
            {
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }

                return FileDeleteStatus.Success;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Current.Info.TrackAsync("Unauthorized access to deleting directory", ex)
                    .FireAndForget();

                return FileDeleteStatus.UnauthorizedAccessError;
            }
            catch (Exception ex)
            {
                Logger.Current.Exception.TrackAsync(ex, "Error deleting directory")
                    .FireAndForget();

                return FileDeleteStatus.Error;
            }
        }
    }
}
