using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    [SerializeField]
    RectTransform prefab = null;
    Stack<RectTransform> list;
    public Texture2D icon1, icon2, icon3;
    public string mode;

    public void ReDraw()
    {
        for(int i = 0;i < list.Count+1; i++)
        {
            Destroy(list.Pop().gameObject);
        }
        switch (mode)
        {
            case "Class":
                for (int i = 0; i < UserData.instance.classProject.Count; i++)
                {
                    var item = GameObject.Instantiate(prefab) as RectTransform;
                    list.Push(item);
                    item.SetParent(transform, false);
                    //item.position = new Vector3(item.position.x, item.position.y - (i * 100f), item.position.z);
                    var text = item.GetComponentInChildren<Text>();
                    var image = item.GetComponentInChildren<RawImage>();
                    text.text = UserData.instance.classProject[i].className+" "+UserData.instance.classProject[i].title;
                    if (UserData.instance.classProject[i].latency == "Vacant")
                    {
                        image.texture = icon1;
                    }else if(UserData.instance.classProject[i].latency == "OK")
                    {
                        image.texture = icon2;
                    }else if(UserData.instance.classProject[i].latency == "Crowded")
                    {
                        image.texture = icon3;
                    }
                }
                break;
            case "Kodo":
                foreach (TT tt in UserData.instance.kodoTT)
                {
                    var item = GameObject.Instantiate(prefab) as RectTransform;
                    list.Push(item);
                    item.SetParent(transform, false);
                    //item.position = new Vector3(item.position.x, item.position.y - (i * 100f), item.position.z);
                    var text = item.GetComponentInChildren<Text>();
                    var image = item.GetComponentInChildren<RawImage>();
                    text.text = tt.name;
                    image.gameObject.SetActive(false);
                }
                break;
            case "Stage":
                foreach (TT tt in UserData.instance.stageTT)
                {
                    var item = GameObject.Instantiate(prefab) as RectTransform;
                    list.Push(item);
                    item.SetParent(transform, false);
                    //item.position = new Vector3(item.position.x, item.position.y - (i * 100f), item.position.z);
                    var text = item.GetComponentInChildren<Text>();
                    var image = item.GetComponentInChildren<RawImage>();
                    text.text = tt.name;
                    image.gameObject.SetActive(false);
                }

                break;
        }
    }

    void Start()
    {
        mode = "Class";
        list = new Stack<RectTransform>();
        for (int i = 0; i < UserData.instance.classProject.Count; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            list.Push(item);
            item.SetParent(transform, false);
            //item.position = new Vector3(item.position.x, item.position.y - (i * 100f), item.position.z);
            var text = item.GetComponentInChildren<Text>();
            var image = item.GetComponentInChildren<RawImage>();
            text.text = UserData.instance.classProject[i].className + " " + UserData.instance.classProject[i].title;
            if (UserData.instance.classProject[i].latency == "Vacant")
            {
                image.texture = icon1;
            }
            else if (UserData.instance.classProject[i].latency == "OK")
            {
                image.texture = icon2;
            }
            else if (UserData.instance.classProject[i].latency == "Crowded")
            {
                image.texture = icon3;
            }
        }
    }
}