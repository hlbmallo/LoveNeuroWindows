﻿using HeartCentreW104.Helpers;
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
    public class InkingZoneViewModel
    {
        public ObservableCollection<InkingZoneClass> InkingZoneList { get; } = new ObservableCollection<InkingZoneClass>();

        public InkingZoneViewModel()
        {
            CloudClass cloudclass = new CloudClass();

            CloudBlobContainer container = new CloudBlobContainer(new Uri(cloudclass.GetContainerSasUri(cloudclass.MyCloudClass())));

            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Lateral Aspect of the Brain",
                InkingZoneImage = container.GetBlockBlobReference("LateralBrain4.png").Uri,
                InkingZoneDescription = "This diagram shows the lateral aspect of the brain. Features of note include:<ul><li>The four lobes of the cerebral cortex (frontal, parietal, occipital, temporal)</li><li>Cerebellum</li><li>Pons</li><li>Medulla oblongata</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Medial Aspect of the Brain",
                InkingZoneImage = container.GetBlockBlobReference("MedialBrain.png").Uri,
                InkingZoneDescription = "This diagram shows the medial aspect of the brain. Features of note include:<ul><li>The four lobes of the cerebral cortex (frontal, parietal, occipital, temporal)</li><li>Cerebellum</li><li>Brainstem (midbrain, pons, medulla oblongata)</li><li>Thalamus</li><li>Hypothalamus</li><li>Corpus callosum</li><li>Pituitary gland</li>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Basic Neuron",
                InkingZoneImage = container.GetBlockBlobReference("Neuron.png").Uri,
                InkingZoneDescription = "This diagram shows a typical multipolar neuron. Features of note include:<ul><li>Cell body</li><li>Axon</li><li>Nucleus</li><li>Dendrites</li><li>K+ and Na+ ion channels</li><li>Na+/K+ ATPase pump</li><li>Presynaptic terminal</li><li>Vesicles containing neurotransmitter</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Brachial Plexus",
                InkingZoneImage = container.GetBlockBlobReference("BrachialPlexus.png").Uri,
                InkingZoneDescription = "This diagram shows the brachial plexus and its main branches, including:<ul><li>Musculocutaneous nerve</li><li>Radial nerve</li><li>Ulnar nerve</li><li>Median nerve</li><li>Axillary nerve</li><li>Long thoracic nerve</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Circle of Willis",
                InkingZoneImage = container.GetBlockBlobReference("CircleOfWillis.png").Uri,
                InkingZoneDescription = "This diagram shows the circle of Willis at the base of the brain. Features of note include:<ul><li>1. Anterior cerebral artery</li><li>2. Anterior communicating artery</li><li>3. Internal carotid artery</li><li>4. Middle cerebral artery</li><li>5. Posterior communicating artery</li><li>6. Posterior cerebral artery</li><li>7. Superior cerebellar artery</li><li>8. Basilar artery</li><li>9. Pontine branch</li><li>10. Anterior inferior cerebellar artery</li><li>11. Posterior inferior cerebellar artery</li><li>12. Vertebral artery</li><li>13. Anterior spinal artery</li><li>14. Posterior spinal artery</li></ul><ul><li>A. Frontal lobe</li><li>B. Olfactory bulb</li><li>C. Optic chiasm</li><li>D. Temporal lobe</li><li>E. Midbrain</li><li>F. Mamillary bodies</li><li>G. Pons</li><li>H. Cerebellum</li><li>I. Medulla</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Spinal Cord Divisions",
                InkingZoneImage = container.GetBlockBlobReference("SpinalCordDivisions.png").Uri,
                InkingZoneDescription = "This diagram shows the divisions of the spinal cord. Features of note include:<ul><li>Medulla oblongata</li><li>Cervical division of the spinal cord</li><li>Thoracic division of the spinal cord</li><li>Lumbar division of the spinal cord</li><li>Sacral division of the spinal cord</li><li>Coccygeal division of the spinal cord</li><li>Vertebral column (specifically, vertebral bodies and spinous processes)</li><li>Spinal cord proper</li><li>Conus medullaris</li><li>Cauda equina</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Cerebral Cortex",
                InkingZoneImage = container.GetBlockBlobReference("CerebralCortex.png").Uri,
                InkingZoneDescription = "This diagram shows the main functional areas of the cerebral cortex. Features of note include:<ul><li>Primary motor cortex (precentral gyrus)</li><li>Central sulcus</li><li>Primary somatosensory cortex (postcentral gyrus)</li><li>Sensory association cortex</li><li>Primary visual cortex</li><li>Visual association cortex</li><li>Wernicke's area</li><li>Primary auditory cortex</li><li>Temporal gyri (superior, middle and inferior)</li><li>Lateral sulcus</li><li>Broca's area</li><li>Prefrontal cortex</li><li>Premotor cortex</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Synapse",
                InkingZoneImage = container.GetBlockBlobReference("Synapse.png").Uri,
                InkingZoneDescription = "This diagram shows a typical synapse. Features of note include:<ul><li>Presynaptic neuron</li><li>Postsynaptic neuron</li><li>Presynaptic terminal</li><li>Vesicles (containing neurotransmitter molecules)</li><li>Calcium ion channels and calcium ions</li><li>Synaptic cleft</li><li>Neurotransmitter receptors</li><li>Sodium ion channels and sodium ions</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Ventricles of the Brain",
                InkingZoneImage = container.GetBlockBlobReference("Ventricles.png").Uri,
                InkingZoneDescription = "This diagram shows the ventricles of the brain. Features of note include:<ul><li>Lateral ventricles (left and right)</li><li>Interventricular foramen</li><li>Third ventricle</li><li>Cerebral aqueduct</li><li>Fourth ventricle</li><li>Central canal of the spinal cord</li><li>Lateral apertures (left and right)</li><li>Median aperture</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClass
            {
                InkingZoneTitle = "Spinal Tracts Matching Exercise",
                InkingZoneImage = container.GetBlockBlobReference("MatchingExercise.png").Uri,
                InkingZoneDescription = "This diagram shows the spinal tracts. Try matching the tract names with their functions.",
            });
        }
    }
}