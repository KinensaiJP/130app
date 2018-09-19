using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3DText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(Camera.main.transform);
        this.transform.Rotate(new Vector3(0f, 180f, 0f));
	}
}
