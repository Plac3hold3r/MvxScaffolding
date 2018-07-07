//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

namespace MvxScaffolding.Core.Extensions
{
    public static class GitHubDownloadExtensions
    {
        public static string AsRawUrl(this string url)
        {
            return $"{url}?raw=true";
        }
    }
}
