﻿using System.Collections;
using System.Collections.Generic;
using System;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour {

    public FlickGesture flickGesture;
    public Button back;
    public bool enable;
    Vector3 deffalt;
    bool lastSwitch;
    private void OnEnable()
    {
        flickGesture.Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        flickGesture.Flicked -= OnFlicked;
    }

    private void OnFlicked(object sender, EventArgs e)
    {
        Debug.Log("フリックされた: " + flickGesture.ScreenFlickVector + (flickGesture.ScreenPosition.x - flickGesture.ScreenFlickVector.x));
        
        if (enable == false && flickGesture.ScreenFlickVector.x > 0 && flickGesture.ScreenPosition.x- flickGesture.ScreenFlickVector.x< 60f)
        {
            enable = true;
        }
        if (enable == true && flickGesture.ScreenFlickVector.x < 0)
        {
            enable = false;
        }
    }

    // Use this for initialization
    void Start () {
        enable = false;
        deffalt = transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (lastSwitch != enable)
        {
            if (enable == false)
            {
                if (transform.localPosition.x > deffalt.x)
                    transform.localPosition = new Vector3(transform.localPosition.x - 2500f * Time.deltaTime, 0f, 0f);
                else
                {
                    transform.localPosition = new Vector3(deffalt.x, 0f, 0f);
                    lastSwitch = enable;
                }
                back.gameObject.SetActive(false);
            }
            else
            {
                if (transform.localPosition.x < deffalt.x + 800f)
                    transform.localPosition = new Vector3(transform.localPosition.x + 2500f * Time.deltaTime, 0f, 0f);
                else
                {
                    transform.localPosition = new Vector3(deffalt.x + 900f, 0f, 0f);
                    lastSwitch = enable;
                }
                back.gameObject.SetActive(true);
            }
        }
    }
}
