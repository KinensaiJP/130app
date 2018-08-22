using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTScroll : MonoBehaviour {
    public RectTransform prefab;
    // Use this for initialization
    void Start()
    {
        var item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        var text = item.GetComponentInChildren<Text>();
        text.text = "ステージ企画";
        var button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
        foreach (TT tt in UserData.instance.stageTT)
        {
            item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);
            text = item.GetComponentInChildren<Text>();
            text.text = tt.dtime.Substring(6,5) + " " + tt.name;
            var name = item.GetComponentInChildren<TTClick>();
            name.text = tt.name;
        }

        item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        text = item.GetComponentInChildren<Text>();
        text.text = "";
        button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);

        item = GameObject.Instantiate(prefab) as RectTransform;
        item.SetParent(transform, false);
        text = item.GetComponentInChildren<Text>();
        text.text = "講堂企画";
        button = item.GetComponentInChildren<Button>();
        button.gameObject.SetActive(false);
        foreach (TT tt in UserData.instance.kodoTT)
        {
            item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);
            text = item.GetComponentInChildren<Text>();
            text.text = tt.dtime.Substring(6, 5) + " " + tt.name;
            var name = item.GetComponentInChildren<TTClick>();
            name.text = tt.name;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
