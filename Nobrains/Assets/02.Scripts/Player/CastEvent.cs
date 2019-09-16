using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
using Valve.VR.Extras;


public class CastEvent : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;
    void OnEnable()
    {
        laserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

        laserPointer.PointerIn += OnPointerEnter;
        laserPointer.PointerOut += OnPointerExit;
        laserPointer.PointerClick += OnPointerClick;
    }
    void OnDisable()
    {
        laserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

        laserPointer.PointerIn -= OnPointerEnter;
        laserPointer.PointerOut -= OnPointerExit;
        laserPointer.PointerClick -= OnPointerClick;

    }
    void OnPointerEnter(object sender, PointerEventArgs e)
    {
        IPointerEnterHandler enterHandler = e.target.GetComponent<IPointerEnterHandler>();
        enterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));
    }

    void OnPointerExit(object sender, PointerEventArgs e)
    {
        IPointerExitHandler exitHandler = e.target.GetComponent<IPointerExitHandler>();
        exitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
    }

    void OnPointerClick(object sender, PointerEventArgs e)
    {
        IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
        clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));

        // ExecuteEvents.Execute(e.target.gameObject
        // , new PointerEventData(EventSystem.current)
        // , ExecuteEvents.pointerClickHandler);
    }
}