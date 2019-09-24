using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class PlatformController : MonoBehaviour
{
    private Animator anim;
    private GameObject selectedBrain;
    public GameObject Gob;
    public GameObject Leeb;

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
    public void CharaterAnim()
    {
        Gob.SendMessage("PlayAnim", SendMessageOptions.DontRequireReceiver);
        Leeb.SendMessage("PlayAnim", SendMessageOptions.DontRequireReceiver);
    }

    void LaserClick()
    {
        //애니메이션 실행
        anim.SetTrigger("play_animation");

    }

    void LaserEnter(GameObject brain)
    {
        selectedBrain = brain;
    }


}