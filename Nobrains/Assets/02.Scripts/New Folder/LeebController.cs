using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class LeebController : MonoBehaviour
{
    private Animator anim;
    private GameObject selectedBrain;

    private void OnEnable()
    {
        LaserPointer.OnLaserEnter += LaserEnter;
        //LaserPointer.OnLaserClick += LaserClick;

    }
    private void OnDisable()
    {
        LaserPointer.OnLaserEnter -= LaserEnter;
        //LaserPointer.OnLaserClick -= LaserClick;

    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        //애니메이션 실행
        switch (selectedBrain.tag)
        {            
            case "frontal":
                anim.SetTrigger("hash_frontal");
                break;            
            case "temporal":
                anim.SetTrigger("hash_temporal");
                break;
            case "occipital":
                anim.SetTrigger("hash_occipital");
                break;            
        }
    }

    void LaserEnter(GameObject brain)
    {
        selectedBrain = brain;
    }
    


}