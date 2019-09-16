using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private Transform tr;
    private LineRenderer line;

    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    
    public float range = 20f;
    // public Color defaultColor = Color.green;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        tr = GetComponent<Transform>();
        
        CreateLine();

    }

    void Update()
    {
        ray = new Ray(tr.position, tr.forward);

    }
    void CreateLine()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0,0,range));
        line.startColor = Color.green;
        line.endColor = Color.red;
        line.startWidth = 0.01f;
        line.endWidth = 0.005f;
        line.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
        // line.material.color = defaultColor;

    }
    
}
