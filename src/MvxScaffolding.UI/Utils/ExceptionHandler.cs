using System;
using System.Windows;

namespace MvxScaffolding.UI.Utils
{
    public static class ExceptionHandler
    {
        public static void ShowErrorDialog(Exception ex)
        {
            var messageBoxText = $"There was an exception thrown when trying to run MvxScaffolding. Please log an issue on GitHub if the error persists.\n\nException Message: {ex.Message}\nException StackTrace:{ex.StackTrace}\n\nInner Exception Message: {ex.InnerException?.Message}\nInner Exception StackTrace:{ex.InnerException?.StackTrace}";
            var caption = "MvxScaffolding unhandled exception";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
