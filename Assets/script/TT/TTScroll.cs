using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TTScroll : MonoBehaviour {
    public RectTransform prefab;
    List<RectTransform> buttonList;

    // Use this for initialization
    void Start()
    {
        buttonList = new List<RectTransform> { };
        var item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        var text = item.GetComponentInChildren<Text>();
        text.text = "ステージ企画";
        var button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
        Space("パフォーマンス大会");
        Space("29日(土)");
        Stage(29);
        Space("30日(日)");
        Stage(30);

        item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        text = item.GetComponentInChildren<Text>();
        text.text = "";
        button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
        var panel = item.Find("Panel");
        panel.gameObject.SetActive(false);

        item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        text = item.GetComponentInChildren<Text>();
        text.text = "講堂企画";
        button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);

        Space("29日(土)/音楽祭");
        Kodo("音楽祭");
        Space("30日(日)");
        Space("クラブ･有志発表");
        Kodo("クラブ･有志発表");
        Space("T-TED");
        Kodo("T-TED");

    }

    public void AllButtonOff()
    {
        foreach (var param in buttonList)
        {
            param.GetComponentInChildren<TTBooking>().buttonObject.gameObject.SetActive(false);
        }
    }

    void Stage(int date_)
    {
        foreach (TT tt in UserData.instance.stageTT)
        {   
            if (date_ == Int32.Parse(tt.dtime.Substring(3, 2)))
            {
                var item = GameObject.Instantiate(prefab) as RectTransform;
                item.SetParent(transform, false);
                var text = item.GetComponentInChildren<Text>();
                text.text = "<size=50>" + tt.dtime.Substring(6, 5) + " " + tt.name + "</size>";
                var name = item.GetComponentInChildren<TTClick>();
                name.text = tt.name;
                var book = item.GetComponentInChildren<TTBooking>();
                book.id = tt.ID.ToString();
                buttonList.Add(item);
            }
        }

    }

    void Kodo(string iventName_)
    {
        foreach (TT tt in UserData.instance.kodoTT)
        {
            if (tt.iventName == iventName_)
            {
                var item = GameObject.Instantiate(prefab) as RectTransform;
                item.SetParent(transform, false);
                var text = item.GetComponentInChildren<Text>();
                text.text = "<size=50>" + tt.dtime.Substring(6, 5) + " " + tt.name + "</size>";
                var name = item.GetComponentInChildren<TTClick>();
                name.text = tt.name;
                var book = item.GetComponentInChildren<TTBooking>();
                book.id = tt.ID.ToString();
                buttonList.Add(item);
            }
        }

    }

    void Space(string text_)
    {
        var item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        var text = item.GetComponentInChildren<Text>();
        text.text = "<size=55>" + text_ + "</size>";
        text.alignment = TextAnchor.MiddleCenter;
        var button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
        var plane = item.Find("Panel");
        plane.gameObject.SetActive(false);
    }

}
