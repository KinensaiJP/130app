using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule.Mathf;

public class DisplayConfig : MonoBehaviour {
    private Camera cam;
    private float width = 9f;
    private float height = 16f;


    private void  displayupdate()
    {
        float aspect = (float)Screen.height / (float)Screen.width;
        float bgAcpect = height / width;    
        cam = GetComponent<Camera>();
        if (bgAcpect > aspect)
        {
            //
        }
        else
        {
            cam.fieldOfView = 35f * (1 / cam.aspect);
        }
    }

    void Awake()
    {
        displayupdate();
    }

    void Update()
    {
        //displayupdate();//todo if: boolean
    }
}   
