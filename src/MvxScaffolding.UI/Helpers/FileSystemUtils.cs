using System;
using System.IO;

namespace MvxScaffolding.UI.Helpers
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
                // TODO [JF] :: log exception
            }
        }
    }
}
