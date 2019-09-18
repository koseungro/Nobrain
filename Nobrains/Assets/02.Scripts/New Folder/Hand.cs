using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    private Transform tr;    
    private GameObject brain;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.layer == 8) {
            brain = other.gameObject;
            brain.transform.SetParent(tr);
            brain.GetComponent<Rigidbody>().isKinematic = true;
            
        }
    }
}