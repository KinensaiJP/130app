using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClassProject : MonoBehaviour {

    public Text title, className, description;
    public RawImage image;
    public Texture texture;

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
                    if (command.StartsWith("H")) className.text = "高校";
                    else className.text = "中学";

                    className.text += command.Substring(1, 2);

                    if (param.title.Length < 9)
                    {
                        title.text = "<size=70>"+param.title+"</size>";
                    }
                    else
                    {
                        title.text = "<size=60>" + param.title + "</size>";
                    }
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
                    className.text = param.iventName;
                    if (param.name.Length < 9)
                    {
                        title.text = "<size=70>" + param.name + "</size>";
                    }
                    else
                    {
                        title.text = "<size=60>" + param.name + "</size>";
                    }
                    description.text = "場所: " + param.place + "\n\nメンバー:\n" + param.member + "\n\n開始時間:" + param.dtime;
                    url = param.imageURL;
                }
            }
            foreach (TT param in user.stageTT)
            {
                if (command == param.name)
                {
                    className.text = "<size=48>" + "ﾊﾟﾌｫｰﾏﾝｽ大会" + "</size>";
                    if (param.name.Length < 9)
                    {
                        title.text = "<size=70>" + param.name + "</size>";
                    }
                    else
                    {
                        title.text = "<size=60>" + param.name + "</size>";
                    }
                    description.text = "場所: " + param.place + "\n\nメンバー:\n" + param.member + "\n\n開始時間:" + param.dtime;
                    url = param.imageURL;
                }
            }
            if (url != "") StartCoroutine(GetImage());
            else image.gameObject.SetActive(false);
        }

    }

    private IEnumerator GetImage()
    {
            WWW www = new WWW("https://api.kinensai.jp/image/" + url);
            yield return www;
            image.texture = www.textureNonReadable;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
