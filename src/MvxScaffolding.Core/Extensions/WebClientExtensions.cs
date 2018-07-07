//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Net;
using System.Threading.Tasks;
using MvxScaffolding.Core.Diagnostics;
using MvxScaffolding.Core.Tasks;

namespace MvxScaffolding.Core.Extensions
{
    public static class WebClientExtensions
    {
        public static async Task<string> SafeDownloadStringTaskAsync(this WebClient webClient, string url)
        {
            try
            {
                return await webClient.DownloadStringTaskAsync(url);
            }
            catch (Exception ex)
            {
                Logger.Current.Exception.TrackAsync(ex, $"Error downloading from: {url}")
                    .FireAndForget();

                return "";
            }
        }
    }
}
