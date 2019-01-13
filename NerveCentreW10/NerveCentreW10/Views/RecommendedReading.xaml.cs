using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecommendedReading : Page
    {
        string intro = "The resources below were used when creating this app. They have been included here for academic integrity and to provide a useful recommended reading list.";
        string textbooks = "Crossman and Neary, Neuroanatomy.<br/><br/>Tortora and Derrickson, Principles of Anatomy & Physiology (13th Edition).<br/><br/>Drake, Vogl & Mitchell, Gray’s Anatomy for Students (2nd Edition).<br/><br/>Snell, Clinical Anatomy by Regions (9th Edition).<br/><br/>Ross and Wilson, Anatomy and Physiology in Health and Illness (8th Edition).";
        string generalweblinks = @"<a href =""http://www.neuroanatomy.wisc.edu"">University of Wisconsin-Madison Neuroscience Resources</a><br/><br/><a href =""http://radiopaedia.org/"">Radiopaedia</a><br/><br/><a href =""http://medcell.med.yale.edu/histology/nervous_system_lab.php"">Yale University, Nervous System Lab</a><br/><br/><a href =""http://neuroscience.uth.tmc.edu/"">University of Texas, Neuroscience Online</a><br/><br/><a href =""http://piclib.nhm.ac.uk/"">National History Museum Picture Library</a>";
        string cnsweblinks = @"<a href =""http://www.columbia.edu/cu/psychology/courses/1010/mangels/neuro/anatomy/structure.html"">University of Columbia - Overview of the Brain</a><br/><br/><a href =""http://www.napavalley.edu/people/briddell/documents/bio%20218/15_lecture_presentation.pdf"">Napa Valley College - Overview of the Spinal Cord</a><br/><br/><a href =""http://patient.info/health/cauda-equina-syndrome-leaflet"">University of Columbia - Overview of the Spinal Cord</a><br/><br/><a href =""http://www.as.wvu.edu/~rbrundage/chapter5a/sld014.htm"">West Virginia University College - Glial Cells</a><br/><br/><a href =""http://www.nature.com/ni/journal/v10/n5/fig_tab/ni0509-453_F1.html"">Nature - CSF and the Ventricles</a><br/><br/><a href =""http://scholarpedia.org/article/Episodic_memory"">Scholarpedia - Limbic System</a><br/><br/><a href =""http://cercor.oxfordjournals.org/content/10/3/205.full"">Oxford Journals - Limbic System</a>";
        string pnsweblinks = @"<a href =""http://www.emory.edu/ANATOMY/AnatomyManual/back.html"">Emory University - Spinal Nerves</a><br/><br/><a href =""http://anatomy.uams.edu/anatomyhtml/nerves_thorax.html"">University of Arkansas for Medical Sciences - Plexuses</a>";
        string disordersweblinks = @"<a href =""http://www.nhs.uk/conditions/dementia-guide/pages/about-dementia.aspx"">NHS Choices - Alzheimer's Disease</a><br/><br/><a href =""https://www.alzheimers.org.uk/"">Alzheimer's Society - Alzheimer's Disease</a><br/><br/><a href =""http://www.health.harvard.edu/mind-and-mood/what-causes-depression"">Harvard University - Depression</a><br/><br/><a href =""http://www.mssociety.org.uk/what-is-ms"">MS Society - Multiple Sclerosis</a><br/><br/><a href =""http://www.nature.com/nm/journal/v6/n11/fig_tab/nm1100_1208_F1.html?foxtrotcallback=true"">Nature Medicine - Huntington's Disease</a><br/><br/><a href =""http://www.compgene.com/hd.htm"">Compgene - Huntington's Disease</a><br/><br/><a href =""https://www.ncbi.nlm.nih.gov/pubmed/28753941"">International Journal of Molecular Sciences - Huntington's Disease</a><br/><br/><a href =""https://ghr.nlm.nih.gov/condition/huntington-disease#genes"">Genetics Home Reference - Huntington's Disease</a><br/><br/><a href =""https://www.alz.org/dementia/huntingtons-disease-symptoms.asp"">Alzheimer's Society - Huntington's Disease</a><br/><br/><a href =""http://neuroscience.uth.tmc.edu/s3/chapter06.html"">University of Texas Health Sciences Center at Houston - Huntington's Disease</a><br/><br/>";

        public RecommendedReading()
        {
            this.InitializeComponent();
        }
    }
}
