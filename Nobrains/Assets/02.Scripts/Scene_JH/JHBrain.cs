using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class JHBrain : MonoBehaviour
{
    private Transform tr;
    private Animator anim;
    private int hashOpen;
    private bool opening = false;
    public GameObject bomb;

    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;

    private SteamVR_Action_Boolean grab = SteamVR_Actions.default_GrabGrip;
    private SteamVR_Action_Boolean teleport = SteamVR_Actions.default_Teleport;
    private SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;

    public float rotSpeed = 15f;
    private bool rotate = true;

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        hashOpen = Animator.StringToHash("BrainOpen");
        

    }


    void Update()
    {
        // RotateBrain();
        BombBrain();

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
            anim.SetTrigger(hashOpen);
            opening = true;
        }
        if (opening)
        {
            Debug.Log("Close!");
            haptic.Execute(0.2f, 0.3f, 10f, 0.5f, hand);
            anim.SetTrigger(hashOpen);
            opening = false;
        }

    }
    void RotateBrain()
    {
        if (rotate)
        {
            tr.Rotate(Vector3.up, Time.deltaTime * rotSpeed);
            if (rotate && teleport.GetStateDown(hand))
            {
                rotate = false;
                Debug.Log(rotate);
            }            
        }
        else if (!rotate)
        {
            if (teleport.GetStateDown(hand))
            {
                tr.Rotate(Vector3.up, Time.deltaTime * rotSpeed);
                rotate = true;
            }
        }
    }
    void BombBrain() {
        if(teleport.GetStateDown(hand)) {
           bomb.SetActive(true);
           Debug.Log("BBBBBBOMB");
        }
    }

}