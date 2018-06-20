using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    public float StartPos;
    public float EndPos;

    public Camera mainCamera;
    public GameObject main;

    void Start()
    {
       // mainCamera = GameObject.Find("MainCamera").GetComponent();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartPos = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndPos = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            if (StartPos > EndPos)
            {
                mainCamera.transform.position = new Vector3(main.transform.position.x + 10, main.transform.position.y, -10);
            }
            else if (StartPos < EndPos)
            {
                mainCamera.transform.position = new Vector3(main.transform.position.x - 10, main.transform.position.y, -10);
            }
            StartPos = 0;
            EndPos = 0;
        }
    }
}