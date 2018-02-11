namespace MvxScaffolding.UI.Diagnostics.Trackers
{
    public static class TelemetryTrackerExtensions
    {
        public static string HasValue(this string value)
        {
            return (!string.IsNullOrWhiteSpace(value)).ToString();
        }
    }
}
