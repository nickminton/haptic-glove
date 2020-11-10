using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class Serial_Interaction : MonoBehaviour
{

    // =========================================================================
    // PUBLIC DATA MEMBERS
    // =========================================================================

    // enable - whether or not serial communication is enabled
    public bool enableOutput = false;

    // Hand - the hand object to get the handController from
    public GameObject Hand;

    // delimiter - character in the serial 
    public char delimiter = ',';
    
    // timeoutCount - number of tries before bad data causes an error
    public int timeoutCount = 5;


    // =========================================================================
    // PRIVATE DATA MEMBERS
    // =========================================================================

    // stream - the serial stream object
    SerialPort stream = new SerialPort("/dev/cu.usbmodemM43210051", 115200);

    // handController - the hand controller object to feed information into
    HandController handController;


    // =========================================================================
    // PUBLIC METHODS
    // =========================================================================
    
    // Start is called before the first frame update
    void Start()
    {
        // Set up the hand controller
        handController = Hand.GetComponent<HandController>();
        enableOutput = false;
        // skip if not enabled
        if (!enableOutput) {return;}

        // Set the read/write timeouts
        stream.ReadTimeout = 500;
        stream.WriteTimeout = 500;

        // open stream
        try
        {
            stream.Open();
        } catch
        {
            throw new System.Exception("Stream is not available!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // skip if not enabled
        if (!enableOutput) {return;}

        // Check if stream is open
        if (!stream.IsOpen) 
        {
            throw new System.Exception("Stream is closed");
        }

        // Initialize

        // Generate string based on hand values
        string sendStr = GenerateInteractionStream();

        // Send string
        stream.Write(sendStr);
    }

    public string GenerateInteractionStream()
    {
        // Initialize
        string retstr = "";
        
        // For each finger, add to the string
        foreach (GameObject finger in handController.fingers)
        {
            FingerController fc = finger.GetComponent<FingerController>();

            // Add proximal
            retstr += (fc.jointControllers[0].isInteracting ? 1 : 0) * fc.jointControllers[0].forcePercent;
            retstr += ",";

            // Link proximal and distal
            int middleForce = (fc.jointControllers[1].isInteracting ? 1 : 0) * fc.jointControllers[1].forcePercent;
            int distalForce = (fc.jointControllers[2].isInteracting ? 1 : 0) * fc.jointControllers[2].forcePercent;
            retstr += (Mathf.Max(middleForce, distalForce));
            retstr += ",";
        }

        return retstr;
    }
}
