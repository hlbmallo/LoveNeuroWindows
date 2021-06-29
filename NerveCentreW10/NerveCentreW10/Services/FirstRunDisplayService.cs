using System;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.Helpers;

using NerveCentreW10.Views;
using Windows.Storage;
using Windows.UI.Xaml;

namespace NerveCentreW10.Services
{
    public static class FirstRunDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.Instance.IsFirstRun && !shown)
            {

                shown = true;
                var dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
