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
    public class Section4ViewModel
    {
        public ObservableCollection<SubsectionModel> SubsectionList { get; } = new ObservableCollection<SubsectionModel>();

        public Section4ViewModel()
        {
            CloudClass cloudclass = new CloudClass();

            CloudBlobContainer container = new CloudBlobContainer(new Uri(cloudclass.GetContainerSasUri(cloudclass.MyCloudClass())));

            SubsectionList.Add(new SubsectionModel
            {
                PageId = "Section41",
                Title = "4.1. Alzheimer's Disease",
                Subtitle1 = "Defining ‘Dementia’ and ‘Alzheimer’s Disease’",
                Description1 = "Dementia is a syndrome (i.e. a set of symptoms that normally occur together) that is associated with cognitive decline, i.e. thinking problems. The symptoms are caused by progressive damage to particular areas of the brain. The main symptoms are:<ul><li>Memory loss (especially of short term, day-to-day memories);</li><li>Decrease in mental agility (for example, of concentration and planning);</li><li>Language problems (holding conversations and remembering certain words become more difficult);</li><li>Orientation (to date, place and time);</li><li>Personality changes, such as increased apathy, anxiety and frustration;</li><li>Behavioural changes, such as becoming less social and performing certain activities over and over again, e.g. pacing up and down;</li></ul>Alzheimer’s disease (AD), vascular dementia, dementia with Lewy bodies and frontotemporal dementia are all examples of neurodegenerative diseases that have dementia as their main symptom/syndrome. These neurodegenerative diseases are differentiated from each other by how the disease processes affect brain tissue. Let’s take a look at the development of Alzheimer’s disease below.",
                Subtitle2 = "Biological Processes Underlying Alzheimer’s Disease",
                Description2 = "Alzheimer’s disease is thought to begin with insulin resistance in the brain, so it is sometimes called ‘diabetes of the brain’. As such, Alzheimer’s disease is considered to be a neurodegenerative and metabolic disease.<br/><br/>Research suggests that insulin resistance facilitates the aggregation of a protein called amyloid-beta in the hippocampus. These aggregations, or collections, of protein build up over time, forming amyloid-beta plaques. These plaques stimulate an immune response from microglia in the brain, which begins a cascade of cellular activity that damages neurons and prevents them from functioning normally. The neurons in the hippocampus eventually begin to die and, because the hippocampus is essential for forming memories, memory problems and dementia are common symptoms. Plaques also build up in the cerebral cortex and so neuronal death occurs there too. The neurons that are most likely to die use the neurotransmitter acetylcholine in their synapses.",
                Subtitle3 = "Identifying and Treating Alzheimer’s disease",
                Description3 = "Increasing age is the major risk factor for the development of Alzheimer’s disease, although other risk factors exist. For example, having type 2 diabetes is thought to increase the risk of developing Alzheimer’s disease. Genetic risk factors exist too. Mutations in genes called PSEN1 and PSEN2 are associated with early-onset familial Alzheimer’s disease. Another genetic risk factor involves the type of apolipoprotein that you have. Apolipoproteins are normally required for transporting fats in the circulatory system, but having a type called E4 may lead to the formation of more amyloid-beta plaques.<br/><br/>There is currently no cure for Alzheimer's Disease, but some medications can ease the symptom of memory loss. An example of this type of medication is the AChE inhibitor. This medication works by preventing an enzyme from breaking down the neurotransmitter acetylcholine, which is found in some hippocampal and cortical synapses; because acetylcholine is not broken down, it stays in the synapse for longer, helping the neurons to continue to communicate and thus improving the symptom of memory loss.<br/><br/>If a person is diagnosed with Alzheimer's Disease, a comprehensive care plan will be drawn up. This involves more than just prescribing medication. Areas in which the patient needs or will need support are identified and addressed. This support comes in a number of ways and can include occupational therapy, psychological therapy (such as cognitive stimulation and relaxation therapy), patient and carer support and counselling.",
                ImageUri1 = container.GetBlockBlobReference("alzheimers.png").Uri,
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
                PageId = "Section42",
                Title = "4.2. Depression",
                Subtitle1 = "Defining 'Depression'",
                Description1 = "In medicine, ‘depression’ can refer to one of two things:<ul><li><b>Major depressive episode (MDE)</b>, where a person experiences a persistent low mood and lack of interest in activities they used to find pleasurable, for two weeks or more.</li><li><b>Major depressive disorder (MDD)</b>, where a person has experienced two or more MDEs.</li></ul>Depression can have biological, psychological and social components. Here, we will mainly consider the biological component, but we will also see how all three components can be intricately linked by concepts such as epigenetics and neuronal plasticity.",
                Subtitle2 = "Biological Processes Underlying Depression",
                Description2 = "Serotonin is seen as neurotransmitter that has a major role in regulating mood. High levels of serotonin are associated with positive mood. Under normal circumstances, serotonin is released from the presynaptic terminal into the synaptic cleft. It then diffuses across the cleft and occupies postsynaptic receptors. It is then released from the receptors, taken back up into the presynaptic terminal, broken down and reassembled. It is thought that low levels of the neurotransmitter serotonin can result in depression, and this could be because of decreased production of serotonin, a decreased number of receptors or excessive reuptake. This is thought to occur in the hippocampus, amygdala and thalamus.",
                Subtitle3 = "Treating Depression",
                Description3 = "Due to its nature, depression can be treated with a mixture of biological, psychological and social interventions. (Note that this app is for information only, not medical adivce.)<ul><li><b>Biological interventions</b> – this mainly involves the administration of anti-depressants. Examples of frequently prescribed anti-depressants are fluoxetine, citalopram and sertraline. These drugs are all termed selective serotonin reuptake inhibitors (SSRIs) and they work by blocking some of the serotonin reuptake channels in the presynaptic terminals of neurons. This means that less serotonin can leave the synapses and, as a result, more serotonin can occupy receptors on the postsynaptic membrane. Other drugs used to treat depression of greater intensity include venlafaxine (which is a serotonin and noradrenalin reuptake inhibitor, or SNRI) and lithium (an anti-manic drug). Electroconvulsive therapy can be used for very hard-to-treat depression.</li><li><b>Psychological interventions</b> – examples of this include cognitive behavioural therapy (CBT), counselling and mindfulness. These therapies provide patients with new ways to think about and approach their problems, and may address some of the underlying issues that are triggering depression. Regular practice of mindfulness (a meditation-based therapy) has been shown to change the anatomy of the brain for the better. It is suggested that this is a result of neuronal plasticity, a feature of the brain that allows it to change its neuronal circuits over time when psychological therapies are consistently applied.</li><li><b>Social interventions</b> – if social isolation is a trigger for depression, introduction to routine, creative activities with other patients may help to reverse some of the symptoms of depression.</li></ul>",
                ImageUri1 = container.GetBlockBlobReference("depression.png").Uri,
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
                PageId = "Section43",
                Title = "4.3. Multiple Sclerosis",
                Subtitle1 = "Biological Processes Underlying MS",
                Description1 = "Multiple sclerosis (MS) is thought to be an autoimmune disease in which, over time, white blood cells (specifically T lymphocytes) attack and strip away the myelin sheaths of neurons in the brain and spinal cord (this process is called demyelination). This results in inflammation around the neuron. The inflammation can clear but often reoccurs, and this permanently damages the neuronal axons and prevents them from conducting action potentials effectively. Recurrent damage to the neurons results in the formation of many sclerotic plaques, or scars, in the brain and spinal cord (hence the terms “multiple” and “sclerosis”). Without myelinated axons, neurons conduct action potentials at a much slower speed, or stop altogether. Another hallmark of MS is oligodendrocyte death – remember from Section 2.5. Glial Cells that oligodendrocytes are responsible for myelinating neurons in the CNS.<br/><br/>The cause of MS is unknown. However, it is likely due to a combination of environmental and genetic factors. One theory suggests that people are more likely to develop MS if they live further from the equator - this is why MS is relatively common in the UK and USA. The important link here may be vitamin D, which has a role in immunity; if you live further from the equator, you are exposed to less sunlight and therefore produce less vitamin D, and less vitamin D may contribute to the development of MS. A second theory proposes that some people have DNA that codes for abnormal myelin – this abnormal myelin is ‘antigenic’, making it a target for T lymphocytes. A third theory suggests that a viral infection may lead to such a strong response by the body's immune system that it begins to damage its own nervous tissue in addition to the virus, leading to the development of MS. A fourth theory suggests that smoking increases a person's risk of developing MS, although the mechanism of this is currently unclear. Evidence also indicates that stopping smoking slows the progression of MS.<br/><br/>It is known that MS affects approximately 1 in 1000 people in the UK. The progressive condition generally develops between the ages of 20 and 40 years. It is also twice as common in women as it is in men.",
                Subtitle2 = "Symptoms of MS",
                Description2 = "Those living with MS can go through periods of relapse and remission, with the below symptoms worsening during relapse.<br/><br/><b>Muscle spasms and tremors</b><br/>This eventually leads to the shortening and permanent contraction of muscles(this is called spasticity).<br/><br/><b>Pain</b><br/>There are two types of pain: neuropathic and musculoskeletal. Neuropathic pain occurs due to the damage to nerve fibres and leads to stabbing or burning sensations over the skin. Musculoskeletal pain is a result of the spasticity of muscles.<br/><br/><b>Visual problems</b><br/>This occurs due to disturbances in the functioning of the optic nerve.<br/><br/><b>Fatigue</b><br/>This is a common symptom, caused by the damage to the CNS or perhaps caused by side effects of medications or other MS symptoms. Fatigue can be severe and affect balance and concentration.<br/><br/><b>Depression, anxiety and stress</b><br/>Perhaps due to damage to the CNS, dealing with the difficulties MS brings, or as a result of an individual’s psychological response to MS.",
                Subtitle3 = "Treating MS",
                Description3 = "Currently there is no cure for MS, although the symptoms can often be eased. Treatments can involve:<br/><br/><b>Medications</b><br/>Immunomodulatory agents are available; these help to reduce the number of relapses in some cases. Steroids are also available; these reduce inflammation during a period of relapse. Painkillers can be prescribed too, including amitriptyline (an antidepressant) for neuropathic pain. Antidepressants are also available to treat depression and anxiety.<br/><br/><b>Transcutaneous electrical nerve stimulation (TENS)</b><br/>This is a chronic pain-relieving technique that involves attaching electrodes to the skin through which small electrical impulses are delivered; the electrical impulses can block or reduce the pain action potentials going to the spinal cord and brain.<br/><br/><b>Physiotherapy</b><br/>This helps to maintain good function in tense and contracted muscles.<br/><br/><b>Occupational Therapy</b><br/>This helps patients adjust their work and home environments as appropriate to their needs.<br/><br/><b>Psychological therapy</b><br/>This helps patients to manage depression and anxiety, and deal with the difficulties that MS presents to patients.",
                ImageUri1 = container.GetBlockBlobReference("multiplesclerosis.png").Uri,
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
                PageId = "Section44",
                Title = "4.4. Stroke",
                Subtitle1 = "Defining a 'Stroke'",
                Description1 = "A stroke (aka cerebrovascular accident, or CVA), is a reduction in the blood supply to an area of the brain due to a clot ('infarct') or bleed ('haemorrhage').",
                Subtitle2 = "Biological Processes Underlying a Stroke",
                Description2 = "When an infarct or haemorrhage occurs in a blood vessel in the brain, there are two identifiable areas of damage: an ischaemic core and an ischaemic penumbra.<ul><li>The ischaemic core is the site of the infarct or haemorrhage and the immediate surrounding brain tissue - irreparable damage due to neurons dying occurs here quickly because of the lack of oxygen and glucose being delivered to brain tissue.</li><li>The ischaemic penumbra is the nearby surrounding brain tissue that is mildly or moderately damaged and can survive for a number of hours after the stroke; this is because the brain tissue is supplied by collateral arteries from other large arteries and so it still receives some blood. Pharmacological interventions, such as the administration of clot-busting drugs, are more likely to be successful in the ischaemic penumbra rather than the ischaemic core.</li></ul>So, what are the symptoms of a stroke? The symptoms of a stroke are closely related to the area of brain tissue that has lost its blood supply. For example, an infarct in the middle cerebral artery (MCA) can lead to a loss of motor function because the MCA is responsible for providing much of the blood supply to the precentral gyrus, in which the primary motor cortex is located. Infarcts or haemorrhages that occur in the lateral striate arteries (branches of the MCA) can cause particularly widespread brain damage. This is because these arteries supply blood to a structure called the internal capsule, which is responsible for conveying fibres between the cerebrum and the diencephalon and brainstem. Therefore, a infarct or haemorrhage in these arteries can prevent large parts of the cerebral hemispheres from communicating with the rest of the brain and body.<br/><br/>It’s also important to realise that a haemorrhagic stroke is just as bad as an infarction. Sometimes a haemorrhagic stroke occurs when a blood vessel ruptures because of a weak arterial wall (aneurysm), and the blood pours into nearby tissues and gathers in a pool. If this pool of blood becomes very large, it can increase the intracranial pressure (the pressure inside the skull) and other areas of brain tissue can become compressed. This is life-threatening.",
                Subtitle3 = "Diagnosing and Treating a Stroke",
                Description3 = "One of the first aid recommendations for establishing if a stroke is occurring is to perform a FAST test. FAST stands for Face, Arm, Speech, Time to call an ambulance. For example, for Face, you ask the patient to smile - an uneven smile may indicate a stroke. In hospital, a CT scan can establish the presence of an infarct or haemorrhage. It is sometimes necessary for the medical team to put a tube into the patient’s trachea and breathe for them, as the stroke may have disrupted the motor control of the tongue, pharynx and larynx.<br/><br/>In hospital, if a stroke is identified on a CT scan, there are a number of treatment options. A thrombolytic drug called alteplase can be administered as an injection. This is sometimes called a clot-busting drug. Alteplase dissolves the infarct (also called a thrombus) and thus allows restoration of blood flow. Alteplase treatment is most effective if started within four and a half hours of the onset of a stroke. Alteplase is not administered to a patient with a haemorrhagic stroke as it could lead to even more extensive bleeding in the brain. The treatment for a haemorrhagic stroke is different. If there is bleeding into the subdural space, surgery may be performed to relieve the pressure inside the cranium. A section of the cranium is removed in a procedure called a craniotomy and the excess blood is drained away. For patients who have had any type of stroke, anti-hypertensive and anticoagulant medications may be offered as long-term treatment to prevent more strokes in the future.",
                ImageUri1 = container.GetBlockBlobReference("stroke.png").Uri,
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
                PageId = "Section45",
                Title = "4.5. Parkinson's Disease",
                Subtitle1 = "Defining Parkinson's Disease",
                Description1 = "Parkinson’s disease is a neurodegenerative disease where dopamine neurons die, normally resulting in the symptoms of a tremor and slower movements. Diagnosis normally occurs around the age of 60, although a small number of people can be diagnosed when they are around the age of 40. Parkinson’s disease does not appear to have a strong inheritable component, so it is unlikely to be passed from parent to child. The exact cause is unknown, although it is suggested that ingesting pesticides and herbicides from food, along with some gene-altering factors, may be contributing factors.",
                Subtitle2 = "Biological Processes Underlying Parkinson's Disease",
                Description2 = "Parkinson’s disease is a disorder of the basal ganglia. The basal ganglia is required for performing motor activity, in particular performing practiced motor activities and voluntary movements, and inhibiting excessive and unwanted movements. In this disease, the neurons that run between two parts of the basal ganglia begin to die, resulting in a large imbalance of neurotransmitters.<br/><br/>There are a number of parts to the basal ganglia, but here we are concerned with three parts specifically:<ul><li>Substantia nigra (which is part of the midbrain);</li><li>Putamen;</li><li>Caudate nucleus.</li></ul>You can see the location of these structures in Figure 4.5.1. The neurons that connect the substantia nigra to the putamen and caudate nucleus are dopaminergic (i.e. they use dopamine as their neurotransmitter). In Parkinson’s disease, these neurons die gradually, meaning the amount of dopamine decreases over time. The basal ganglia connections are lost, and thus control can be lost over which movements are made. The speed at which movements are made can also be affected. The overall result can include symptoms such as a tremor, muscle rigidity, slow movements (when walking this is sometimes referred to as a ‘festinating gate’ or ‘shuffle’) and impaired range of movement (making actions such as writing more difficult).",
                Subtitle3 = "Treating Parkinson's Disease",
                Description3 = "There is currently no cure for Parkinson’s disease although the symptoms can be eased using different therapies.<br/><br/><b>Medication</b><br/>A medication called levodopa (also called L-dopa) is given to most patients with the disease. Levodopa is a precursor to dopamine and, when taken up by neurons in the basal ganglia, it is converted to dopamine and replaces the dopamine which has already been lost. The parts of the basal ganglia can then communicate more, although not completely, effectively. Note that dopamine cannot be given directly as it is unable to cross the blood-brain barrier (see more in Section 2.5. Glial Cells). Other drugs, such as monoamine oxidase-B inhibitors, are used to decrease the activity of enzymes that break down dopamine, although they are prescribed in the earlier stages of the disease.<br/><br/><b>Surgery</b><br/>If Parkinson’s disease cannot be controlled with medication, people may be offered surgery. A surgeon can set up deep-brain stimulation (DBS). During surgery, electrodes are implanted into parts of the basal ganglia. After surgery, these electrodes produce high frequency stimulation that blocks some of the natural electrical signals in the basal ganglia, thereby reducing the symptoms of the disease. It is kind of like a pacemaker of the brain.<br/><br/><b>Physiotherapy and occupational therapy</b><br/>Regular physiotherapy exercises can help free up tight and stiff muscles. Physiotherapists can also help improve a patient’s ability to walk. Occupational therapists can help patients adjust their lifestyles and their homes so they can cope better with the difficulties that Parkinson’s disease brings about. This might include installing handrails in the home to aid mobility, learning ways to cope with anxiety and depression, and developing new ways to communicate when handwriting and speech become difficult.",
                ImageUri1 = container.GetBlockBlobReference("parkinsons.png").Uri,
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
                PageId = "Section46",
                Title = "4.6. Huntington's Disease",
                Subtitle1 = "Defining Huntington's Disease",
                Description1 = "Huntington’s disease is an inherited neurodegenerative disorder that involves progressive damage to the basal ganglia, resulting in symptoms such as dyskinesia (abnormal, involuntary movements), apparent clumsiness, lack of concentration and other cognitive problems. Although inherited, the symptoms of Huntington’s disease only become apparent in 30 – 50 year olds.<br/><br/>Huntington’s disease used to be called Huntington’s chorea due to the involuntary movements of the limbs and face (‘chorea’ is the Greek work for ‘dance’).",
                Subtitle2 = "Biological Processes Underlying Huntington's Disease",
                Description2 = "In the healthy body, there is a gene in the short arm of chromosome 4 (see Figure 4.6.) that has a specific sequence of bases – CAG – that is repeated between 9 and 35 times. This gene is responsible for carrying the code that will make a protein called Huntingtin (sometimes abbreviated to HTT). The normal functions of Huntingtin are thought to include transporting materials within cells, regulation of DNA copying (transcription) and inhibition of programmed cell death (apoptosis). However, in Huntington’s disease, there are 36 or more repeats of the CAG sequence. This means that the instructions for making the Huntingtin protein are wrong, and as a result the protein is longer and becomes dysfunctional.<br/><br/>The faulty protein causes the death of neurons in the indirect pathway between the striatum of the basal ganglia and the cerebral cortex. Normally, the basal ganglia helps to inhibit excitatory action potentials that would stimulate excess and unwanted movements. So, when the neurons of the basal ganglia die, there is no mechanism to inhibit these messages on their way to the cerebral motor cortices. This is how abnormal and involuntary movements arise in Huntington’s disease.<br/><br/>Researchers are not completely sure how the faulty protein causes neurons in the basal ganglia to die. However, the following mechanisms have been suggested:<ul><li>The faulty protein stimulates an inflammatory response that begins to damage neurons.</li><li>The faulty protein interferes with cell metabolism – this produces harmful ‘oxidative stress’ molecules.</li><li>The faulty protein may be ‘chopped up’ in the brain and the resulting fragments induce apoptosis.</li><li>The faulty proteins may aggregate, just like in Alzheimer’s disease, and induce apoptosis.</li></ul>",
                Subtitle3 = "Diagnosing and Treating Huntington’s disease",
                Description3 = @"Huntington’s disease can be diagnosed by testing for the faulty gene. Testing may be offered to those who have symptoms of the disease, and to those who have a parent with the disease. It is important to note that Huntington’s disease is classified as autosomal dominant – this means that if one parent has the disease, there is a 50% chance that a child will also develop the disease.<br/><br/>There is currently no cure for Huntington’s disease. Available treatments aim to help manage the symptoms.<br/><br/><b>Medications</b><br/>Two types of drugs can be used for the treatment of involuntary movements. These include a group of medications called atypical antipsychotics, and a new drug called tetrabenazine. The latter is thought to work by reducing the amount of serotonin, dopamine and noradrenaline in the brain, although the exact mechanism is unknown. SSRIs, such as fluoxetine, can also be given to reduce depressive symptoms.<br/><br/><b>Speech and language therapy</b><br/>Speech and language therapy can also help to improve communication and swallowing problems that occur in certain stages of the disease.<br/><br/><b>Occupational therapy</b><br/>Therapists can identify practical problems that may arise in the home and provide appropriate solutions to ensure independence is maintained for as long as possible.<br/><br/><b>Diet and exercise</b><br/>People diagnosed with Huntington’s disease may find it difficult to eat and maintain a healthy body weight. As such, a high calorie diet may be advised by the medical team. Exercise can also improve mental and physical health.<br/><br/>Other useful factsheets on living with Huntington’s disease can be found at the <a href=""https://hda.org.uk/"">Huntington's Disease Association</a> website.",
                ImageUri1 = container.GetBlockBlobReference("huntingtons.png").Uri,
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
