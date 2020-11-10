using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serial_Test : MonoBehaviour {

    public Serial_Interaction si;

    void FixedUpdate() {
        Debug.Log(si.GenerateInteractionStream());
    }
}