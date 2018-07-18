using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ClassProject : MonoBehaviour {

    public Text title, className, description;
    public RawImage image;

    private string command;
    private int index;
	// Use this for initialization
	void Start () {
        command = UserData.instance.command;

        for (index = 0; command != UserData.instance.classProject.eachClass[index].className; index++) ;
        className.text = command.Substring(0, 1) + "-" + command.Substring(1, 1);
        title.text = UserData.instance.classProject.eachClass[index].title;
        description.text = UserData.instance.classProject.eachClass[index].description;
        UserData.instance.command = "";
    }

    private IEnumerator GetImage()
    {
        WWW www = new WWW("http://localhost/image/"+ UserData.instance.classProject.eachClass[index].description);
        yield return www;
        image.texture = www.textureNonReadable;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
