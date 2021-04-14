using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Serial_Interaction : MonoBehaviour
{

    // =========================================================================
    // PUBLIC DATA MEMBERS
    // =========================================================================

    // enable - whether or not serial communication is enabled
    public bool enableOutput = true;
    public bool textOutput = false;

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
    SerialPort stream = new SerialPort("COM8", 9600);
    //StreamWriter stream = new StreamWriter("./outTest/test.txt", true);

    // handController - the hand controller object to feed information into
    HandController handController;


    // =========================================================================
    // PUBLIC METHODS
    // =========================================================================
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("serial interaction start up");
        // Set up the hand controller
        handController = Hand.GetComponent<HandController>();

        // skip if not enabled
        if (!enableOutput) {return;}

        textOutput = false;
        if (!textOutput)
        {
            Debug.Log("Serial inteaction entered stream try");
            // Set the read/write timeouts
            stream.ReadTimeout = 500;
            stream.WriteTimeout = 500;

            // open stream
            try
            {
                stream.Open();
                Debug.Log("stream opened");
            }
            catch
            {
                throw new System.Exception("Out Stream is not available!");
                //Debug.Log("serial interaction stream not available");
            }
            Debug.Log("serial interaction past try catch");
        }
        Debug.Log("serial interaction start up complete");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // skip if not enabled
        if (!enableOutput) {return;}

        if (!textOutput)
        {
            // Check if stream is open
            if (!stream.IsOpen)
            {
                throw new System.Exception("Stream is closed");
            }
        }
        // Initialize

        // Generate string based on hand values
        string sendStr = GenerateInteractionStream();

        // Send string
        //textOutput = false;
        if (!textOutput)
        {
            sendStr = sendStr + "\n";
            stream.Write(sendStr);

        } else
        {
            string path = "Assets/Resources/test.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            sendStr = sendStr + "\n";
            writer.Write(sendStr);
            writer.Close();
        }

    }

    public string GenerateInteractionStream()
    {
        // Initialize
        string retstr = "";
        
        // For each finger, add to the string
        foreach (GameObject finger in handController.fingers)
        {
            FingerController fc = finger.GetComponent<FingerController>();

            // Link middle and distal
            int middleForce = (fc.jointControllers[1].isInteracting ? 1 : 0) * fc.jointControllers[1].forcePercent;
            int distalForce = (fc.jointControllers[2].isInteracting ? 1 : 0) * fc.jointControllers[2].forcePercent;
            retstr += (Mathf.Max(middleForce, distalForce));

            // Add proximal
            retstr += (fc.jointControllers[0].isInteracting ? 1 : 0) * fc.jointControllers[0].forcePercent;
        }

      
        return retstr;
    }
}
