using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InteractionTests
    {
        // Private Data Members
        private HandController handController;
        private GameObject testObj;

        // SetUp function happens before every Unit Test
        [SetUp]
        public void Setup()
        {
            GameObject hand = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RiggedHand"));
            handController = hand.GetComponent<HandController>();
        }

        // TearDown function happens after every Unit Test
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(testObj);
            Object.Destroy(handController.gameObject);
        }

        [UnityTest]
        public IEnumerator IndexDistalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator IndexMiddleJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator IndexProximalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator MiddleDistalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator MiddleMiddleJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator MiddleProximalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator RingDistalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator RingMiddleJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator RingProximalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator SmallDistalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator SmallMiddleJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator SmallProximalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator ThumbDistalJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator ThumbMiddleJointInteractionTriggers()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaction pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction happened
            Assert.True(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator IndexDistalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator IndexMiddleJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator IndexProximalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator MiddleDistalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator MiddleMiddleJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator MiddleProximalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator RingDistalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator RingMiddleJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator RingProximalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator SmallDistalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator SmallMiddleJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator SmallProximalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            GameObject joint = fingerController.proximalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator ThumbDistalJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            GameObject joint = fingerController.distalPhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }

        [UnityTest]
        public IEnumerator ThumbMiddleJointInteractionDisengages()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            GameObject joint = fingerController.middlePhalange;
            BoxCollider interactionPad = joint.GetComponent<BoxCollider>();

            // Spawn a collider on the interaciton pad
            testObj = new GameObject();
            testObj.AddComponent<BoxCollider>();
            testObj.transform.position = interactionPad.transform.position;

            // Allow interaction to occur
            yield return new WaitForFixedUpdate();

            // Teleport the collider away
            testObj.transform.position += new Vector3(50,50,50);

            // Allow for another interaciton to occur
            yield return new WaitForFixedUpdate();

            // Check to see if the interaction flag was removed
            Assert.False(joint.GetComponent<JointController>().isInteracting);
        }
    }
}
