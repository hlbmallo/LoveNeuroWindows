using NerveCentreW10.Helpers;

using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace NerveCentreW10.ViewModels
{
    public class Section1ViewModel
    {
        public ObservableCollection<SubsectionModel> SubsectionList { get; } = new ObservableCollection<SubsectionModel>();

        public Section1ViewModel()
        {
            CloudClass cloudclass = new CloudClass();

            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section11",
                Title = "1.1. The Neuron",
                Subtitle1 = "Introducing the 'Neuron'",
                Description1 = "A neuron is the standard communicating and processing cell of the nervous system. To fulfil its role, it can conduct electrical impulses. A neuron can carry sensory information, motor information or other information. Neurons exist throughout the brain, spinal cord and all the nerves in the rest of the body. Neurons frequently communicate and work together. Take the following example. Imagine you are leaving for school or work one morning but as soon as you step outside you realise it's freezing cold. The sensory neurons in the skin of your body (particularly your hands) detect the temperature of the cold air and they carry this information to the sensory area of the brain. From here, interneurons carry information to other parts of the brain that allow you to remember times in the past when you were cold and help you to realise the importance of wrapping up warm. Neurons in the advanced brain centres enable you to make a decision to return indoors to put on a thicker coat and gloves. Motor neurons are then activated, and these carry electrical impulses to the muscles in your legs that will stimulate the muscles to contract and enable you to walk back inside to wrap up warm.",
                Subtitle2 = "Features of a Neuron",
                Description2 = "Most neurons have a standard set of features, and these are described below (see Figure 1.1.1.).<br/><br/><b>Cell body (aka cell soma)</b><br/>The cell body contains the all-important, DNA-containing nucleus of the neuron. The cell body communicates with the rest of the cell by using transport proteins that run along the axon.<br/><br/><b>Axon</b><br/>This is the long thin tube-like part of the neuron (in fact, it can be up to 1m long, as is seen in the sciatic nerve in the leg!) The membrane of the axon has lots of ion pumps and ion channels that allow it to conduct electrical impulses (see Section 1.3. Action Potentials). As mentioned already, the axon contains transport proteins too.<br/><br/><b>Ion pumps and channels</b><br/>These are embedded in the axonal membrane and allow the movement of particular ions into or out of the axon. Ion pumps are described as active because they require energy (via ATP) to function. Ion channels tend to be passive and not require energy because they allow diffusion down their concentration gradient. The main ions that are transported are sodium and potassium ions.<br/><br/><b>Dendrites</b><br/>These are spiky projections with many branches that receive electrical impulses from other neurons and carry them into the cell body or axon.<br/><br/><b>Presynaptic terminal</b><br/>After travelling along the axon, the electrical impulse arrives at the presynaptic terminal. Here, it will be converted into a chemical message and released from the neuron. This chemical message will then be transmitted into an electrical message in another neuron (see Section 1.4. Synapses).<br/><br/><b>Myelin Sheaths</b><br/>These structures (not shown in Figure 1.1.1.) are present on most but not all nerves. Myelin is an insulating substance that wraps around most of the axon, leaving a few gaps. This layout forces the electrical impulse to skip some ion channels and 'jump' to the next gap – this speeds up the conduction of an electrical impulse along the axon. Myelin sheaths are formed by Schwann cells.",
                Subtitle3 = "Types of Neurons",
                Description3 = "Most neurons are multipolar neurons. This means they have lots of dendrites feeding <b>into</b> the cell body, and an axon <b>leaving</b> the cell body. One of the benefits of having a multipolar neuron is its ability to integrate impulses from lots of other neurons. Think about it - if ten neurons each synapse onto a single dendrite of one multipolar cell, they will massively increase the signal reaching the cell body. this is particularly important in scenarios such as auditory processing. The other two types of neurons are described below.<br/><br/><b>Unipolar neurons (see Figure 1.1.2, top)</b><br/>In these neurons, the cell body is attached to the rest of the neuron by only one short axon. A good example is a sensory neuron in a spinal nerve (see Section 3.1. Spinal Nerves). Side note: technically, the neuron shown here as 'unipolar' is actually classified as a 'pseudounipolar' neuron. This is because it has one very short axon that links to two other axons - it is kind of like a bipolar neuron in disguise.<br/><br/><b>Bipolar neurons (see Figure 1.1.2., bottom)</b><br/>These neurons have two axons, one entering the cell body and another leaving the cell body. A good example is a neuron found in the retina of the eye.",
                ImageUri1 = "structure.png",
                ImageUri2 = "unipolar.png",

                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section12",
                Title = "1.2. The Resting Membrane Potential",
                Subtitle1 = "What is the Resting Membrane Potential?",
                Description1 = "Every neuron has an essential feature called a resting membrane potential (RMP). The RMP ensures a neuron survives in normal healthy conditions and essentially prepares the neuron for conducting action potentials. The RMP arises because there is a difference in voltage (also called electrical potential) between the inside of a neuron and the outside of a neuron. A neuron, in its resting state, is much more negative inside compared to the outside. In fact, the inside is 70mV (millivolts) more negative than the outside, so we say that the difference in voltage (or electrical potential) is -70mV. So we simply say that the RMP has a value of -70mV. This is quite a tricky concept, so it’s explained step-by-step below with the help of Figure 1.2.1.",
                Subtitle2 = "What Causes the RMP to be Negative?",
                Description2 = "There are four ions and molecules that contribute to the RMP. These are:<br/><br/><b>• Sodium ion, Na+</b><br/><b>• Potassium ion, K+</b><br/><b>• Chloride ion, Cl-</b><br/><b>• Negatively charged proteins</b><br/><br/>Let’s set the stage first. Note that there are high concentrations of Na+ ions and Cl- ions outside the neuron, but high concentrations of K+ ions and negatively charged proteins inside the neuron. Also note that none of the ions or molecules can freely diffuse across the neuronal membrane. Let's also remember that the voltage inside the neuron is more negative with respect to the outside. The reason for this will become apparent shortly!<br/><br/>Now for the explanation. Neurons have ion channels that are selectively permeable to K+ ions. A few sentences ago we said that K+ has a high concentration inside the cell so, as you would expect, K+ ions want to diffuse out of the neuron, down their concentration gradient, using these selective ion channels. Now quite a lot of K+ ions leave by this way. Because some K+ ions are leaving the neuron, the inside becomes more negative.<br/><br/>So, we’ve established that some K+ ions leave the cell down their concentration gradient. But will this process go on forever until all of the K+ ions leave the cell? No, and here’s why. We are talking about ions here. Ions have an electrical charge, and therefore they have an electrical gradient too. If lots of K+ ions leave the neuron down their concentration gradient, an electrical gradient is going to be established in the opposite direction. This electrical gradient will try to push most of the K+ ions back into the neuron via the leaky K+ ion channels. The overall result of these two opposing gradients is the formation of an equilibrium (i.e. the net number of K+ ions going in equals the net number of K+ ions going out). This equilibrium occurs at -97mV for K+ ions. So, when the voltage difference is -97mV, there is no net movement of K+ ions into or out of the neuron, and most of the K+ ions are kept inside the neuron. This is shown in part 1 of Figure 1.2.1.<br/><br/>But the RMP is -70mV, not -90mV, so where did I get the -70mV from? The key is Na+ ions. Remember we said that Na+ ions are in a high concentration outside the neuron? Well, what happens with the K+ ions also happens with the Na+ ions. As you would expect, Na+ ions want to follow their concentration and electrical gradient into the neuron and, because there are some leaky Na+ ion channels , some Na+ ions (but not nearly as many as K+ ions) do move into the neuron. However, when the Na+ ion concentration and electrical gradients balance, most of Na+ ions stay outside the neuron and the Na+ ions reach their equilibrium at +61mV. This is shown in part 2 of Figure 1.2.1.<br/><br/>As Na+ ions and K+ ions both try to reach their individual equilibria, they end up compromising at -70mV. Neither ion perfectly reaches its equilibrium and so a few Na+ ions continue to leak into the neuron and some K+ ions continue to leak out. The neuron can't just let the leaks continue unchecked though, so it uses a sodium-potassium ATPase pump to help out. This is shown as part 3 in Figure 1.2.1. These pumps are located in the neuronal membrane and require ATP to work continually. These pumps force out 3 Na+ ions and force in 2 K+ ions – thereby keeping the internal part of the neuron negatively charged (and so maintaining the RMP at -70mV).<br/><br/>It's also worth talking about the negatively charged proteins inside the neuron. These are too large to diffuse out through the membrane and they help to maintain the negative internal state of the neuron. Chlorine ions don't have much net movement, because their equilibrium potential is -64mV (which is fairly close to the RMP).<br/><br/>So, in conclusion, the Na+ and K+ ion channels contribute to the formation of the RMP, but the Na+/K+ ATPase pump maintains the RMP at -70mV, by correcting the change in electrical potential caused by the leakage of Na+ and K+ ions.",
                Subtitle3 = "More Info",
                Description3 = @"The statistics on this page are calculated using the Nernst equation. More info can be found <a href=""http://www.physiologyweb.com/lecture_notes/resting_membrane_potential/resting_membrane_potential_nernst_equilibrium_potential.html"">here on PhysiologyWeb</a>",
                ImageUri1 = "rmp.png",
                ImageUri2 = null,
                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section13",
                Title = "1.3. Action Potentials",
                Subtitle1 = "Introducing the Action Potentional",
                Description1 = "The action potential is vital to the daily functioning of the human body. When nerves are at rest, they have the RMP, but when they need to communicate or process information, they need to conduct action potentials.<br/><br/>When people talk about an 'electrical impulse' or 'nerve impulse', what they are really referring to is an action potential. Explanations and accompanying diagrams are used below to explain the formation and conduction of an action potential along a neuron. Essentially, an action potential is an ionic Mexican wave!",
                Subtitle2 = "The Five Stages of the Action Potential",
                Description2 = "<b>Stage 1</b><br/>An action potential must be generated by a stimulus. For example, when you place your hand on a railing, the Na+ ion stretch receptors at the tips of the sensory neurons in your hand change shape, opening their Na+ ion channels. With the Na+ ion channels open, Na+ ions begin to enter the neuron slowly. Remember that the neuron, in its resting state, is much more negative inside than outside (the RMP across the neuronal membrane is -70mV), so the influx of sodium ions is making the inside of the neuron more positive. <br/><br/>" +
                "<b>Side Note</b><br/>What I have described here is a sensory cell that has stretch receptors embedded in it, such as a Pacinian corpuscle. However, not all neurons are equal. Sometimes, neurons synapse with each other in a big chain, or pathway, and, if this is the case, then our neuron will receive an action potential from another single neuron or multiple neurons. In this instance, the action potentials arrive in our neuron and congregate at the axon hillock (see Figure 1.1.1.), and then Stage 2 continues as below.<br/><br/>" +
                "<b>Stage 2</b><br/>The influx of Na+ ions into the neuron occurs at a fairly slow rate until the threshold for an action potential is reached. The threshold value is around -55mV for Na+ ions. Once the threshold value is reached, many more Na+ ion channels open and a huge number of Na+ ions flood into the neuron. In fact, so many Na+ ions flood into the neuron that the membrane potential rises to +30mV. This means that the inside of the neuron is now more positive compared to the outside. The process of the neuron becoming more positive inside is called depolarisation. If the threshold value is not reached (maybe due to a weak stimulus), there will be no action potential.<br/><br/>" +
                "<b>Stage 3</b><br/>At this stage, the electrical potential is so positive inside the neuron that Na+ ion channels begin to close, and the K+ ion channels begin to open. K+ ions begin to leak out of the neuron, and so the neuron gradually becomes more negative. Eventually, it reaches the resting membrane potential value of -70mV. This process of becoming more negative again is called repolarisation. Actually, the K+ ion channels stay open for slightly longer than they should, meaning the electrical potential reaches -70mV but then continues to become even more negative. The electrical potential eventually reaches -90mV. This 'overshoot' of K+ ion outflow and its excessive negative state is called hyperpolarisation. This has the beneficial effect of preventing another action potential from being generated too soon and becoming confused with the current action potential.<br/><br/>" +
                "<b>Stage 4</b><br/>Once -90mV is reached, the K+ ion channels close. The Na+/K+ ATPase pump then quickly restores the balance of ions so the RMP of -70mV is achieved again. The neuron is now ready to conduct another action potential.<br/><br/>",
                Subtitle3 = "Finally...",
                Description3 = "<b>Stage 5</b><br/>These ion movements begin at receptors in a sensory neuron and once the first set of Na+ ion channels open, a chain reaction is set off. Neighbouring Na+ ion channels open and, as mentioned before, the ion movements occur like a wave along the length of the axon until it reaches the presynaptic terminal.",
                ImageUri1 = "actionpotentials1to4.png",
                ImageUri2 = "ap5.png",

                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section14",
                Title = "1.4. Synapses",
                Subtitle1 = "Introducing the Synapse",
                Description1 = "When the action potential arrives at the presynaptic terminal, it needs to communicate with another neuron (or, in some cases, muscles or glands). However, in most neurons the action potential doesn't jump electrically from one neuron to the other. Instead, these synapses are chemical. In summary, this means that the electrical action potential is converted into a chemical messenger, sent across a short gap to the next neuron, and then reconverted back into a second electrical action potential. This process of communication is vital throughout the body, including in the spinal cord and brain, and when it breaks down, medical problems, such as depression (see Section 4.2. Depression) can occur. Check out the explanations and accompanying diagrams below.",
                Subtitle2 = "The Five Stages of Synaptic Transmission",
                Description2 = "<b>Stage 1</b><br/>An action potential travels along the presynaptic neuron. It eventually reaches the presynaptic terminal (also called presynaptic knob). The presynaptic terminal, like the rest of the neuron, is depolarised.<br/><br/>" +
                "<b>Stage 2</b><br/>Depolarisation of the neuron stimulates voltage-gated calcium ion (Ca2+) channels in the presynaptic terminal to open. As a result, Ca2+ ions flood into the presynaptic terminal. In close proximity to the presynaptic membrane lie vesicles which contain neurotransmitter molecules. The Ca2+ ions stimulate the vesicles to migrate towards the presynaptic membrane and fuse with it.<br/><br/>" +
                "<b>Stage 3</b><br/>The neurotransmitter molecules are released into the synaptic cleft – this is simply the space between the two neurons. The release of neurotransmitter molecules is called 'exocytosis'. The neurotransmitter molecules that have just been released are initially present in a high concentration. So, they diffuse across the synaptic cleft towards the postsynaptic membrane to an area of low concentration.<br/><br/>" +
                "<b>Stage 4</b><br/>The neurotransmitter molecules travel towards the postsynaptic membrane. There are receptors in the postsynaptic membrane that have a complementary shape to the neurotransmitter molecules, and so the neurotransmitter molecules bind to the receptor sites perfectly. This binding stimulates the opening of the Na+ ion channels in the postsynaptic membrane. Thus, Na+ ions rush into the postsynaptic membrane and…<br/><br/>" +
                "<b>Stage 5</b><br/>…this Na+ influx generates an action potential in the postsynaptic neuron that continues along the entire length of the postsynaptic neuron. At this stage, the neurotransmitter molecules will be recycled and used again in the presynaptic terminal.",
                Subtitle3 = "More Info",
                Description3 = "It is worth noting that there are a few electrical synapses (not chemical), an example being found between the secretory neurons in the hypothalamus (see Section 2.1. Overview of the Brain). These electrical synapses are essentially gap junctions, and they transmit action potentials at a faster rate compared to the chemical synapses described above. The distance between the neurons connected by electrical synapses is much smaller too, meaning a faster transmission speed. It should also be noted that some neurotransmitters are not 'excitatory' but instead they are 'inhibitory'. When these inhibitory neurotransmitters bind to their receptors in the postsynaptic membrane, they stimulate the opening of K+ or Cl- ion channels. When K+ or Cl- ions flood into the postsynaptic neuron, they induce a state of hyperpolarisation and no action potential is generated.",
                ImageUri1 = "synapses1to4.png",
                ImageUri2 = "syn5.png",

                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section15",
                Title = "1.5. Reflex Arcs",
                Subtitle1 = "What is a Reflex?",
                Description1 = "A reflex arc provides a great example to combine everything we have learned so far, such as neurons, the RMP, action potentials and synapses. A reflex arc is also a vitally important event in its own right. It functions to quickly protect the body from immediately threatening stimuli. Reflex arcs pass through the spinal cord but not the brain, which means that our response is rapid and involuntary. It would take a long time to consult the brain and consciously decide how to respond all threatening stimuli, and all the while potentially life-threatening damage would be occurring. So, the brain is bypassed and the spinal cord acts as the processing centre. The reflex arc is explained in writing and in Figure 1.5.1. *This example of a reflex arc shows only three neurons. Some reflex arcs will use more than three neurons.",
                Subtitle2 = "The Six-Stage Response",
                Description2 = "<b>1. Stimulus</b><br/>A chef is working in a kitchen and accidentally places his hand on a hot surface. The high temperature of the hot surface is the stimulus.<br/><br/><b>2. Receptor</b><br/>Temperature receptors in the skin of the hand detect the stimulus. The receptors respond by opening Na+ ion channels in the sensory neuron and an action potential is generated.<br/><br/><b>3. Sensory neuron</b><br/>The action potential passes along the sensory neuron in the chef's arm. The action potential travels extra fast because the sensory neuron is myelinated, and the action potential ‘jumps’ along the axon. The action potential then reaches the chef’s spinal cord.<br/><br/><b>4. Interneuron</b><br/>In the grey matter of the spinal cord, the sensory neuron synapses with an interneuron. This interneuron is short in length and so it quickly synapses with a motor neuron.<br/><br/><b>5. Motor neuron</b><br/>The action potential travels along the motor neuron, which is myelinated, and leaves the grey matter of the spinal cord. It travels back down the chef’s arm, heading for the muscles in the upper arm.<br/><br/><b>6. Effector</b><br/>The action potential in the motor neuron reaches a neuromuscular junction, releases a neurotransmitter and stimulates the biceps brachii and brachialis muscles in the arm to contract. This means the chef involuntarily moves his hand up and away from the stimulus, thereby reducing the amount of damage to the skin.<br/><br/>Note that many interneurons will also give off 'collateral axons' that run up to the brain for processing. This means that we have an initial involuntary reflex but slightly later we will have a voluntary response that is more complex and based on our understanding of the stimulus. In our example, this voluntary response might be the chef running his hand under cold water for ten minutes!",
                Subtitle3 = "",
                Description3 = "",
                ImageUri1 = "reflex.png",
                ImageUri2 = null,

                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section16",
                Title = "1.6. The Neuromuscular Junction",
                Subtitle1 = "What is a Neuromuscular Junction?",
                Description1 = "As you will have seen in Section 1.5. Reflex Arcs, a motor neuron running from the spinal cord must be able to stimulate, or excite, a skeletal muscle, so that it can contract and perform its function. A motor neuron communicates with a skeletal muscle using a particular combination of neurotransmitters, ions and a type of synapse called a ‘neuromuscular junction’. This process of communication is described below.",
                Subtitle2 = "Communication at a Neuromuscular Junction",
                Description2 = "<b>Stage 1</b><br/>As a motor neuron approaches a skeletal muscle, it divides into lots of branches. Each branch forms a neuromuscular junction with a muscle fibre. This means that one motor neuron innervates a number of muscle fibres.<br/><br/>As you might expect, the process begins with an action potential arriving at the presynaptic terminal. Ca2+ ions enter the presynaptic terminal and stimulate neurotransmitter-containing vesicles to migrate towards the presynaptic membrane. Communication with skeletal muscles requires the use of a specific neurotransmitter: acetylcholine. The vesicles exocytose the acetylcholine into the neuromuscular junction. This is quite similar to a regular synapse.<br/><br/><b>Stage 2</b><br/>The membrane of a muscle fibre is referred to as ‘the sarcolemma’, and it contains receptors for acetylcholine and Na+ ion channels. The acetylcholine molecules bind to their receptors in the sarcolemma (they have a complementary shape) and the receptors open the Na+ ion channels, allowing a rush of Na+ ions into the sarcolemma and the generation of an action potential in the muscle.<br/><br/><b>Stage 3</b><br/>Now, individual muscle fibres are made up of myofibrils. To ensure that the action potential gets deep down into the muscle fibre and close to all of the myofibrils, the sarcolemma has special tubes that run deep through the muscle fibre. These special tubes are called T-tubules, and the action potential runs continues down these too.<br/><br/><b>Stage 4</b><br/>The T-tubules don’t lead directly to the myofibrils. Instead, they lead to the sarcoplasmic reticulum, a unique feature of muscle fibres. The sarcoplasmic reticulum holds a large quantity of Ca2+ ions and, when the action potential reaches it via the T-tubules, it releases these Ca2+ ions into the myofibrils.<br/><br/><b>Stage 5</b><br/>The myofibrils then use the Ca2+ ions to enable their filaments to slide over each other and shorten – this is a muscular contraction.",
                Subtitle3 = "",
                Description3 = "",
                ImageUri1 = "nmj.png",
                ImageUri2 = null,
                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
            SubsectionList.Add(new SubsectionModel
            {
                PageId = "section17",
                Title = "1.7. The Neuronal Cytoskeleton",
                Subtitle1 = "Defining the Term ‘Neuronal Cytoskeleton’",
                Description1 = "The cytoskeleton is a cellular structure made up of filament-like proteins that helps to maintain the shape and organisation of a cell and provides a secure location for cell organelles to attach to. Neurons have a specialised cytoskeleton that also allows them to grow in length and transport substances, such as nerve growth factors, to and from the cell body. Figure 1.7.1. shows the intracellular environment of a neuron, with the different types of proteins in their respective locations.",
                Subtitle2 = "The Proteins Contributing to the Neuronal Cytoskeleton",
                Description2 = "There are three main types of proteins (also called protein filaments) that contribute to the neuronal cytoskeleton. These are:" +
                "<ol><li>Microtubules</li>" +
                "<li>Actin filaments</li>" +
                "<li>Neurofilaments (a type of intermediate filament)</li></ol>" +
                "Let’s start by looking at microtubules. Microtubules are made up of lots of smaller units of tubulin which have been joined together, processed and organised in a cellular structure called the centrosome. Microtubules also have a plus end and a minus end. In neurons, the minus ends are described as ‘free’, i.e. they are not anchored down to the centrosome – this allows the neuron to increase the length of its axon. Microtubules also provide a framework for transporting substances along the axon, as described in the section below. Microtubules also help to maintain ‘organelle polarity’ – this means that all the organelles are found where they should relative to each other.<br/><br/>" +
                "Actin filaments are made up of monomers of the protein actin – the most common protein in eukaryotic cells. Actin tends to lie close to the dendrites and growth cones of developing neurons (see Figure 1.7.1.), and there it helps to maintain the shape of these neuronal projections while they grow. The remainder of actin is found close to the neuronal membrane in the axon. The formation of actin from its monomers is active, i.e. it requires ATP. Moreover, actin is continuously being removed and replaced in a process known as remodelling.<br/><br/>" +
                "Neurofilaments are three chains wrapped together and are essential for the axon to grow in diameter and for the fast conduction of electrical impulses along the axon. They also form part of the nuclear lamina – this is a network of fibrils that provides structural support to the nucleus and is involved in DNA replication.",
                Subtitle3 = "Axonal Transport Using the Cytoskeleton",
                Description3 = "Axonal transport can occur in one of two directions:" +
                "<ol><li>From the cell body to the presynaptic terminal – this is called anterograde transport. Cargo such as new synaptic vesicles are moved by anterograde transport using a specialised ‘motor protein’ called kinesin. The down side is that this process is slow.</li>" +
                "<li>From the presynaptic terminal to the cell body – this is called retrograde transport. Cargo such as old bits of presynaptic terminal and nerve growth factors are moved by retrograde transport using a specialised ‘motor protein’ called dynein. This process is faster than anterograde transport.</li></ol>",
                ImageUri1 = "cytoskeletonv1.png",
                ImageUri2 = null,

                Popup1Title = "",
                Popup1Content = "",
                Popup2Title = "",
                Popup2Content = "",
                Popup3Title = "",
                Popup3Content = "",
            });
        }
    }
}

