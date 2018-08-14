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

	void Start () {
        user = UserData.instance;
        direction = new Vector3[5]
        { new Vector3(-23.704f, 40.49f, -18.944f), new Vector3(8.667001f, 105.308f, -28.833f), new Vector3(30f, 180f, 0f), new Vector3(8.937f, -105.805f, 28.759f), new Vector3(-24.41f, -38.183f, 18.006f) };
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
	
	void Update () {
        GetFrontButton();
        float x;
        switch (user.touchVal[0])
        {
            case 0:
                transform.Rotate(new Vector3(0f, 0.1f, 0f));
                break;
            case 2:
                dif = user.swipeDif.x * 30;
                transform.Rotate(new Vector3(0f, dif, 0f));
                break;
            case 3:
                if (frontButton == 4)
                {
                    toButton = 0;
                }
                else
                {
                    toButton = frontButton + 1;
                }
                user.touchVal[0] = 5;
                break;
            case 4:
                if (frontButton == 0)
                {
                    toButton = 4;
                }
                else
                {
                    toButton = frontButton - 1;
                }
                user.touchVal[0] = 5;
                break;
            case 5:
                x = button[toButton].transform.position.x;
                step = 2.5f * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(direction[toButton]), step);
                if (x >= -0.1f && x <= 0.1f) user.touchVal[0] = 0;
                break;
        }
    }
}
