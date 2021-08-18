using LoveNeuroWinUI3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LoveNeuroWinUI3.Views
{
    public sealed partial class NeuroDictionary : Page
    {
        private ObservableCollection<NeuroDictionaryModel> NeuroDictionaryModelList = new ObservableCollection<NeuroDictionaryModel>();

        public NeuroDictionary()
        {
            this.InitializeComponent();
            populatedata();
        }

        void populatedata()
        {
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "A",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Acetylcholine",
                Definition = "An excitatory neurotransmitter. Neurons that use acetylcholine are affected during the course of multiple sclerosis.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Action potential",
                Definition = "An electrical impulse. This involves Na+ ions rushing into and depolarising the neuron.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Adenoma",
                Definition = "A tumour that grows on the pituitary gland. Adenomas can be classified as functional or non-functional. ",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Afferent neuron ",
                Definition = "Another term for a sensory neuron, i.e. a neuron that carries sensation (e.g. touch, pressure, temperature, pain, stretch) to the brain.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Amygdala",
                Definition = "Part of the cerebrum that is essential for regulating our instinctive motivational behaviours such as fear, anger, hunger and sexual arousal.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Apertures",
                Definition = "Holes in the fourth ventricle that allow CSF to flow into the subarachnoid space. There are three apertures: two lateral apertures and one median aperture.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Aphasia",
                Definition = "A disorder where a person finds it difficult to communicate. Two examples are Broca's aphasia (difficulty in speaking/writing) and Wernicke's aphasia (difficulty in understanding the spoken/written word).",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Arachnoid mater",
                Definition = "The thin middle layer of the meninges. Below this layer there is an actual space through which cerebrospinal fluid moves (i.e. the subarachnoid space).",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Arachnoid villi",
                Definition = "Portions of the arachnoid mater that project into the dural venous sinuses. This facilitates the flow of CSF into the blood, thereby ensuring CSF does not build up within the ventricular system.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Association cortices",
                Definition = "Parts of the cerebral cortex that assist the primary cortical regions in their processing of more complex tasks. For example, the premotor cortex is the association cortex of the primary motor cortex, and it prepares the body for movement and postural changes.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Association tracts",
                Definition = "Groups of myelinated neurons (white matter) that connect different areas of grey matter contained in the same cerebral hemisphere.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Astrocyte",
                Definition = "The most common glial cell in the brain. Astrocytes maintain the blood-brain barrier, regulate the homeostasis of neurons, maintain synapses and respond to brain damage by taking part in gliosis.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "ATPase pump",
                Definition = "The sodium-potassium ATPase pump uses ATP (energy) to move 3 Na+ out of a neuron and 2 K+ ions into the neuron, and thereby restoring and maintaining the resting membrane potential of a neuron.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Autonomic Nervous System (ANS)",
                Definition = "The functional division of the nervous system that is involuntary (e.g. vasoconstriction, sweat, glands).",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Axon",
                Definition = "The long, thin tube-like part of the neuron that conducts action potentials by allowing the entry and exit of ions into and out of it.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "B",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Basal ganglia",
                Definition = "A group of subcortical structures that are involved in voluntary movement. Dying neurons in the basal ganglia is seen during Parkinson's disease.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Bipolar neuron",
                Definition = "A type of neuron that has two axonal projections; one projection enters the cell body and the other projection leaves the cell body.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Brachial plexus",
                Definition = "The network of nerves in the neck and shoulder that provides all of the sensory and motor innervation to the upper limb.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Brainstem",
                Definition = "Part of the brain consisting of the medulla, pons and midbrain. It contains important cardiac and respiratory regulatory centres, which are responsible for the heart and breathing rates.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "C",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Calcium ion, Ca2+",
                Definition = "The main ion responsible for stimulating neurotransmitter-containing vesicles to migrate towards the presynaptic membrane and spill their contents into the synapse. The Ca2+ ion channels in the presynaptic terminal are voltage-gated.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cauda equina",
                Definition = "The leash of spinal nerves that sits in the subarachnoid space in the vertebral column. Each spinal nerve branches off at its associated vertebra, e.g. S3 spinal nerves leave the subarachnoid space at the level of the S3 vertebra.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cell body",
                Definition = "The nucleus and DNA-containing processing centre of the neuron.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Central Nervous System",
                Definition = "The structural division of the nervous system that consists of the brain, spinal cord and retina.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cerebellum",
                Definition = "Part of the hindbrain that is responsible for walking, coordination and balance.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cerberal aqueduct",
                Definition = "The thin tube that connects the third and fourth ventricles, allowing the flow of CSF.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cerebrospinal fluid (CSF)",
                Definition = "A clear fluid that flows in the subarachnoid space. It gives buoyancy to the brain and acts as a shock-absorber if the head is dealt a blow.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cerebrum",
                Definition = "The largest part of the forebrain, divided into right and left hemispheres. These hemispheres consist of the cerebral cortex and some subcortical structures, such as the hippomcapus and basal ganglia.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Circle of Willis",
                Definition = "The anastomotic circle of arteries that lies at the base of the brain.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Commissural tracts",
                Definition = "Groups of myelinated neurons (white matter) that connect areas of grey matter in one cerebral hemisphere with the same area in the opposite cerebral hemisphere.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cortex (cerebral)",
                Definition = "The outermost layer of grey matter of each cerebral hemisphere. It is divided into lobes called the frontal lobe, parietal area, temporal area and occipital area. The cerebral cortex is much more developed in the human brain compared to the brains of our primate relatives.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Cortisol",
                Definition = "A stress hormone that, when secreted, increases blood pressure and blood glucose, regulates pH and reduces inflammation.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Cranial nerve",
                Definition = "These are peripheral nerves that provide sensory and motor innervation to the head and neck.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "D",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Dendrite",
                Definition = "A spiky projection with many branches that receives electrical impulses from other neurons.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Depolarisation",
                Definition = "The process by which the inside of a neuron becomes positive; caused by the influx of Na+ ions. This is the first stage in an action potential.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Diencephalon",
                Definition = "Part of the forebrain that consists of the thalamus and hypothalamus. The thalamus is a relay centre and the hypothalamus is a neuroendocrine regulatory centre.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Dura mater",
                Definition = "The outermost and toughest layer of the meninges. It is composed of two sub-layers: the endosteal layer and the meningeal layer.",
            });

            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "E",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Effector",
                Definition = "Another term for a muscle or gland that receives a motor neuron. The effector puts an action, such as contraction or secretion, into 'effect'.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Efferent neuron",
                Definition = "Another term for a motor neuron, i.e. a neuron that carries action potentials to muscles (or other structures such as glands) to allow them to contract.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Ependymal cells",
                Definition = "A glial cell in the CNS that helps to produce and move CSF throughout the ventricular system.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Excitatory neurotransmitter",
                Definition = "A neurotransmitter than stimulates the production of an action potential in the postsynaptic neuron by opening Na+ ion channels. An example is the neurotransmitter glutamate.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "F",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Fissure",
                Definition = "A large dip between large areas of the cerebrum.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Falx cerebri",
                Definition = "The longitudinal fold of meningeal dura mater that runs in-between the two cerebral hemispheres.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Forebrain",
                Definition = "The most rostral area of the brain that consists of the cerebral cortex, subcortical structures, commissures and the diencephalon.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "G",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Glia",
                Definition = "Non-electrical cells in the central nervous system that provide structural support and protection to neurons.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Grey matter",
                Definition = "The location of the nerve cell bodies in the spinal cord and the main processing centres in the brain.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Gyrus",
                Definition = "A raised ridge of the cerebral cortex that often contains a centre or centres that are associated with certain motor or sensory functions.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "H",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Hindbrain",
                Definition = "The most caudal area of the brain that consists of the medulla, pons and cerebellum.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Hippocampus",
                Definition = "Part of the cerebral cortex responsible for the formation and consolidation of episodic memory, i.e. events that we have personally experienced.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "HPA axis",
                Definition = "An abbreivation for the hypothalamic-pituitary adrenal axis. This axis is a circuit that uses hormones to regulate the homeostatic state of the body.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Hyperpolarisation",
                Definition = "The short process during which the inside of a neuron temporarily becomes excessively negative. It is caused by too many K+ ions flooding out of the neuron. The membrane potential can reach -90mV during repolarisation.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Hypothalamus",
                Definition = "Part of the diencephalon that is largely responsible for regulating the body's hormones and thus homeostatic state. For example, body temperature, thyroid hormones and hunger are, in part, regulated by the hypothalamus.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "I",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Inhibitory neurotransmitter",
                Definition = "A neurotransmitter that inhibits an action potential from arising in the postsynaptic neuron by opening Cl- or K+ ion channels. An example is the neurotransmitter GABA.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Interneuron",
                Definition = "A type of connecting and processing neuron that exists in the spinal cord or brain. In reflex arcs, these exist in the spinal cord and quickly connect the sensory and motor neurons.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Ion channel",
                Definition = "A protein in the neuronal membrane that allows passive diffusion of ions into or out of the neuron, e.g. Na+ and K+ ion channels.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Ion pump",
                Definition = "A protein in the neuronal membrane that actively moves ions into or out of the neuron using ATP for energy, e.g. Na+/K+ ATPase pump.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "M",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Microglia",
                Definition = "A glial cell that is essentially the macrophage of the brain. It clears up debris and damaged neurons, and takes part in gliosis.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Midbrain",
                Definition = "The small middle area of the brain that consists of the midbrain. It is concerned with walking and eye reflexes.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Motor neuron",
                Definition = "A neuron that carries action potentials to muscles and glands, so that they can effect a response, i.e. contract or secrete.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Multipolar neuron",
                Definition = "A type of neuron that has three or more dendrites/axons projecting into it.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Myelin",
                Definition = "The insulating membrane of Schwann cells and oligodendrocytes that wraps around neuronal axons. It speeds up the transmission of action potentials by making them ‘jump’ along the neuron at the nodes of Ranvier.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "N",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Negatively-charged proteins",
                Definition = "Large, insoluble proteins that cannot diffuse out of a neuron. They help to maintain the negative resting membrane potential by remaining inside the neuron.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Nerve",
                Definition = "A bundle of neurons with connective tissue in-between them.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Neuromuscular junction",
                Definition = "A unique type of synapse that ensures an action potential in a motor neuron is communicated, by neurotransmitters, to a skeletal muscle, thereby allowing the muscle to contract.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Neuron",
                Definition = "The main nervous system cell that is electrically excitable. They can be classed as: sensory/motor, somatic/autonomic and general/special.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Neurotransmitter",
                Definition = "A chemical messenger that moves across a synapse, allowing two neurons to communicate.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Nodes of Ranvier",
                Definition = "Gaps between myelin sheaths with ion channels and pumps. Action potentials 'jump' between nodes of Ranvier, as this is quicker than a wave of ion movements along the entire axon.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "O",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Olfaction",
                Definition = "The sense of smell.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Oligodendocyte",
                Definition = "A glial cell in the CNS tha myelinates 5 - 8 neurons, ensuring action potentials are conducted rapidly.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "P",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Peripheral Nervous System (PNS)",
                Definition = "The structural division of the nervous system that consists of the 12 pairs of cranial nerves and 31 pairs of spinal nerves.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Pia mater",
                Definition = "The thin innermost layer of the meninges that is adhered to the brain matter.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Pituitary gland",
                Definition = "A pea-sized gland that is part of the diencephalon, the pituitary gland is responsible for producing and releasing hormones into the systemic (body-wide) circulation.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Plexus",
                Definition = "A network of nerves in the body where neurons are redistributed. These are classed as either somatic or autonomic/visceral.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Potassium ion, K+",
                Definition = "The main ion responsible for the restoration and maintenance of the resting membrane potential.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Presynaptic terminal / presynaptic knob",
                Definition = "The end of a neuron where neurotransmitter molecules are stored in vesicles. The neurotransmitter molecules will be released into a synapse to communicate with other neurons.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Projection tracts",
                Definition = "Groups of myelinated neurons (white matter) that connect areas of grey matter in the cerebrum with lower areas of the brain, such as the thalamus and brainstem.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "R",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Radial glial cells",
                Definition = "A glial cell that acts as a scaffold for newborn neurons to migrate along during development.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Reflex arc",
                Definition = "A path of only a few neurons that passes through the spinal cord and allows us to react involuntarily to potentially dangerous stimuli.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Repolarisation",
                Definition = "The process during which the resting membrane potential of a cell (-70mV) is re-established. Repolarisation occurs after hyperpolarisation and involves the redistribution of the Na+ and K+ ions by the Na+/K+ ATPase pump.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Resting membrane potential (RMP)",
                Definition = "The voltage difference across the neuronal membrane when no action potential is being conducted. This is normally -70mV, meaning the cell is -70mV more negative inside the cell compared to outside the cell. At the RMP, there is a high concentration of Na+ ions outside the neuron and a high concentration of K+ ions inside the cell.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "S",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Sarcolemma",
                Definition = "The membrane surrounding a muscle fibre.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Sarcoplasmic reticulum",
                Definition = "An internal cellular structure of muscle fibres that holds Ca2+ ions. When these Ca2+ ions are released to the myofibrils, they will enable a muscle contraction to occur.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Schwann cells",
                Definition = "Cells in the periheral nervous system that produce myelin sheaths for axons.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Sciatic nerve",
                Definition = "The main nerve in the lower limb. It runs posterior to the femur and has a root value of L4 – S3.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Sensory neuron",
                Definition = "A neuron that carries sensory information, such as pressure, fine touch, pain and temperature, to the spinal cord and/or brain.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Serotonin",
                Definition = "An inhibitory neurotransmitter.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Sodium ion, Na+",
                Definition = "The main ion responsible for depolarising a neuron during an action potential.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Soma",
                Definition = "Another term for the cell body of a neuron.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Somatic Nervous System (SNS)",
                Definition = "The functional division of the nervous system that is under voluntary control.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Word = "Spinal arteries",
                Definition = "Three arteries (one anterior and two posterior) that supply much of the spinal cord with blood.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Spinal cord proper",
                Definition = "The main, tube-like portion of the spinal cord that extends from the medulla to L1/L2.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Spinal nerve",
                Definition = "A nerve that leaves/enters the spinal cord from a particular spinal segment.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Spinal segment",
                Definition = "A section of the spinal cord that is associated with a vertebra and gives rise to two spinal nerves. For example, the T3 spinal segment lies below the T3 vertebrae and gives rise to two spinal nerves.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Stimulus",
                Definition = "An event or object that elicits a nervous system response when we experience it or come into contact with it.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Sulci",
                Definition = "The shallow dips in-between the gyri of the cerebrum.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Synapse",
                Definition = "The gap between two neurons. Many are chemical in nature, i.e. a neurotransmitter is released into the synapse to allow two neurons to communicate. The space between the two neurons is specifically called the synaptic cleft.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "T",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Tentorium cerebelli",
                Definition = "The horizontal/transverse fold of meningeal dura mater that runs in-between the cerebral hemispheres and the cerebellar hemispheres.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Threshold value",
                Definition = "The value at which a slow influx of Na+ ions into the neuro becomes a rapid influx of ions during the early stages of an action potential. The threshold value of Na+ ions is -55mV.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Tract",
                Definition = "A group of neurons in the CNS or PNS responsible for the same or similar functions, e.g. the spinothalamic tract contains neurons that carry pain and temperature sensations from the PNS to the CNS.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "T-tubules",
                Definition = "T-tubules, or transverse tubules, are tubes that run deep through a muscle fibre, carrying the action potential to the sarcoplasmic reticulum.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "U",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Unipolar neuron",
                Definition = "A neuron in which the cell body is attached to the rest of the neuron by only one axon.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "V",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Ventricles",
                Definition = "Large CSF-containing spaces within the brain. There are four ventricles: two lateral ventricles in the cerebral hemispheres, the third ventricle between the thalamus and the fourth ventricle lying ventral to the cerebellum.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "Voltage-gated ion channel",
                Definition = "An ion channel that is opened only when an action potential passes through it.",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "W",
                Word = "",
                Definition = "",
            });
            NeuroDictionaryModelList.Add(new NeuroDictionaryModel
            {
                Letter = "",
                Word = "White matter",
                Definition = "The myelinated axons of neurons. In the brain, these connect areas of grey matter.",
            });

            MyDictionaryListView.ItemsSource = NeuroDictionaryModelList;
        }

    }
}
