using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class BrainPart : MonoBehaviour
{        
    private Renderer rend;
    private Color normalColor;    
    public Color highlightColor = new Color(0.764151f, 0.1534704f, 0.1477839f, 0.5529412f);

    private void OnEnable()
    {       
        LaserPointer.OnLaserEnter += LaserEnter;
        LaserPointer.OnLaserClick += LaserClick;
        LaserPointer.OnLaserExit += LaserExit;
    }
    private void OnDisable()
    {
        LaserPointer.OnLaserEnter -= LaserEnter;
        LaserPointer.OnLaserClick -= LaserClick;
        LaserPointer.OnLaserExit -= LaserExit;

    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        normalColor = GetComponent<Renderer>().material.color;
       
        // mat = Resources.Load<GameObject>("TestColor");

    }
    void update() {

    }    
    void LaserEnter(GameObject cBrain) 
    {
        if (gameObject == cBrain)
        {
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
            rend.material.color = highlightColor;
        }
    }
    void LaserClick()
    {
        ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
              

    }
    void LaserExit(GameObject pBrain)
    {
        if (gameObject == pBrain)
        {
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            rend.material.color = normalColor;

        }
    }
}
