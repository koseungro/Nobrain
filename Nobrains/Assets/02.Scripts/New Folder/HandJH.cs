using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandJH : MonoBehaviour
{
    private Transform tr;
    private GameObject brain;

    public SteamVR_Input_Sources handType;
    private SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;  //왼, 오른손 모두
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    private SteamVR_Behaviour_Pose pose; //컨트롤러 정보
    public SteamVR_Action_Boolean teleportAction = SteamVR_Actions.default_Teleport; // 그랩액션 정보
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    private bool objectPicked = false;
    private List<GameObject> brains;
    private bool bigBrainPicked = false;

    void Start()
    {
        tr = GetComponent<Transform>();
        brains = new List<GameObject>();
    }

    void Update()
    {
        if (trigger.GetStateUp(hand) && objectPicked)
        {
            Debug.Log("와라와라와라와");
            foreach (GameObject brain in brains)
            {
                brain.transform.SetParent(null);
                // brain.GetComponent<Rigidbody>().isKinematic = false;
                brain.GetComponent<GoBrain>().enabled = true;
                // brain = null;
                Debug.Log(brain.name);
                brains.Remove(brain);
            }
            objectPicked = false;
        }
    }
    // private void OnTriggerEnter(Collider other)  //물체 집기
    // {
    //     if(other.gameObject.layer == 8) 
    //     {
    //         brain = other.gameObject;
    //         brain.transform.SetParent(tr);
    //         brain.GetComponent<Rigidbody>().isKinematic = true;

    //     }
    // }

    private void OnTriggerStay(Collider other) //물체 집기
    {
        brain = other.gameObject;
        Debug.Log(objectPicked);
        Debug.Log(brain.name);
        if (trigger.GetStateDown(hand) && !objectPicked && other.gameObject.layer == 8)
        {
            Debug.Log(brains.Count);
            if(brains.Count == 0){
                brain.transform.SetParent(tr);
            }
            brain.GetComponent<Rigidbody>().isKinematic = true;
            brain.GetComponent<GoBrain>().enabled = false;
            objectPicked = true;
            brains.Add(brain);
            bigBrainPicked = true;
            Debug.Log("Big");
        }
        if (trigger.GetStateDown(hand) && !objectPicked && other.gameObject.layer == 9)
        {
            Debug.Log("Small");
            brain.transform.SetParent(tr);
            // brain.GetComponent<Rigidbody>().isKinematic = true;
            // brain.GetComponent<GoBrain>().enabled = false;
            objectPicked = true;
            brains.Add(brain);
            Debug.Log(brains.Count);
            if(bigBrainPicked){
                GameObject bigBrain = brains.Find(x => x. name.Contains("GoBrain"));
                bigBrain.transform.SetParent(null);
                brain.GetComponent<GoBrain>().enabled = true;
                // brain = null;
                Debug.Log(brain.name);
            }
        }
    }

    //온트리거엑시트로 글로벌 bool변수 true(큰 뇌를 잡을 수 있는 상황으로)

    //  public void OnTriggerExit(Collider other) //물체 놓기
    // {
    //     if (!brain)
    //     {
    //         //brain.transform.SetParent(tr, false);
    //         return;
    //     }
    //     brain = null;
    // }

    //teleportAction.GetStateDown(hand) &&
}