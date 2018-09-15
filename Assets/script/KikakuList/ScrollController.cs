using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    [SerializeField]
    RectTransform prefab = null;
    [SerializeField]
    ScrollRect scrollRect;
    [SerializeField]
    RectTransform classObject, kodoObject, stageObject, clubObject;
    RectTransform scrollTransform, thisRecttransform;
    Stack<RectTransform> list;
    public Texture2D icon1, icon2, icon3;
    public string mode;
    public float[] posSnap;
    float numOfRow;
    int objectNum;

    public void ReDraw(int snap)
    {
        thisRecttransform.anchoredPosition = new Vector3(0f, posSnap[snap]+10, 0f);
    }

    void Start()
    {
        thisRecttransform = GetComponent<RectTransform>();
        mode = "Class";
        list = new Stack<RectTransform>();
        scrollTransform = scrollRect.GetComponent<RectTransform>();
        posSnap = new float[4];
        posSnap[0] = 0.0f;

        var item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(classObject.transform, false);
        var text = item.GetComponentInChildren<Text>();
        text.text = "<size=60>クラス企画</size>";
        var image = item.GetComponentInChildren<RawImage>();
        image.gameObject.SetActive(false);
        var button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);

        for (int i = 0; i < UserData.instance.classProject.Count; i++)
        {
            item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(classObject.transform, false);
            text = item.GetComponentInChildren<Text>();
            image = item.GetComponentInChildren<RawImage>();
            if (UserData.instance.classProject[i].className.StartsWith("H"))
                text.text = "高校";
            else
                text.text = "中学";
            text.text += UserData.instance.classProject[i].className.Substring(1, 2) + "\n" + UserData.instance.classProject[i].title;
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

        Space("講堂企画", 1, kodoObject);
        string lastIventName = "";
        foreach (TT tt in UserData.instance.kodoTT)
        {
            if (lastIventName != tt.iventName)
            {
                item = GameObject.Instantiate(prefab) as RectTransform;
                item.SetParent(kodoObject.transform, false);
                text = item.GetComponentInChildren<Text>();
                text.text = "<size=42><b>" + tt.iventName + "</b></size>";
                text.alignment = TextAnchor.MiddleCenter;
                image = item.GetComponentInChildren<RawImage>();
                image.gameObject.SetActive(false);
                button = item.GetComponentInChildren<Button>();
                button.gameObject.SetActive(false);
                lastIventName = tt.iventName;
            }
            item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(kodoObject.transform, false);
            text = item.GetComponentInChildren<Text>();
            image = item.GetComponentInChildren<RawImage>();
            text.text = tt.name;
            image.gameObject.SetActive(false);
        }

        Space("ステージ企画", 2, stageObject);
        foreach (TT tt in UserData.instance.stageTT)
        {
            if (lastIventName != tt.iventName)
            {
                item = GameObject.Instantiate(prefab) as RectTransform;
                item.SetParent(stageObject.transform, false);
                text = item.GetComponentInChildren<Text>();
                text.text = "<size=42><b>" + tt.iventName + "</b></size>";
                text.alignment = TextAnchor.MiddleCenter;
                image = item.GetComponentInChildren<RawImage>();
                image.gameObject.SetActive(false);
                button = item.GetComponentInChildren<Button>();
                button.gameObject.SetActive(false);
                lastIventName = tt.iventName;
            }
            item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(stageObject.transform, false);
            text = item.GetComponentInChildren<Text>();
            image = item.GetComponentInChildren<RawImage>();
            text.text = tt.name;
            image.gameObject.SetActive(false);
        }

        Space("クラブ企画", 3, clubObject);
        foreach (ClubProjectList param in UserData.instance.clubProject)
        {
            item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(clubObject.transform, false);
            text = item.GetComponentInChildren<Text>();
            image = item.GetComponentInChildren<RawImage>();
            text.text = param.name;
            image.gameObject.SetActive(false);
        }

        posSnap[0] = 0f;
        posSnap[1] = classObject.transform.childCount * 104f;
        posSnap[2] = posSnap[1] + kodoObject.childCount * 104f;
        posSnap[3] = posSnap[2] + stageObject.childCount * 104f;

        Debug.Log(objectNum = list.Count);

    }

    void Update()
    {
        float presentPos = thisRecttransform.anchoredPosition.y;
        if (presentPos <= posSnap[1]) mode = "Class";
        else if (posSnap[1] < presentPos && presentPos <= posSnap[2]) mode = "Kodo";
        else if (posSnap[2] < presentPos && presentPos <= posSnap[3]) mode = "Stage";
        else mode = "Club";
    }

    void Space(string title_,int index_,RectTransform rect_)
    {
        var item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(rect_.transform, false);
        var text = item.GetComponentInChildren<Text>();
        text.text = "";
        var image = item.GetComponentInChildren<RawImage>();
        image.gameObject.SetActive(false);
        var button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
        posSnap[index_] = list.Count;
        item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(rect_.transform, false);
        text = item.GetComponentInChildren<Text>();
        text.text = "<size=60>"+title_+"</size>";
        image = item.GetComponentInChildren<RawImage>();
        image.gameObject.SetActive(false);
        button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
    }

}