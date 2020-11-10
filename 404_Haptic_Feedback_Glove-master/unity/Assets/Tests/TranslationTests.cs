using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TranslationTests
    {
        
        // Private Data Members
        private HandController handController;
        private float testRotationY = 45f;
        private float testRotationX = 5f;
        private float testRotationZ = 5f;
        private float epsilon = 3f;
        private float resolveRate = 0.05f;
        private Vector3 boundPush = new Vector3(5f, 5f, 5f);

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
            Object.Destroy(handController.gameObject);
        }

        // =====================================================================
        // ROTATION RESOLUTION TESTS
        // =====================================================================

        [UnityTest]
        public IEnumerator IndexDistalRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator IndexMiddleRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator IndexProximalRotationResolutionY()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator IndexProximalRotationResolutionZ()
        {
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,0,testRotationZ));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.z - testRotationZ);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleDistalRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleMiddleRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleProximalRotationResolutionY()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleProximalRotationResolutionZ()
        {
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,0,testRotationZ));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.z - testRotationZ);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingDistalRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingMiddleRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingProximalRotationResolutionY()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingProximalRotationResolutionZ()
        {
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,0,testRotationZ));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.z - testRotationZ);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallDistalRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallMiddleRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallProximalRotationResolutionY()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallProximalRotationResolutionZ()
        {
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,0,testRotationZ));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.z - testRotationZ);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbDistalRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbMiddleRotationResolution()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbProximalRotationResolutionY()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,testRotationY,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.y - testRotationY);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbProximalRotationResolutionZ()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(0,0,testRotationZ));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully3
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.z - testRotationZ);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbProximalRotationResolutionX()
        {
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            bool pass = true;

            // Set target rotation
            jointController.SetRotation(new Vector3(testRotationX,0,0));

            // DEBUG:
            // Debug.Log("Starting rotation: " + jointController.gameObject.transform.localRotation.eulerAngles);

            // Wait for 100ms
            yield return new WaitForSeconds(resolveRate);

            // Check the following 5 frames to see if the rotation resolved successfully
            for (int i = 0; i < 5; i++) {
                // Wait for fixed update
                yield return new WaitForFixedUpdate();

                // Check rotational value
                float delta = Mathf.Abs(jointController.gameObject.transform.localRotation.eulerAngles.x - testRotationX);
                if (delta > epsilon) {
                    pass = false;
                }
                
                // DEBUG:
                // Debug.Log("Delta = " + delta);
            }

            Assert.True(pass);
        }

        // =====================================================================
        // ROTATION BOUNDS MAX TESTS
        // =====================================================================

        [UnityTest]
        public IEnumerator IndexDistalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator IndexMiddleRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator IndexProximalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.indexFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleDistalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleMiddleRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator MiddleProximalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.middleFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingDistalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingMiddleRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator RingProximalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.ringFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallDistalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallMiddleRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator SmallProximalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.smallFinger.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbDistalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.distalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbMiddleRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.middlePhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }

        [UnityTest]
        public IEnumerator ThumbProximalRotationBoundaries()
        {
            // We've already determined that the rotation resolution works, so let's just test to make sure that making a rotation request to beyond the boundary properly adjusts
            
            // Initialize
            FingerController fingerController = handController.Thumb.GetComponent<FingerController>();
            JointController jointController = fingerController.proximalPhalange.GetComponent<JointController>();
            ConfigurableJoint joint = jointController.gameObject.GetComponent<ConfigurableJoint>();
            bool pass = true;

            // Give one frame to initialize the hand object
            yield return new WaitForFixedUpdate();

            // Create minimum and maximum test vectors
            // Recall that the joint limits have x and y axis flipped from the input rotation value
            Vector3 maxRotation = new Vector3(joint.angularYLimit.limit, -joint.lowAngularXLimit.limit, joint.angularZLimit.limit);
            Vector3 minRotation = new Vector3(-joint.angularYLimit.limit, -joint.highAngularXLimit.limit, -joint.angularZLimit.limit);

            // Set target rotation beyond maximum
            jointController.SetRotation(maxRotation + boundPush);

            // Test if target rotation exceeds max bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y > maxRotation.x || jointController.targetRot.x > maxRotation.y || jointController.targetRot.z > maxRotation.z) {
                pass = false;
                Debug.Log("failed max: " + jointController.targetRot);
            }

            // Set target rotation beyond minimum
            jointController.SetRotation(minRotation + boundPush);

            // Test if target rotation exceeds min bounds
            // Recall that the targetRot vector has x and y axis flipped from the input rotation value
            if (jointController.targetRot.y < minRotation.x || jointController.targetRot.x < minRotation.y || jointController.targetRot.z < minRotation.z) {
                pass = false;
                Debug.Log("failed min: " + jointController.targetRot);
            }

            // Assert
            Assert.True(pass);
        }
    }
}
