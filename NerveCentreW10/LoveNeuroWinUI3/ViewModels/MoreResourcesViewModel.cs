using LoveNeuroWinUI3.Models;
using System;
using System.Collections.ObjectModel;
namespace LoveNeuroWinUI3.ViewModels
{
    public class MoreResourcesViewModel
    {
        public ObservableCollection<MoreResourcesClass> MoreResourcesList { get; } = new ObservableCollection<MoreResourcesClass>();

        public MoreResourcesViewModel()
        {
            MoreResourcesList.Add(new MoreResourcesClass
            {
                MoreResourcesName = "Thorax Anatomy App",
                MoreResourcesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconTGA.png")),
                MoreResourcesLinkOut1 = new Uri("ms-windows-store://pdp/?ProductId=9wzdncrcs92r"),
                MoreResourcesLinkOut2 = new Uri("ms-windows-store://pdp/?ProductId=9wzdncrcs92r"),
            });
            MoreResourcesList.Add(new MoreResourcesClass
            {
                MoreResourcesName = "The Goofy Anatomist Website",
                MoreResourcesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconTGA.png")),
                MoreResourcesLinkOut1 = new Uri("https://thegoofyanatomist.com/"),
                MoreResourcesLinkOut2 = new Uri("https://thegoofyanatomist.com/"),
            });
            //MoreResourcesList.Add(new MoreResourcesClass
            //{
            //    MoreResourcesName = "Facebook (@thegoofyanatomist)",
            //    MoreResourcesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconFB.png")),
            //    //MoreResourcesLinkOut1 = new Uri("fb://profile/291588604660331"),
            //    MoreResourcesLinkOut1 = new Uri("https://www.facebook.com/thegoofyanatomist/"),
            //    MoreResourcesLinkOut2 = new Uri("https://www.facebook.com/thegoofyanatomist/"),
            //});
            MoreResourcesList.Add(new MoreResourcesClass
            {
                MoreResourcesName = "Twitter (@goofy_anatomist)",
                MoreResourcesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconTwitter.png")),
                //MoreResourcesLinkOut1 = new Uri("Twitter:profile?username=@goofy_anatomist"),
                MoreResourcesLinkOut1 = new Uri("https://twitter.com/goofy_anatomist"),
                MoreResourcesLinkOut2 = new Uri("https://twitter.com/goofy_anatomist"),
            });
        }
    }
}
