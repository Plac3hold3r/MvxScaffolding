using System;
using System.IO;
using MvxScaffolding.UI.Diagnostics;

namespace MvxScaffolding.UI.Files
{
    public static class FileSystemUtils
    {
        public static void SafeDeleteDirectory(string dir)
        {
            try
            {
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Exception.TrackAsync(ex, "Error deleting directory").FireAndForget();
            }
        }
    }
}
