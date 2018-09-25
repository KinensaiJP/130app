using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObjectScript : MonoBehaviour {

    public GameObject[] button = new GameObject[5];
    public int frontButton;

    private UserData user;
    private float dif;
    private Vector3[] direction;
    private float step;
    private int toButton;

    public GameObject obj;

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
    

    void Start () {
        user = UserData.instance;
        direction = new Vector3[5]
        { new Vector3(-23.704f, 40.49f, -18.944f), new Vector3(8.667001f, 105.308f, -28.833f), new Vector3(30f, 180f, 0f), new Vector3(8.937f, -105.805f, 28.759f), new Vector3(-24.41f, -38.183f, 18.006f) };
        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
        initScale = obj.transform.localScale;
    }
	
    void GetFrontButton()
    {
        float min = 0f;
        for (int i = 0; i < 5; i++)
        {
            if (min > button[i].transform.position.z)
            {
                frontButton = i;
                min = button[i].transform.position.z;
            }
        }
    }

    Quaternion b1;
    Quaternion b2;

    void Update ()
    {

        obj.transform.Rotate(new Vector3(0, -30 * tx / 1.2f, 0), Space.Self);
        tx /= 1.2f;
        
        if (TouchUtil.GetTouchPosition() != Vector3.zero)
        {
            TouchInfo info = TouchUtil.GetTouch();
            if (info == TouchInfo.Began)
            {
                sPos = TouchUtil.GetTouchPosition();
                sRot = obj.transform.rotation;
            }
            else if (info == TouchInfo.Moved)
            {
                tx = (TouchUtil.GetTouchPosition().x - sPos.x) / wid;
                ty = (TouchUtil.GetTouchPosition().y - sPos.y) / hei;
                
                obj.transform.rotation = sRot;
                obj.transform.Rotate(new Vector3(0, -90 * tx, 0), Space.Self);
            }
        }
        else
        {
           if(!(Mathf.Abs(tx) > 0.01f))
            {
                tx = -0.01f;
            }
        }
    }
}
