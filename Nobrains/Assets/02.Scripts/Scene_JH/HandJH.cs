using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;


public class HandJH : MonoBehaviour
{
    private Transform tr;
    private GameObject brain;
    private GameObject button;

    private SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;  //왼, 오른손 모두

    private SteamVR_Behaviour_Pose pose; //컨트롤러 정보
    public SteamVR_Action_Boolean teleportAction = SteamVR_Actions.default_Teleport; // 그랩액션 정보
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    private bool objectPicked = false;
    private List<GameObject> brains;

    void Start()
    {
        tr = GetComponent<Transform>();
        brains = new List<GameObject>();

    }

    void Update()
    {

        // 잡은 물체 놓기
        if (trigger.GetStateUp(hand) && objectPicked)
        {
            Debug.Log("내려놔라");

            brain.transform.SetParent(null);
            brain.GetComponent<GoBrain>().enabled = true;
            Debug.Log("내려놓음" + brain.name);

            objectPicked = false;
            brain = null;
        }
    }


    private void OnTriggerStay(Collider other) //물체 집기
    {
        brain = other.gameObject;        
        Debug.Log("objectpicked" + objectPicked);
        Debug.Log(brain.name);


        if (trigger.GetStateDown(hand) && !objectPicked && other.gameObject.layer == 8)
        {
            Debug.Log("Whole");
            brain.transform.SetParent(tr);

            //brain.GetComponent<Rigidbody>().isKinematic = true;
            //brain.GetComponent<GoBrain>().enabled = false;

            objectPicked = true;
            brains.Add(brain);

        }
        if(trigger.GetStateDown(hand) && brain.gameObject.layer == 5) {
            Debug.Log("Button Pressed");
            ExecuteEvents.Execute(brain, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

    }    

}