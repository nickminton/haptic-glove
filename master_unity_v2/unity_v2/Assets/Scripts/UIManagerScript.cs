using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public GameObject hand;

    public Slider SliderX;
    public Slider SliderY;
    public Slider SliderZ;

    private List<GameObject> fingers = new List<GameObject>();

    private GameObject activeFinger;
    private int activeJoint;

    private float rotX = 0;
    private float rotY = 0;
    private float rotZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Populate fingers List
        HandController hc = hand.GetComponent<HandController>();
        fingers.Add(hc.Thumb);
        fingers.Add(hc.indexFinger);
        fingers.Add(hc.middleFinger);
        fingers.Add(hc.ringFinger);
        fingers.Add(hc.smallFinger);
        fingers.Add(hc.Hand);

        // Initialize
        activeFinger = fingers[0];
        activeJoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandController hc = hand.GetComponent<HandController>();

        // Check for hand
        if (activeFinger == hc.Hand) {hc.RotateHand(new Vector3(rotX, rotY, rotZ)); return;}

        if (activeJoint == 0) {hc.RotateProximal(activeFinger, new Vector3(rotX, rotY, rotZ));}
        else if (activeJoint == 1) {hc.RotateMiddle(activeFinger, rotY);}
        else if (activeJoint == 2) {hc.RotateDistal(activeFinger, rotY);}
    }

    private GameObject ChooseJoint()
    {
        GameObject retval;

        if (activeFinger != fingers[5]) {
            FingerController fc = activeFinger.GetComponent<FingerController>();
            if (activeJoint == 0) {retval = fc.proximalPhalange;}
            else if (activeJoint == 1) {retval = fc.middlePhalange;}
            else {retval = fc.distalPhalange;}
        } else {
            retval = fingers[5];
        }

        return retval;
    }

    public void SetActiveFinger(int index) 
    {
        // Update Active Finger
        activeFinger = fingers[index];

        // Choose Joint
        Transform trans = ChooseJoint().GetComponent<Transform>();

        // Set Slider Values
        // Offset if hand
        if (trans.gameObject == fingers[5]) {
            SliderX.value = 0;
            SliderY.value = 0;
            SliderZ.value = 0;
        } else {
            SliderX.value = trans.localRotation.eulerAngles.x;
            SliderY.value = trans.localRotation.eulerAngles.y;
            SliderZ.value = trans.localRotation.eulerAngles.z;
        }

    }
    public void SetActiveJoint(int index) 
    {
        // Update Active Joint
        activeJoint = index;

        // Choose Joint
        Transform trans = ChooseJoint().GetComponent<Transform>();

        // Set Slider Values
        SliderX.value = trans.localRotation.eulerAngles.x;
        SliderY.value = trans.localRotation.eulerAngles.y;
        SliderZ.value = trans.localRotation.eulerAngles.z;
    }

    public void SetRotX(float x) {rotX = x;}
    public void SetRotY(float y) {rotY = y;}
    public void SetRotZ(float z) {rotZ = z;}
}
