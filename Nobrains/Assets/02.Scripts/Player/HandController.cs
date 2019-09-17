using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandController : MonoBehaviour
{
    public Animator anim;
    public Transform tr;
    private int default_hand;
    public SteamVR_Input_Sources handType;

    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;


    //액션 - 트리거 버튼(InteractUI)
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    //액션 - 트랙패드 클릭(Teleport)
    public SteamVR_Action_Boolean trackPad = SteamVR_Actions.default_Teleport;
    //액션 - 트랙패드 터치 여부(TrackpadTouch)
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TouchpadTouch;
    //액션 - 트랙패드 터치 좌표(TrackpadPosition)
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TouchpadPosition;

    //액션 - 그립 버튼의 잡기(GrabGrip)
    public SteamVR_Action_Boolean grip = SteamVR_Input.GetBooleanAction("GrabGrip");
    //액션 - 햅틱(Haptic)
    public SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;


    private void Start()
    {
        tr = GetComponent<Transform>();
        //anim = GetComponent<Animator>();
        default_hand = Animator.StringToHash("Natural");
    }

    void Update()
    {
        if (GetTeleportDown())
        {
            Debug.Log("Teleport" + handType);
            anim.SetTrigger("GunShoot");

        }

        if (GetGrab())
        {
            Debug.Log("Grip" + handType);
            anim.SetTrigger("Fist");


        }

        if (GetTrigger())
        {
            Debug.Log("Trigger" + handType);
            anim.SetTrigger("PressTriggerViveController");


        }
    }

    public bool GetTeleportDown()
    {
        return trackPad.GetStateDown(handType);
    }
    public bool GetGrab()
    {
        return grip.GetState(handType);

    }
    public bool GetTrigger()
    {
        return trigger.GetStateDown(handType);

    }
}


