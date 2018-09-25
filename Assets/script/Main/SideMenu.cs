using System.Collections;
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

    public GameObject obj;
    //回転用
    Vector2 sPos;   //タッチした座標
    Quaternion sRot;//タッチしたときの回転
    Quaternion cRot;//タッチしたときの回転
    float wid, hei, diag;  //スクリーンサイズ
    float tx, ty;    //変数

    Quaternion beforeRotation;

    //ピンチイン ピンチアウト用
    float vMin = 0.5f, vMax = 2.0f;  //倍率制限
    float sDist = 0.0f, nDist = 0.0f; //距離変数
    Vector3 initScale; //最初の大きさ
    float v = 1.0f; //現在倍率

    private void OnEnable()
    {
        //flickGesture.Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        //flickGesture.Flicked -= OnFlicked;
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

        wid = Screen.width;
        hei = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {

        if (TouchUtil.GetTouch() != TouchInfo.None)
        {
            //回転
            TouchInfo info = TouchUtil.GetTouch();
            if (info == TouchInfo.Began)
            {
                sPos = TouchUtil.GetTouchPosition();
                sRot = obj.transform.rotation;


            }
            else if (info == TouchInfo.Moved)
            {
                tx = (TouchUtil.GetTouchPosition().x - sPos.x) / wid;

                if (sPos.x < 30)
                {
                    //Debug.Log(tx);
                    float buf = wid * 2 * tx;
                    if (buf > 900f) buf = 900f;
                    obj.transform.localPosition = deffalt + new Vector3(buf, 0, 0);
                    if(wid * 2 * tx > 100)
                    {
                        enable = true;
                    }
                }

            }

        }
        else
        {

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
}
