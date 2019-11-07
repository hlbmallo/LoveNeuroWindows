using HeartCentreW104.Helpers;
using Microsoft.WindowsAzure.Storage.Blob;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.ViewModels
{
    public class VideoTutorialsViewModel
    {
        public ObservableCollection<VideoTutorialsClass> VideoTutorialsList { get; } = new ObservableCollection<VideoTutorialsClass>();

        public VideoTutorialsViewModel()
        {
            CloudClass cloudclass = new CloudClass();

            CloudBlobContainer container = new CloudBlobContainer(new Uri(cloudclass.GetContainerSasUri(cloudclass.MyCloudClass())));

            VideoTutorialsList.Add(new VideoTutorialsClass
            {
                VideoTutorialsPageId = "section71",
                VideoTutorialsName = "Alzheimer's Disease",
                VideoTutorialsDescription = "A video tutorial that focuses on the anatomy of the healthy brain, the pathology of Alzheimer's disease and current treatments.",
                VideoTutorialsThumbnail = container.GetBlockBlobReference("alzheimers.png").Uri,
                VideoTutorialsUrl = new Uri("https://www.youtube.com/embed/jZe5M0zLJUE?rel=0"),
            });
            VideoTutorialsList.Add(new VideoTutorialsClass
            {
                VideoTutorialsPageId = "section72",
                VideoTutorialsName = "HPA Axis",
                VideoTutorialsDescription = "A video tutorial that explains the anatomy and physiology of the hypothalamic-pituitary-adrenal (HPA) axis, using the CRH/ACTH/cortisol system as an example.",
                VideoTutorialsThumbnail = container.GetBlockBlobReference("hpaaxis.png").Uri,
                VideoTutorialsUrl = new Uri("https://www.youtube.com/embed/g9iGI5o_U-Y?rel=0"),
            });
            VideoTutorialsList.Add(new VideoTutorialsClass
            {
                VideoTutorialsPageId = "section73",
                VideoTutorialsName = "Spinal Cord",
                VideoTutorialsDescription = "A video tutorial that focuses on the anatomy of the spinal cord. Cord transections are discussed as relevant clinical connections.",
                VideoTutorialsThumbnail = container.GetBlockBlobReference("spinalnerves.png").Uri,
                VideoTutorialsUrl = new Uri("https://www.youtube.com/embed/5CTesOmOC58?rel=0"),
            });
            VideoTutorialsList.Add(new VideoTutorialsClass
            {
                VideoTutorialsPageId = "section74",
                VideoTutorialsName = "The Action Potential",
                VideoTutorialsDescription = "A video tutorial that explains the RMP, as well as the generation and conduction of an action potential. Local anaesthetics are discussed as a relevant clinical connection.",
                VideoTutorialsThumbnail = container.GetBlockBlobReference("ap5.png").Uri,
                VideoTutorialsUrl = new Uri("https://www.youtube.com/embed/wHJka2zp0ME"),
            });
        }
    }
}
