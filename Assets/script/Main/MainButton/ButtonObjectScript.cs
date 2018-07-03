using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 0.2f, 0f));
	}
}
