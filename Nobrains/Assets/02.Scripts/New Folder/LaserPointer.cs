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
    private GameObject pointer;

    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    public float range = 20f;
    // public Color defaultColor = Color.green;

    private RaycastHit hit;
    private Ray ray;
    private int brainLayer;
    private int animLayer;
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
        animLayer = 1 << LayerMask.NameToLayer("BRAIN_ANIM");

        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate(_pointer);

        CreateLine();

    }

    void Update()
    {
        Pointer();
        BrainPart();
        ClickButton();

        if (trigger.GetStateDown(hand) && Physics.Raycast(ray, out hit, range, brainLayer))
        {
            ClickUI();
        }
        else if (trigger.GetStateDown(hand) && Physics.Raycast(ray, out hit, range, animLayer))
        {
            ClickAnim();
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
    void Pointer()
    {
        ray = new Ray(tr.position, tr.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            line.SetPosition(1, new Vector3(0, 0, hit.distance)); //라인이 오브젝트에 닿으면 그 hit을 끝점으로
            if (hit.collider.gameObject.layer == 8 || hit.collider.gameObject.layer == 5) //만약 라인이 뇌에 닿으면 포인터 생성
            {
                pointer.transform.gameObject.SetActive(true);
                pointer.transform.position = hit.point;
                pointer.transform.rotation = Quaternion.LookRotation(hit.normal); //포인터의 각도 조정

            }
            else //라인이 뇌가 아닌 오브젝트에 닿으면 포인터 비활성화
            {
                pointer.transform.gameObject.SetActive(false);
            }
        }
        else //라인이 오브젝트에 닿지 않으면 길이 그대로, 포인터 비활성화
        {
            line.SetPosition(1, new Vector3(0, 0, range));
            pointer.transform.gameObject.SetActive(false);
        }
        // if (!Physics.Raycast(ray, out hit, range))
        // {
        //     line.SetPosition(1, new Vector3(0, 0, range));
        // }
    }
    void BrainPart()
    {
        if (Physics.Raycast(ray, out hit, range, brainLayer | animLayer))
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
        if (!uiClick /*&& Physics.Raycast(ray, out hit, range, brainLayer)*/) //뇌 부분 별 설명UI 켜기
        {
            hit.collider.gameObject.transform.Find("Canvas").gameObject.SetActive(true);
            uiClick = true;
        }
        else if (uiClick /*&& Physics.Raycast(ray, out hit, range, brainLayer)*/) //뇌 부분 별 설명UI 끄기
        {
            hit.collider.gameObject.transform.Find("Canvas").gameObject.SetActive(false);
            uiClick = false;
        }
        // if (Physics.Raycast(ray, out hit, range, 1 << 5)) //Scene 이동 버튼 클릭
        // {
        //     Debug.Log("Button!");
        //     if (trigger.GetStateDown(hand))
        //     {
        //         ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        //     }
        // }
    }
    void ClickAnim()
    {
        Debug.Log("HIHIHI");
    }

    void ClickButton() {
        if (Physics.Raycast(ray, out hit, range, 1 << 5)) //Scene 이동 버튼 클릭
        {
            Debug.Log("Button!");
            if (trigger.GetStateDown(hand))
            {
                ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
        }
    }

}
