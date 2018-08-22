using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadProjects : MonoBehaviour {
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (GetComponentInParent<ScrollController>().mode == "Class")
            UserData.instance.command = text.text.Substring(0, 3);
        else
            UserData.instance.command = text.text;
        UserData.instance.lastMode.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Projects");
    }
}
