using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonRotate : MonoBehaviour {
    public Transform camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(camera);
	}
}
