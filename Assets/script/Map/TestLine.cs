using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLine : MonoBehaviour {

    public GameObject lineCanvas;
    public Camera worldCamera;
    public GameObject text;
    LineRenderer lr;
    // Use this for initialization
    void Start ()
    {
      lr = lineCanvas.GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 one = GameObject.Find("Hide体育館").transform.position;
        Vector3 two = Vector3.zero;
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(lineCanvas.GetComponent<RectTransform>(), new Vector2(50f, 50f), worldCamera, out one);
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(lineCanvas.GetComponent<RectTransform>(), text.transform.position, worldCamera, out two);

        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.SetPosition(0, one);
        lr.SetPosition(1, text.transform.position);
    }
}
