using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KikakuList : MonoBehaviour {
    public Text mode;
    public GameObject scroll;
    ScrollController scroll_class;
	// Use this for initialization
	void Start () {
        scroll_class = scroll.GetComponent<ScrollController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (scroll_class.mode == "Class")
        {
            scroll_class.mode = "Kodo";
            mode.text = "講堂";
            scroll_class.ReDraw(1);
        }else if (scroll_class.mode == "Kodo")
        {
            scroll_class.mode = "Stage";
            mode.text = "ステージ";
            scroll_class.ReDraw(2);
        }else if (scroll_class.mode == "Stage")
        {
            scroll_class.mode = "Club";
            mode.text = "クラブ";
            scroll_class.ReDraw(3);
        }else if (scroll_class.mode == "Club")
        {
            scroll_class.mode = "Class";
            mode.text = "クラス";
            scroll_class.ReDraw(0);
        }
    }
}
