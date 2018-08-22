using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//まわす
public class MapModelRotation : MonoBehaviour {
    public GameObject obj;

    public bool active = true;

    //回転用
    Vector2 sPos;   //タッチした座標
    Quaternion sRot;//タッチしたときの回転
    float wid, hei, diag;  //スクリーンサイズ
    float tx, ty;    //変数

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
            }
            else if (info == TouchInfo.Moved || info == TouchInfo.Stationary)
            {
                tx = (TouchUtil.GetTouchPosition().x - sPos.x) / wid; //横移動量(-1<tx<1)
               // ty = (TouchUtil.GetTouchPosition().y - sPos.y) / hei; //縦移動量(-1<ty<1)
                obj.transform.rotation = sRot;
                obj.transform.Rotate(new Vector3(90 * ty, -90 * tx, 0), Space.World);
            }
        }
        /*
        else if (Input.touchCount >= 2)
        {
            //ピンチイン ピンチアウト
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);
            if (t2.phase == TouchPhase.Began)
            {
                sDist = Vector2.Distance(t1.position, t2.position);
            }
            else if ((t1.phase == TouchPhase.Moved || t1.phase == TouchPhase.Stationary) &&
                     (t2.phase == TouchPhase.Moved || t2.phase == TouchPhase.Stationary))
            {
                nDist = Vector2.Distance(t1.position, t2.position);
                v = v + (nDist - sDist) / diag;
                sDist = nDist;
                if (v > vMax) v = vMax;
                if (v < vMin) v = vMin;
                obj.transform.localScale = initScale * v;
            }
        }*/
    }
    
}
