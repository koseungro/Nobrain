using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    private Transform tr;
    private SteamVR_Action_Boolean teleport = SteamVR_Actions.default_Teleport;

    //레이저
    public float maxDistance = 20.0f;
    public Color defaultColor = Color.blue;
    public Color clickedColor = Color.green;

    private RaycastHit hit;
    private Ray ray;
    private int buttonLayer;
    private int floorLayer;
    private int objectLayer;
    public delegate void LaserEnterHandler(GameObject btn);
    public static event LaserEnterHandler OnLaserEnter;
    public delegate void LaserExitHandler();
    public static event LaserExitHandler OnLaserExit;
    private GameObject prevButton;
    private GameObject cube;




    void Start()
    {
        //컨트롤러 입력값을 받아옴
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        tr = transform.parent.transform;
        buttonLayer = 1 << LayerMask.NameToLayer("BUTTON"); //1<<8
        floorLayer = 1 << LayerMask.NameToLayer("FLOOR"); //1<<9
        objectLayer = 1 << LayerMask.NameToLayer("OBJECT"); //1<<9
        CreateLine();
    }

    void CreateLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false; //라인이 컨트롤러에 생기도록
        line.receiveShadows = false; //그림자에 반응할지 여부

        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));
        line.startWidth = 0.03f;
        line.endWidth = 0.005f;
        //line.widthMultiplier = 0.01f;
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = defaultColor;
    }


    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, maxDistance, floorLayer))
        {
            if (teleport.GetStateUp(hand))
            {
                SteamVR_Fade.Start(Color.black, 0.0f);
                StartCoroutine(Teleport());

            }

        }
        if (Physics.Raycast(ray, out hit, maxDistance, buttonLayer))
        {
            prevButton = hit.collider.gameObject;
            //Debug.Log(hit.collider.name);
            OnLaserEnter(hit.collider.gameObject);
            if (trigger.GetStateDown(hand))
            {
                ExecuteEvents.Execute(hit.collider.gameObject
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerClickHandler);
            }
        }

        //raycast를
        if (Physics.Raycast(ray, out hit, maxDistance, objectLayer))
        {
            cube = hit.collider.gameObject;
            //Debug.Log(hit.collider.name);
            OnLaserEnter(hit.collider.gameObject);
            if (trigger.GetStateDown(hand))
            {
                ExecuteEvents.Execute(hit.collider.gameObject
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerClickHandler);
            }


            else
            {
                if (prevButton != null)
                {
                    OnLaserExit();
                }
            }


        }
        IEnumerator Teleport()
        {
            tr.position = hit.point;
            yield return new WaitForSeconds(0.1f);
            SteamVR_Fade.Start(Color.clear, 0.2f);
        }
    }
}