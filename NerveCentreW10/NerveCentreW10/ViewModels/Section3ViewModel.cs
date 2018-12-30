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
    public class Section3ViewModel
    {
        public ObservableCollection<SubsectionModel> SubsectionList { get; } = new ObservableCollection<SubsectionModel>();

        public Section3ViewModel()
        {
            CloudClass cloudclass = new CloudClass();

            CloudBlobContainer container = new CloudBlobContainer(new Uri(cloudclass.GetContainerSasUri(cloudclass.MyCloudClass())));

            SubsectionList.Add(new SubsectionModel
            {
                PageId = "Section31",
                Title = "3.1. Spinal Nerves",
                Subtitle1 = "Spinal Nerves",
                Description1 = "Let’s begin by looking at spinal nerves, and defining what they are. A spinal nerve is formed by the sensory and motor neurons that enter and leave the spinal cord. These neurons are part of the somatic nervous system, but neurons from the autonomic nervous system can also travel in spinal nerves (the autonomic nervous system is essentially made up of the sympathetic and parasympathetic divisions – more on this later). Every spinal nerve is associated with a dermatome and a myotome (see below for more info).<br/><br/>Consider the following example at the vertebral level of T3. There are sensory neurons coming from the upper chest, carrying information like touch, pressure and temperature, and eventually these neurons travel together in a close bundle called the ventral (or anterior) 'ramus'. The nerves coming from the back eventually travel together in the dorsal (or posterior) ramus. These two 'rami' eventually join together and are then called a 'spinal nerve'. The spinal nerve then divides again and the sensory neurons enter the spinal cord via the dorsal root. Processing occurs in the spinal cord/brain. Motor fibres then leave the spinal cord via the ventral root. They also enter the spinal nerve and are then distributed via the dorsal and ventral rami. Sound confusing? Put simply, a spinal nerve is formed shortly after neurons enter/leave the spinal, and a spinal nerve can have sensory, motor and autonomic neurons inside it. Take a look at the Figure 3.1.1 for more info.",
                Subtitle2 = "Spinal Segments",
                Description2 = "A spinal segment is an area of the spinal cord proper that gives rise to two spinal nerves. For example, the T3 spinal segment gives rise to two spinal nerves that will provide sensory innervation to a band of skin on the chest and motor innervation to the third intercostal muscles (these muscles that lie in-between the ribs). The spinal nerves might also contain autonomic fibres. It is important to realise that spinal nerves and their branches provide sensory and motor innervation to skin and muscles that are far away. For example, the lumbar and sacral spinal segments will give rise to spinal nerves that provide innervation as far down as the feet.",
                Subtitle3 = "Dermatomes and Myotomes",
                Description3 = "As has already been alluded to, a dermatome is the area of skin supplied by a single spinal segment and its associated spinal nerve. For example, the T10 dermatome extends horizontally around the abdomen, from front-to-back, at the level of the umbilicus. All of the skin in this region, which is about 1 inch in height, conveys its sensory information to the brain via the spinal nerves of the T10 spinal segment.<br/><br/>A myotome is the group of muscles that is innervated by the spinal nerve of a spinal segment. For example, the myotome of the C5 spinal segment/spinal nerve includes the muscles of the upper arm (biceps brachii), shoulder region (deltoid, infraspinatus, supraspinatus) and the forearm (brachioradialis). It’s important to realise that, in this example, although these muscles are part of the C5 myotome, some are also part of the C6 myotome – C5 and C6 together form the musculocutaneous nerve which supplies the muscles of the upper arm.",
                ImageUri1 = container.GetBlockBlobReference("spinalnerves.png").Uri,
                ImageUri2 = null,

                Popup1Title = "Clinical Note: Cord Damage",
                Popup1Content = "As was mentioned in a previous Clinical Note, the effects of spinal cord damage is dependent on the location of the damage.If the spinal cord is damaged at, say, C5, the C5 spinal segment and all those segments below it will be affected.This means that dermatomes and myotomes will also not function properly. If a myotome cannot function at all, the individual will not be able to move their muscles. If a dermatome cannot function properly, the individual will not be able to sense anything from that area. Note that the C3, C4 and C5 spinal segment are responsible for breathing (because they give rise to the phrenic nerve that supplies the muscular diaphragm). Breathing will be severely affected if these spinal segments are damaged.",
                Popup2Title = "Revision Note: Confused?",
                Popup2Content = "It's easy to get confused with all of the terms on this page, so let's clarify everything here. The spinal cord proper has lots of spinal segments. A spinal segment is an area of the spinal cord proper that gives rise to two spinal nerves (one left and one right). A spinal segment is also classified as either cervical, thoracic, lumbar, sacral or coccygeal, along with a number depending on its position. A spinal nerve is a mixed nerve formed by the sensory, motor and autonomic fibres of the nervous system that arises from a particular spinal segment. Spinal segments and therefore spinal nerves give rise to dermatomes and myotomes.",
                Popup3Title = null,
                Popup3Content = null,
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "Section32",
                Title = "3.2. Cranial Nerves",
                Subtitle1 = "What is a Cranial Nerve?",
                Description1 = "Welcome to the pinnacle of anatomy – the cranial nerves! The cranial nerves are peripheral nerves that largely supply the head and neck with various sensory and motor functions. These nerves have different characteristics; they can be sensory or motor in function, and general or special in nature. Many nerve fibres in the head and neck are autonomic – these regulate the vast number of glands, mucus membranes and smooth muscle fibres that are present there. The nerve fibres emerge directly from the brainstem and generally travel a very short distance to their targets. There are 12 cranial nerves. Their nerve fibre types and functions are listed below and you can see the 12 cranial nerves labelled on the brainstem in Figure 3.2.1.",
                Subtitle2 = "The 12 Cranial Nerves",
                Description2 = "<b>1. Olfactory Nerve</b><br/>Contains special sensory neurons.This nerve detects smell using nerve endings in the roof of the nasal cavity.<br/><br/><b>2. Optic Nerve</b><br/>Contains special sensory neurons. This nerve detects light using nerve endings at the front of the retina in the eye.As the nerves on each side travel to the cerebrum, they partially cross (also called 'decussate') at a structure called the optic chiasm.This means that the left side of the cerebrum is responsible for processing the right visual fields.<br/><br/><b>3. Oculomotor Nerve</b><br/>Contains general motor neurons. This nerve provides motor innervation to four of the six 'extraocular muscles' which move the eyeball in the eye socket.<br/><br/><b>4. Trochlear Nerve</b><br/>Contains general motor neurons. This nerve provides motor innervation to one of the six 'extraocular muscles', called the superior oblique muscle.<br/><br/><b>5. Trigeminal Nerve</b><br/>Contains general sensory neurons. This nerve carries sensory information from the anterior and lateral sides of the face. The fibres detect pain, temperature, touch and pressure.This nerve also contains special motor neurons – these fibres provide motor control to the muscle of mastication (i.e.the four main muscles involved in chewing). These muscles have a special 'visceral' embryological origin.<br/><br/><b>6. Abducent nerve (also called 'abducens')</b><br/>Contains general motor neurons.This nerve provides motor innervation to one of the six 'extraocular muscles', called the lateral rectus muscle.<br/><br/><b>7. Facial nerve</b><br/>Contains special motor neurons. This nerve provides motor control to the muscles of facial expression. These muscles also have a special 'visceral' embryological origin. This nerve also contains general motor neurons – these provide motor control to the lacrimal (eye) and certain salivary (mouth) glands. This nerve also contains special sensory neurons, that receive sensory information from the anterior two thirds of the tongue (i.e. the main, flat surface of the tongue that comes into contact with food during chewing).<br/><br/><b>8. Vestibulocochlear nerve</b><br/>Contains special sensory neurons. This nerve receives sound information via the cochlea. It also receives balance/position information from the semilunar canals.<br/><br/><b>9. Glossopharyngeal nerve</b><br/>Contains special motor neurons. This nerve provides motor innervation to the pharyngeal muscles. It also contains general visceral motor neurons that provide motor control to one of the salivary glands, called the parotid gland. This nerve also contains special sensory neurons – these receive taste information from the posterior third of the tongue (i.e. the part that lies vertically).<br/><br/><b>10. Vagus nerve</b><br/>Contains general sensory neurons. This nerve receives sensory information from the thoracic and abdominal organs. It also contains general motor neurons – provide motor innervation to the thoracic and abdominal organs.<br/><br/><b>11. Spinal accessory nerve</b><br/>Contains special motor neurons. This nerve provides motor control to muscles of the neck.<br/><br/><b>12. Hypoglossal nerve</b><br/>Contains general motor neurons. This nerve provides motor control to most of the muscles of tongue.",
                Subtitle3 = "Summary",
                Description3 = "Cranial nerves 3, 4, 6 and 12 are purely motor nerves.<br/>Cranial nerves 1, 2 and 8 are purely sensory nerves.<br/>Cranial nerves 5, 7, 9, 10 and 11 are mixed (i.e. motor and sensory).",
                ImageUri1 = container.GetBlockBlobReference("cranialnerves.png").Uri,
                ImageUri2 = null,

                Popup1Title = "Clinical Note: CN Examination",
                Popup1Content = "A cranial nerve examination is a physical examintion performed on a patient by a clinician to determine if there are any problems with the functioning of the patient's cranial nerves. This test involves asking the patient to open their jaw against resistance (CN5), make various facial expressions (CN7) and stick their tongue out (CN12), among other physical tests.",
                Popup2Title = "Revision Note: Mnemonics",
                Popup2Content = "Here's a mnemonic to remember the names of the cranial nerves in order...Ooh, Ooh, Ooh To Touch And Feel Very Good Velvet. Such Heaven!",
                Popup3Title = null,
                Popup3Content = null,
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "Section33",
                Title = "3.3. Plexuses",
                Subtitle1 = "What is a Plexus?",
                Description1 = "Both spinal and cranial nerves form plexuses in the peripheral nervous system. A plexus is simply a network of somatic or autonomic nerves. Within this network, neurons are redistributed to create new peripheral nerves. Note that there are no synapses in peripheral plexuses. Plexuses are normally classified based on the type of neurons they contain, i.e. they are either somatic or autonomic. There a number of important plexuses in the different anatomical regions of the body; these are described below and shown in Figure 3.3.1.",
                Subtitle2 = "Important Somatic Plexuses",
                Description2 = "Note: these plexuses are present on both sides of the body.<br/><br/><b>Cervical plexus</b><br/>Originates from the anterior rami of C1 - C4. It is located in the lateral parts of the upper and middle neck and supplies the skin and muscles there.<br/><br/><b>Brachial Plexus</b><br/>Originates from the anterior rami of C5 - T1. It is located in the root of the neck, shoulder and upper arm. This will be the source of all the nerves in the upper limb. The brachial plexus and its major terminal nerve branches are displayed in the diagram above.<br/><br/><b>Lumbar plexus</b><br/>Originates from the anterior rami of L1 - L4. It is located in the lower posterior abdominal region, at the lumbar level.<br/><br/><b>Sacral plexus</b><br/>Originates from the anterior rami of S1 - S4. It is located in the lower posterior pelvic region. The lumbar and sacral plexuses supply nerves to the pelvis and lower limbs.",
                Subtitle3 = "Important Autonomic Plexuses",
                Description3 = "<b>Cardiac plexus</b><br/>The cardiac plexus has superficial and deep parts. The superficial part is located on the aortic arch, while the deep part is located on the trachea. These parts contain the sympathetic and parasympathetic fibres of the autonomic nervous system that influence the heart rate.<br/><br/><b>Oesophageal plexus</b><br/>The oesophageal plexus is located on the oesophagus before it passes through the diaphragm and into the abdomen.<br/><br/><b>Prevertebral plexus</b><br/>The prevertebral plexus is located on the abdominal aorta in the lumbar region of the torso. This plexus is actually made up of a number of small plexuses that supply the stomach, kidneys and intestines.<br/><br/><b>Hypogastric plexuses</b><br/>These plexuses lie within the pelvis and supply sympathetic and parasympathetic nerves to the pelvic organs, such as the rectum and bladder.",
                ImageUri1 = container.GetBlockBlobReference("bodyplexuses.png").Uri,
                ImageUri2 = container.GetBlockBlobReference("brachiallabelled.png").Uri,

                Popup1Title = "Clinical Note: Plexus Injuries",
                Popup1Content = @"Damage to the brachial plexus can occur in a number of ways, e.g.stretching of, and pressure on, the nerves that make up the brachial plexus.Stretching injuries may be experienced during whiplash in a car crash.Pressure injuries may occur after a fall – the clavicle can fracture after falling on outstretched arms; it then presses down on the nerves.Symptoms can include varying degrees of loss of sensation and movement in the affected arm, and they will depend on the nerves that are affected(C5, C6, C7, C8 and/ or T1) and where exactly the nerves are damaged(the closer to the spinal cord the injury is, the more likely the symptoms will be wide spread).Read more about brachial plexus injuries at <a href= ""http://orthoinfo.aaos.org/topic.cfm?topic=A00678"">OrthoInfo</a>",
                Popup2Title = "Revision Note: Lumbosacral Plexus",
                Popup2Content = "When revising for exams, you may come across the term ‘lumbosacral plexus’ – this is simply a term for the sacral plexus, lumbar plexus and coccygeal nerve combined, and is often used interchangeably with the individual plexuses.",
            });
        }
    }
}
