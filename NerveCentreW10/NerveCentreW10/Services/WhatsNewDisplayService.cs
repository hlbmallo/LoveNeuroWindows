using System;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.Helpers;

using NerveCentreW10.Views;
using Windows.Storage;

namespace NerveCentreW10.Services
{
    // For instructions on testing this service see https://github.com/Microsoft/WindowsTemplateStudio/tree/master/docs/features/whats-new-prompt.md
    public static class WhatsNewDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsAppUpdated && !shown)
            {
                shown = true;
                var dialog = new WhatsNewDialog();
                await dialog.ShowAsync();

                StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("FavouritesFolder", CreationCollisionOption.OpenIfExists);
                await appFolder.DeleteAsync();

            }
        }
    }
}
