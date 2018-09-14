using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour {
    public ScrollController scroll;
    public KikakuList kikakuList;
    public RawImage lamp;
    public Texture2D lamp1, lamp2, lamp3, lamp4;
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
            kikakuList.mode.text = "クラス";
        }
        else if (scroll.mode == "Stage")
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 13.5f), step);
            lamp.texture = lamp2;
            kikakuList.mode.text = "ステージ";
        }
        else if (scroll.mode == "Kodo")
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 6.7f), step);
            lamp.texture = lamp3;
            kikakuList.mode.text = "講堂";
        }
        else if (scroll.mode == "Club")
        {
            step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 19.2f), step);
            lamp.texture = lamp4;
            kikakuList.mode.text = "クラブ";
        }
    }
}
