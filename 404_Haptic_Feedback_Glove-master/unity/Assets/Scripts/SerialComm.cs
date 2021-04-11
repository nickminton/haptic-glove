using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class SerialComm : MonoBehaviour
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
    SerialPort stream = new SerialPort("COM7", 115200); //new SerialPort("/dev/cu.usbmodemM43210051", 115200);

    // dataLength - the number of values expected from the input
    int dataLength = 10;

    // handController - the hand controller object to feed information into
    HandController handController;
    
    // Start is called before the first frame update
    void Start()
    {
        enableOutput = true;
        // skip if not enabled
        if (!enableOutput) {return;}
        //Debug.Log("Test test");
        // open stream
        stream.Open();
        Debug.Log(stream.IsOpen);

        // assign handController
        handController = Hand.GetComponent<HandController>();
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
        string[] data = null;

        // Reset counter and loop
        bool passed = false;
        int count = 0;
        while (!passed)
        {
            // read a line from the serial stream
            string str = stream.ReadLine();
            
            // trim and format data
            string input = str.Trim();
            data = str.Split(delimiter);

            // DEBUG
            //Debug.Log(input);

            // DEBUG: should I move this to the end of this update to minimize latency?
            // discard the backed-up stream
            stream.DiscardInBuffer();

            // Data Verification - make sure it has enough data in the array
            if (data.Length == dataLength)
            {
                passed = true;
            } 
            else
            {
                // increase count and throw error if count grows too large
                count += 1;
                if (count >= timeoutCount) {throw new System.Exception("Too many unparsable lines");}
            }
        }

        // Send data to HandController (only if data was added!)
        if (data != null)
        {
            sendData(data);
        }
    }

    void sendData(string[] data)
    {
        // Data Verification
        if (data.Length != dataLength)
        {
            throw new System.Exception(string.Format("sendData() requires data with {0} values", dataLength));
        }

        // Hand rotation
        float yaw = 0;
        float pitch = 0;
        float roll = 0;
        handController.RotateHand(new Vector3(pitch,-yaw,roll));

        // DEBUG: only continue if there is enough data
        if (dataLength < 2) {return;}

        // Thumb
        float tproximal = 0;
        float tmiddle = float.Parse(data[1]);
        float tdistal = float.Parse(data[0]);
        handController.RotateFinger(handController.Thumb, new Vector3(tproximal, tmiddle, tdistal));

        
        // DEBUG: only continue if there is enough data
        if (dataLength < 4) {return;}

        // Index
        float iproximal = float.Parse(data[3]);
        float imiddle = float.Parse(data[2]); // float.Parse(data[4]);
        float idistal = 0; // DEBUG
        handController.RotateFinger(handController.indexFinger, new Vector3(iproximal, imiddle, idistal));

        

        // DEBUG: only continue if there is enough data
        if (dataLength < 6) {return;}

        // Middle
        float mproximal = float.Parse(data[5]);
        float mmiddle = float.Parse(data[4]);
        float mdistal = 0; // DEBUG
        handController.RotateFinger(handController.middleFinger, new Vector3(mproximal, mmiddle, mdistal));

        // DEBUG: only continue if there is enough data
        if (dataLength < 8) {return;}

        // Ring
        float rproximal = float.Parse(data[7]);
        float rmiddle = float.Parse(data[6]);
        float rdistal = 0;
        handController.RotateFinger(handController.ringFinger, new Vector3(rproximal, rmiddle, rdistal));

        // DEBUG: only continue if there is enough data
        if (dataLength < 10) {return;}

        // Small
        float sproximal = float.Parse(data[9]);
        float smiddle = float.Parse(data[8]);
        float sdistal = 0;
        handController.RotateFinger(handController.smallFinger, new Vector3(sproximal, smiddle, sdistal));
    }
}
