using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour {
    public ScrollController scroll;
    public RawImage lamp;
    public Texture2D lamp1, lamp2, lamp3;
    float speed = 3f;
    float step;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (scroll.mode == "Class")
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), step);
            lamp.texture = lamp1;
        }else if (scroll.mode == "Stage")
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 13.5f), step);
            lamp.texture = lamp2;
        }else if (scroll.mode == "Kodo")
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 6.7f), step);
            lamp.texture = lamp3;
        }
    }
}
