using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendbutton : MonoBehaviour {

	// Use this for initialization
    public void Onclick()
    {
        UserData.instance.UpAnswer();
    }


}
