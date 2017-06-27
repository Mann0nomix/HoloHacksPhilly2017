using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycast : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 50, 0)) {
            //if(select gesture){
                //SpeechCommands sc = hit.transform.gameObject.GetComponent<SpeechCommands>();
                //sc.OnSelect();
            //}
        }
    }
}
