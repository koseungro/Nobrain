using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class GoBrain : MonoBehaviour
{
    private Transform tr;
    private Animator anim;
    private int hashOpen;
    private bool opening = false;

    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;

    private SteamVR_Action_Boolean grab = SteamVR_Actions.default_GrabGrip;
    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    private SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;

    public float rotSpeed = 15f;   
    
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        hashOpen = Animator.StringToHash("BrainOpening");        
    }

    
    void Update()
    {
        tr.RotateAround(tr.position, Vector3.up, Time.deltaTime * rotSpeed);
        if (grab.GetStateDown(hand))
        {
            BrainOpening();
        }

    }
    void BrainOpening()
    {
                
        if (!opening)
        {
            Debug.Log("Open!");
            haptic.Execute(0.2f, 0.3f, 10f, 0.5f, hand);
            anim.SetTrigger("BrainOpen");
            opening = true;
        }
        if (opening)
        {
            Debug.Log("Close!");
            haptic.Execute(0.2f, 0.3f, 10f, 0.5f, hand);
            anim.SetTrigger("BrainOpen");
            opening = false;
        }

    }   

}
