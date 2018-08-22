using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KougaiMapController : MonoBehaviour {

    private Text infoText;
    private GameObject infoObject;

    GameObject nowActive;

	// Use this for initialization
	void Start () {
        infoText = GameObject.Find("TappedName").GetComponent<Text>();
        infoObject = GameObject.Find("Info");
        infoObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CallClick(string str)
    {
        Debug.Log(str);
        switch (str)
        {
            case "床":
                infoObject.SetActive(false);
                if(nowActive != null) nowActive.GetComponent<cakeslice.Outline>().eraseRenderer = true;
                break;
            case "ステージ":
                if (nowActive != null) nowActive.GetComponent<cakeslice.Outline>().eraseRenderer = true;
                nowActive = GameObject.Find("StageObject");
                infoText.text = str;
                nowActive.GetComponent<cakeslice.Outline>().eraseRenderer = false;
                break;
            default:
                infoObject.SetActive(true);
                infoText.text = str;
                if (nowActive != null) nowActive.GetComponent<cakeslice.Outline>().eraseRenderer = true;
                nowActive = GameObject.Find(str);
                nowActive.GetComponent<cakeslice.Outline>().eraseRenderer = false;

                break;

        }

    }
}
