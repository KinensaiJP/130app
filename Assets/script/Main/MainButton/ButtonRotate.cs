using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonRotate : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(new Vector3(transform.position.x, 1.0f, transform.position.z - 10.0f));
        transform.eulerAngles = new Vector3(-15.0f, 180.0f, 0.0f);
	}
}
