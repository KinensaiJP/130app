using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMap2DController : MonoBehaviour {

    bool moveActive = true;

    public GameObject camera;

    //回転用
    Vector2 sPos;   //タッチした座標
    Vector3 sRot;//タッチしたときの回転
    float wid, hei, diag;  //スクリーンサイズ
    float tx, ty;    //変数

    public int kando = 3;

    //ピンチイン ピンチアウト用
    float vMin = 0.5f, vMax = 2.0f;  //倍率制限
    float sDist = 0.0f, nDist = 0.0f; //距離変数
    Vector3 initScale; //最初の大きさ
    float v = 1.0f; //現在倍率

    // Use this for initialization
    void Start () {

        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
        initScale = camera.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {

        if (moveActive)
        {
            //移動
            TouchInfo info = TouchUtil.GetTouch();
            if (info == TouchInfo.Began)
            {
                sPos = TouchUtil.GetTouchPosition();
                sRot = camera.transform.position;
            }
            else if (info == TouchInfo.Moved || info == TouchInfo.Stationary)
            {
                tx = (TouchUtil.GetTouchPosition().x - sPos.x) / wid; //横移動量(-1<tx<1)
                ty = (TouchUtil.GetTouchPosition().y - sPos.y) / hei; //縦移動量(-1<ty<1)

                camera.transform.position = sRot + new Vector3(kando * tx, 0,  kando * ty);
            }
        }


    }
}
