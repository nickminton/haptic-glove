using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{

    public GameObject proximalPhalange;
    public GameObject middlePhalange;
    public GameObject distalPhalange;
    public List<GameObject> joints;
    public List<JointController> jointControllers;

    // Start is called before the first frame update
    void Start()
    {
        // Fill list of joints
        joints.Add(proximalPhalange);
        joints.Add(middlePhalange);
        joints.Add(distalPhalange);

        // Fill list of joint Controllers
        foreach (GameObject joint in joints) {
            jointControllers.Add(joint.GetComponent<JointController>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // do nothing
    }
    
    public void SetRotationProximal(Vector3 proximal)
    {
        proximalPhalange.GetComponent<JointController>().SetRotation(proximal);
    }

    public void SetRotationMiddle(float middle)
    {
        middlePhalange.GetComponent<JointController>().SetRotation(new Vector3(0, middle, 0));
    }

    public void SetRotationDistal(float distal)
    {
        distalPhalange.GetComponent<JointController>().SetRotation(new Vector3(0, distal, 0));
    }
}
