using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Billboard : MonoBehaviour
{
    private Transform camTr;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        camTr = GameObject.Find("[CameraRig]/Camera").GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.LookAt(camTr.position);
    }
}
