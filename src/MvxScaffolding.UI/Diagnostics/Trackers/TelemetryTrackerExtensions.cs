//---------------------------------------------------------------------------------
// Copyright (c) 2018 Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

namespace MvxScaffolding.UI.Diagnostics.Trackers
{
    public static class TelemetryTrackerExtensions
    {
        public static string HasValue(this string value)
        {
            return (!string.IsNullOrWhiteSpace(value)).ToString().ToLowerInvariant();
        }

        public static string ToStringLowerCase(this bool value)
        {
            return value.ToString().ToLowerInvariant();
        }
    }
}
