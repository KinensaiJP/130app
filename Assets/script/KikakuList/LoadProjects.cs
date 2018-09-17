using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadProjects : MonoBehaviour {
    public Text text;
    public RawImage rawImage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (rawImage.gameObject.activeSelf)
        {
            if (text.text.StartsWith("高")) UserData.instance.command = "H";
            else UserData.instance.command = "J";
            UserData.instance.command += text.text.Substring(2, 2);
        }
        else
            UserData.instance.command = text.text;
        UserData.instance.lastMode.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Projects");
    }
}
