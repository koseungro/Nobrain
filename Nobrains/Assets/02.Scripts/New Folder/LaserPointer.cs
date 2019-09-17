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
    private int brainLayer;
    private GameObject currBrain;
    private GameObject prevBrain;
    private bool uiClick = false;

    public delegate void LaserEnterHandler(GameObject cBrain);
    public static event LaserEnterHandler OnLaserEnter;

    // public delegate void LaserClickHandler();
    // public static event LaserClickHandler OnLaserClick;

    public delegate void LaserExitHandler(GameObject pBrain);
    public static event LaserExitHandler OnLaserExit;

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        tr = GetComponent<Transform>();
        brainLayer = 1 << LayerMask.NameToLayer("BRAIN");

        CreateLine();

    }

    void Update()
    {
        ray = new Ray(tr.position, tr.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            line.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
        if (!Physics.Raycast(ray, out hit, range))
        {
            line.SetPosition(1, new Vector3(0, 0, range));
        }

        BrainPart();

        if (trigger.GetStateDown(hand))
        {
            ClickUI();
        }

    }
    void CreateLine()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, range));
        line.startColor = Color.green;
        line.endColor = Color.red;
        line.startWidth = 0.005f;
        line.endWidth = 0.005f;
        line.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
        // line.material.color = defaultColor;

    }
    void BrainPart()
    {
        if (Physics.Raycast(ray, out hit, range, brainLayer))
        {
            currBrain = hit.collider.gameObject;
            if (currBrain != prevBrain) //현재 선택한 뇌의 부분과 이전에 선택했던 뇌의 부분이 다른 경우
            {
                OnLaserEnter(currBrain); //현재 선택한 뇌의 부분에 OnLaserEnter이벤트 전달
                OnLaserExit(prevBrain); //이전에 선택했던 뇌의 부분에 OnLaserExit이벤트 전달                
                prevBrain = currBrain; //currBrain이 prevBrain이 되도록                
            }
        }
        else
        {
            ReleaseBrain(); //레이저가 뇌 이외에 다른 부분을 선택했을 경우 OnLaserExit이벤트 전달
        }
    }
    void ReleaseBrain()
    {
        if (prevBrain != null) //이전에 선택헀던 뇌의 부분이 있을 경우
        {
            OnLaserExit(prevBrain); //이전에 선택했던 뇌의 부분에 OnLaserExit이벤트 전달                       
            prevBrain = null; //이전의 뇌의 부분을 초기화
        }
    }
    void ClickUI()
    {
        if (!uiClick && Physics.Raycast(ray, out hit, range, brainLayer))
        {
            hit.collider.gameObject.transform.Find("Canvas").gameObject.SetActive(true);
            uiClick = true;            
        }
        else 
        {
            hit.collider.gameObject.transform.Find("Canvas").gameObject.SetActive(false);
            uiClick = false;            
        }
    }
}
