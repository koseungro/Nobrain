using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class GobController : MonoBehaviour
{
    private Animator anim;    
    private GameObject selectedBrain;

    private void OnEnable()
    {
        LaserPointer.OnLaserEnter += LaserEnter;
        LaserPointer.OnLaserClick += LaserClick;

    }
    private void OnDisable()
    {
        LaserPointer.OnLaserEnter -= LaserEnter;
        LaserPointer.OnLaserClick -= LaserClick;

    }

    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LaserClick()
    {
        //애니메이션 실행
        switch(selectedBrain.tag)
        {
            case "aaa":
                //anim.SetBool("", true);
                break;
            case "bbb":
                //anim.SetBool("", true);
                break;
        }

    }

    void LaserEnter(GameObject brain)
    {
        selectedBrain = brain;
    }


}
