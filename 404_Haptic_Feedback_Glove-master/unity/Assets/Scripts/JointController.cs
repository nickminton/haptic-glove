using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JointController : MonoBehaviour
{
    // public Vector3 rotMax;
    // public Vector3 rotMin;
    public float h = 0.55f;
    public bool isInteracting;

    // TODO: make this value dynamic!
    public int forcePercent = 4;  // percent force to be applied if interacting
    public float forceGradient = 0;

    protected Vector3 rotTemp;

    protected ConfigurableJoint cj;
    public Vector3 targetRot;

    // Start is called before the first frame update
    void Start()
    {
        // Init
        cj = this.GetComponent<ConfigurableJoint>();

        // Initialize rotational velocity
        // targetRot = new Vector3(this.transform.localEulerAngles.y,this.transform.localEulerAngles.x,this.transform.localEulerAngles.z);
        cj.targetVelocity = targetRot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Set the joint's force depending on how far targetRot is from actualRot
        SetVelocity();
    }

    // =========================================================================
    // COLLISION HANDLING
    // =========================================================================
    // protected abstract void OnTriggerEnter(Collider other);
    // protected abstract void OnTriggerExit(Collider other);

    protected void OnTriggerEnter(Collider other)
    {
         Debug.Log(this.name + " interacted with " + other.gameObject.name + " which is " + other.material.name);

        // Set isInteracting
        isInteracting = true;

        // Set forcePercent
        forcePercent = MaterialToForce(other.sharedMaterial);
        forceGradient = cj.targetAngularVelocity.x;
    }

    protected void OnTriggerExit(Collider other)
    {
        // Debug.Log(this.name + " stopped interacting with " + other.gameObject.name);
        
        // Set isInteracting
        isInteracting = false;
    }

    // =========================================================================
    // PUBLIC METHODS
    // =========================================================================
    public void SetRotation(Vector3 rotation)
    {
        // Data Verification
        rotation = Verify(rotation);

        // Flip x and y components of vector
        // has to do with the way that ConfigurableJoint interprets rotation around local axis - x is the primary rotational axis
        float temp = rotation.x;
        rotation.x = rotation.y;
        rotation.y = temp;

        // Set rotation value - all axes!
        targetRot = rotation;
    }

    // =========================================================================
    // PROTECTED METHODS
    // =========================================================================
    protected Vector3 Verify(Vector3 rotation)
    {
        if (rotation.x > cj.angularYLimit.limit) {rotation.x = cj.angularYLimit.limit;}
        else if (rotation.x < -cj.angularYLimit.limit) {rotation.x = -cj.angularYLimit.limit;}
        
        // these are inversed, i hate ConfigurableJoints omg
        if (rotation.y < cj.highAngularXLimit.limit) {rotation.y = cj.highAngularXLimit.limit;}
        else if (rotation.y > -cj.lowAngularXLimit.limit) {rotation.y = -cj.lowAngularXLimit.limit;}
        
        if (rotation.z > cj.angularZLimit.limit) {rotation.z = cj.angularZLimit.limit;}
        else if (rotation.z < -cj.angularZLimit.limit) {rotation.z = -cj.angularZLimit.limit;}

        return rotation;
    }

    protected int MaterialToForce(PhysicMaterial material) {
        // Choose hardness based on physic material
        // TODO: Change this to be NOT based on material name!!
        if (material.name.Contains("rigid")) {
            return 9;
        } else if (material.name.Contains("soft")) {
            return 4;
        }

        // default value
        return 0;
    }

    // =========================================================================
    // PRIVATE METHODS
    // =========================================================================
    void SetVelocity()
    {
        // Set actualRot
        Vector3 actualRot = cj.transform.localEulerAngles;

        // Flip x and y 
        // UGH I HATE THESE JOINTS
        float temp = actualRot.x;
        actualRot.x = actualRot.y;
        actualRot.y = temp; //change to temp?? -Nick

        // Normalize actualRot
        actualRot.x = (actualRot.x > 180) ? actualRot.x - 360 : actualRot.x;
        actualRot.y = (actualRot.y > 180) ? actualRot.y - 360 : actualRot.y;
        actualRot.z = (actualRot.z > 180) ? actualRot.z - 360 : actualRot.z;

        // Calculate Delta
        Vector3 delRot = targetRot - actualRot;

        // Set the target angular velocity according to a smoothing parameter h
        cj.targetAngularVelocity = h * delRot;
        //Debug.Log("targetvel:" + cj.targetAngularVelocity);

    }
}
