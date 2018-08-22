using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnketController : MonoBehaviour {

    public Toggle q1_1;
    public Toggle q1_2;
    public Toggle q1_3;
    public Toggle q1_4;
    public InputField q1_5;
    public InputField q2;
    public InputField q3;
    public Toggle q4_1;
    public Toggle q4_2;
    public Toggle q4_3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBackButton()
    {
        SceneManager.LoadScene(UserData.instance.lastMode.Pop());
    }

    public void OnSendButton()
    {
        UserData.instance.user.anke1 =
            toInt(q1_1.isOn) + 2 * toInt(q1_2.isOn) + 4 * toInt(q1_3.isOn) + 8 * toInt(q1_4.isOn);
        UserData.instance.user.anke23[0] =
            q1_5.text;
        UserData.instance.user.anke23[1] =
            q2.text;
        UserData.instance.user.anke23[2] =
            q3.text;
        UserData.instance.user.anke4 =
            toInt(q4_1.isOn) + 2 * toInt(q4_2.isOn) + 4 * toInt(q4_3.isOn);

        UserData.instance.UpAnswer();
    }

    private int toInt(bool b)
    {
        return b == true ? 1 : 0;
    } 

}
