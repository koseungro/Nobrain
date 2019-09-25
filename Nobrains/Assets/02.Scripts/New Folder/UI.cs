using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;


public class UI : MonoBehaviour
{

    private GameObject selectedUI;
    private bool UIOpen = false;

    private Transform prevUI;
    private Transform currUI;

    private void OnEnable()
    {
        LaserPointer.OnLaserEnter += LaserEnter;

    }
    private void OnDisable()
    {
        LaserPointer.OnLaserEnter -= LaserEnter;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayUI()
    {

        //애니메이션 실행
        switch (selectedUI.tag)
        {
            case "frontal":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("FrontalPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "parietal":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("ParietalPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "temporal":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("TemporalPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "occipital":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("OccipitalPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "Broca":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("BrocaPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "Wernicke":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("WernickePanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "diencephaion":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("DiencephalonPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "stem":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("BrainstemPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
            case "cerebellum":
                if (prevUI != null)
                {
                    prevUI.gameObject.SetActive(false);
                }
                currUI = gameObject.transform.Find("CerebellumPanel");
                currUI.gameObject.SetActive(true);
                prevUI = currUI;
                break;
        }

    }

    void LaserEnter(GameObject brain)
    {
        selectedUI = brain;
    }

}