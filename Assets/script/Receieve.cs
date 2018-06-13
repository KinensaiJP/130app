using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;

public class Receieve : MonoBehaviour {
    public GameObject MessageBox_objct;
    public long NumberOfPeopleCame;
    public int[] Latency;

    private MessageBox MessageBox;
    private string[] ClassList;
    private bool RequestSuccsess;
	// Use this for initialization
	void Start () {
        MessageBox = MessageBox_objct.GetComponent<MessageBox>();
        StartCoroutine(RequestCount());


        ClassList = new string[]
            {"1A","1B","1C","1D","1E","1F","1G","1I","1J","1K",
             "2A","2B","2C","2D","2E","2F","2G","2I","2J","2K"};
        //StartCoroutine(RequestLatency());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator RequestCount()
    {
        WWW www = new WWW("https://api.kinensai.jp/count.php");
        yield return www;
        if (www.error != null)
        {
            RequestSuccsess = false;
        }
        else
        {
            RequestSuccsess = true;
            IList jsonlist = (IList)Json.Deserialize("["+www.text+"]");
            foreach(IDictionary param in jsonlist)
            {
                NumberOfPeopleCame = (long)param["count"];
                Debug.Log("count:" + NumberOfPeopleCame.ToString());
            }
        }
        if (RequestSuccsess == false)
        {
            StartCoroutine(MessageBox.PrintMessage("通信エラー", "接続状況を確認してください", 0));
        }
    }
    /*
    IEnumerator RequestLatency()
    {
        WWW www = new WWW("http://localhost/count.php");
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Error!");
        }
        else
        {
            Debug.Log("Conection Succsess");
            IList jsonlist = (IList)Json.Deserialize("[" + www.text + "]");
            int i=0;
            foreach (IDictionary param in jsonlist)
            {
                IList Latencies = (IList)param["latency"];
                foreach (IDictionary param1 in Latencies)
                {
                    Latency[i] = (int)param[ClassList[i]];
                    Debug.Log(ClassList[i]+" Latency:" + Latency[i].ToString());
                    i++;
                }
            }
        }

    }
    */
}
