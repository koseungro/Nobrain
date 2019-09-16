
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources hand;  //왼, 오른손 모두
    public SteamVR_Behaviour_Pose pose; //컨트롤러 정보
    public SteamVR_Action_Boolean teleportAction; // 그랩액션 정보


    private GameObject collidingObject; //
    private GameObject objectInHand; //




    void Update()
    {
        if (teleportAction.GetStateDown(hand))
        {
            Debug.Log("#############");
            if (collidingObject)
            {
                GrabObject();
                Debug.Log("GRAB OBJECT");

            }
        }

        if (teleportAction.GetLastStateUp(hand))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    public void  OnTriggerEnter(Collider other) 
    {
        
        SetCollidingObject(other); 
          
    }

    public void OnTriggerStay(Collider other) 
    {
        SetCollidingObject(other);    
    }

    public void OnTriggerExit(Collider other) 
    {
    if (! collidingObject) 
    {
        return;
    }
    collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        Debug.Log("@@@@@@@@@@@");
        if (collidingObject || col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
        Debug.Log(collidingObject +"coliding object");
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
       Debug.Log("fIXED JOINT");


    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;

    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = pose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = pose.GetAngularVelocity();

        }
        objectInHand = null;
    }
}
