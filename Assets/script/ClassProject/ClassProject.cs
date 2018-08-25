using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ClassProject : MonoBehaviour {

    public Text title, className, description;
    public RawImage image;

    private UserData user;
    private string command;
    private string url;
    private string format;
    private int index;
    private List<ClassProjectList> list;
	// Use this for initialization
	void Start () {
        user = UserData.instance;

        command = user.command;
        Debug.Log(command);

        if (command.Length == 3)
        {
            list = user.classProject;
            index = 0;
            foreach (ClassProjectList param in list)
            {
                if (command == param.className)
                {
                    className.text = command;
                    title.text = param.title;
                    description.text = param.description;
                    url = param.imageURL;
                    format = param.format;
                    StartCoroutine(GetImage());
                }
            }
        }
        else
        {
            foreach (TT param in user.kodoTT)
            {
                if (command == param.name)
                {
                    title.text = param.name;
                    description.text = "場所: " + param.place + "\n\nメンバー:\n" + param.member + "\n\n開始時間:" + param.dtime;
                }
            }
            foreach (TT param in user.stageTT)
            {
                if (command == param.name)
                {
                    title.text = param.name;
                    description.text = "場所: " + param.place + "\n\nメンバー:\n" + param.member + "\n\n開始時間:" + param.dtime;
                }
            }

        }

    }

    private IEnumerator GetImage()
    {
        WWW www = new WWW("http://localhost/image/"+url);
        yield return www;
        image.texture = www.textureNonReadable;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
