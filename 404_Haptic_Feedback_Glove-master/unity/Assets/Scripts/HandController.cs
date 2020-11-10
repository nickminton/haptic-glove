using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject Thumb;
    public GameObject indexFinger;
    public GameObject middleFinger;
    public GameObject ringFinger;
    public GameObject smallFinger;
    public GameObject Hand;

    public float handOriginRotX = 175.4f;
    public float handOriginRotY = 0;
    public float handOriginRotZ = 0;

    [HideInInspector]
    public List<GameObject> fingers = new List<GameObject>();
    [HideInInspector]
    public List<FingerController> fingerControllers = new List<FingerController>();

    // Start is called before the first frame update
    void Start()
    {
        // Create fingers list
        fingers.Add(Thumb);
        fingers.Add(indexFinger);
        fingers.Add(middleFinger);
        fingers.Add(ringFinger);
        fingers.Add(smallFinger);

        // Create fingerControllers list
        foreach (GameObject finger in fingers) {
            fingerControllers.Add(finger.GetComponent<FingerController>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateProximal(GameObject finger, Vector3 proximal) 
    {
        // Rotate the proximal joint according to Vector3 proximal
        finger.GetComponent<FingerController>().SetRotationProximal(proximal);
    }
    public void RotateMiddle(GameObject finger, float middle) 
    {
        // Rotate the middle joint according to Vector3 middle
        finger.GetComponent<FingerController>().SetRotationMiddle(middle);
    }
    public void RotateDistal(GameObject finger, float distal) 
    {
        // Rotate the distal joint according to Vector3 distal
        finger.GetComponent<FingerController>().SetRotationDistal(distal);
    }

    // Rotate Hand
    public void RotateHand(Vector3 rotation)
    {
        // Offset rotation for initial values
        rotation.x += handOriginRotX;
        rotation.y += handOriginRotY;
        rotation.z += handOriginRotZ;

        //Debug.Log(string.Format("{0}, {1}, {2}",rotation.x, rotation.y, rotation.z));

        // Rotate
        Hand.GetComponent<Transform>().localRotation = Quaternion.Euler(rotation);
    }

    // TODO: convert proximal rotation to allow for 3D proximal rotation
    // Alias function to rotate entire finger
    public void RotateFinger(GameObject finger, Vector3 rotation)
    {
        // rotation - Vector3<proximal, middle, distal>

        // Run each finger's rotation function
        RotateProximal(finger, new Vector3(0, rotation.x, 0));
        RotateMiddle(finger, rotation.y);
        RotateDistal(finger, rotation.z);
    }
}
