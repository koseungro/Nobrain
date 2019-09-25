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
    }
    private void OnDisable()
    {
        LaserPointer.OnLaserEnter -= LaserEnter;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayAnim()
    {
        //애니메이션 실행
        switch (selectedBrain.tag)
        {
            case "frontal":                
                anim.SetTrigger("hash_frontal");
                break;
            case "parietal":
                anim.SetTrigger("hash_parietal");
                break;
            case "temporal":
                anim.SetTrigger("hash_temporal");
                break;
            case "occipital":
                anim.SetTrigger("hash_occipital");
                break;
            case "Broca":
                anim.SetTrigger("hash_Broca");
                break;
            case "Wernicke":
                anim.SetTrigger("hash_Wernicke");
                break;
            case "diencephaion":
                anim.SetTrigger("hash_diencephaion");
                break;
            case "stem":
                anim.SetTrigger("hash_stem");
                break;
            case "cerebellum":
                anim.SetTrigger("hash_cerebellum");
                break;
        }

    }

    void LaserEnter(GameObject brain)
    {
        selectedBrain = brain;
    }


}
