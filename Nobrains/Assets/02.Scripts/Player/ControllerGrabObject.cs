
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerGrabObject : MonoBehaviour
{
    private Transform tr;
    private SteamVR_Input_Sources hand;  //왼, 오른손 모두
    private SteamVR_Behaviour_Pose pose; //컨트롤러 정보
    public SteamVR_Action_Boolean teleportAction; // 그랩액션 정보

    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObject; //
    private GameObject objectInHand; //

    void start()
    {
        tr = GetComponent<Transform>();
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
    }


    // void Update()
    // {
    //     if (teleportAction.GetStateDown(hand))
    //     {
    //         Debug.Log("#############");
    //         if (collidingObject)
    //         {
    //             //GrabObject();
    //             Debug.Log("GRAB OBJECT");

    //         }
    //     }

    //     if (teleportAction.GetLastStateUp(hand))
    //     {
    //         if (objectInHand)
    //         {
    //             //ReleaseObject();
    //         }
    //     }
    // }

    public void OnTriggerEnter(Collider other)
    {
       // SetCollidingObject(other);
        if (other.gameObject.layer == 8)
        {
            Debug.Log("고승로 천재");
            other.gameObject.transform.SetParent(tr);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }
}
//     public void OnTriggerStay(Collider other)
//     {
//         SetCollidingObject(other);

//     }

//     public void OnTriggerExit(Collider other)
//     {
//         if (!collidingObject)
//         {
//             return;
//         }
//         collidingObject = null;
//     }

//     private void SetCollidingObject(Collider other)
//     {
//         Debug.Log("@@@@@@@@@@@");
//         if (collidingObject || !other.GetComponent<Rigidbody>())
//         {
//             return;
//         }
//         // collidingObject = other.gameObject;
//         Debug.Log(collidingObject + "coliding object");
//         other.gameObject.transform.SetParent(tr);
//         collidingObject.GetComponent<Rigidbody>().isKinematic = true;

//     }

//     public void SetParent(Transform tr)
//     {
//         collidingObject.transform.SetParent(tr);
//         collidingObject.GetComponent<Rigidbody>().isKinematic = true;
//     }

//     private void GrabObject()
//     {
//         objectInHand = collidingObject;
//         collidingObject = null;

//         // var joint = AddFixedJoint(); //
//         // joint.connectedBody = objectInHand.GetComponent<Rigidbody>(); //
//         // Debug.Log("fIXED JOINT"); //


//     }

//     // private FixedJoint AddFixedJoint() //
//     // { //
//     //     FixedJoint fx = gameObject.AddComponent<FixedJoint>(); //
//     //     fx.breakForce = 20000; // 
//     //     fx.breakTorque = 20000; //
//     //     return fx; //

//     // } //

//     private void ReleaseObject()
//     {
//         collidingObject.transform.SetParent(tr, false);
//         // if (GetComponent<FixedJoint>()) //
//         // { //
//         //     GetComponent<FixedJoint>().connectedBody = null; //
//         //     Destroy(GetComponent<FixedJoint>()); //

//         // objectInHand.GetComponent<Rigidbody>().velocity = pose.GetVelocity(); //
//         // objectInHand.GetComponent<Rigidbody>().angularVelocity = pose.GetAngularVelocity(); //

//         // } //
//         objectInHand = null;
//     }
// }
