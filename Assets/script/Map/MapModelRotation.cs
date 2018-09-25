using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//まわす
public class MapModelRotation : MonoBehaviour {

    public GameObject obj;
    public GameObject cameraMaster;
    public GameObject camera;

    public bool active = true;

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

    public void ratchActive()
    {
        active = !active;
    }

    void Start()
    {
        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
        initScale = obj.transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount == 1 || active)
        {
            //回転
            //Touch t1 = Input.GetTouch(0);
            TouchInfo info = TouchUtil.GetTouch();
            if (info == TouchInfo.Began)
            {
                sPos = TouchUtil.GetTouchPosition();
                sRot = obj.transform.rotation;
                cRot = cameraMaster.transform.rotation;
            }
            else if (info == TouchInfo.Moved || info == TouchInfo.Stationary)
            {
                tx = (TouchUtil.GetTouchPosition().x - sPos.x) / wid; 
                ty = (TouchUtil.GetTouchPosition().y - sPos.y) / hei; 


                obj.transform.rotation = sRot;
                cameraMaster.transform.rotation = cRot;
                obj.transform.Rotate(new Vector3(0, -90 * tx, 0), Space.World);
                
               cameraMaster.transform.Rotate(new Vector3(-90 * ty, 0), Space.World);

                if((cameraMaster.transform.localEulerAngles.x > 85) 
                    || (cameraMaster.transform.localEulerAngles.x < 5)
                    || cameraMaster.transform.localEulerAngles.y > 90 )
                {
                    cameraMaster.transform.rotation = beforeRotation;
                 } 

                Debug.Log(obj.transform.localEulerAngles.y);


                beforeRotation = cameraMaster.transform.rotation;
            }
        }
    }
    
}
