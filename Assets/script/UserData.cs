using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System;

public class UserData : MonoBehaviour
{
    public User user;
    public GameObject MessageBox_objct;
    public long NumberOfPeopleCame;
    public IList ClassPloject, ClassTT, KodoProjct, KodoTT;
    public string[] Path = new string[2];

    private MessageBox MessageBox;

    void Start()
    {
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
        Path[0] = "./Assets\\script\\Data\\";
#elif UNITY_IPHONE
        Debug.Log("Unity iPhone");
#elif UNITY_ANDROID
        Debug.Log("Any other platform");
#endif

        DontDestroyOnLoad(gameObject);
        MessageBox = MessageBox_objct.GetComponent<MessageBox>();

        if (File.Exists(Path[0]+"\\UserData.json") == false)
        {
            StartCoroutine(CreateUserID());
        }
        else
        {
            Load();
        }

        StartCoroutine(RequestCount());
        //StartCoroutine(RequestLatency());

    }

    void Update()
    {

    }

    public void Save()
    {
        string SaveData = JsonUtility.ToJson(user);
        File.WriteAllText(Path[0] + "\\UserData.json", SaveData);
    }

    public void Load()
    {
        string LoadData = File.ReadAllText(Path[0] + "\\UserData.json");
        JsonUtility.FromJsonOverwrite(LoadData, user);
    }

    public IEnumerator CreateUserID()
    {
        int cnt = 0;
        while (true)
        {
            WWWForm form = new WWWForm();
            form.AddField("from", "app");
            WWW www = new WWW("http://localhost/AddUser.php",form);
            yield return www;
            if (www.error != null)
            {
                yield return StartCoroutine(MessageBox.PrintMessage("通信エラー", "接続状況を確認してください",0));
                cnt++;
                if (cnt >= 3)
                {
                    yield return StartCoroutine(MessageBox.PrintMessage("通信エラー", "情報の取得に失敗しました\nアプリを終了し時間を空けて\nやり直してください。",1));
                }
                continue;
            }
            else
            {
                IList jsonlist = (IList)Json.Deserialize("[" + www.text + "]");
                foreach (IDictionary param in jsonlist)
                {
                    user.ID = (long)param["COUNT(*)"] + 1;
                }
                Save();
                break;
            }
        }
    }

    public IEnumerator RequestCount()
    {
        WWW www = new WWW("http://localhost/count.php");
        yield return www;
        if (www.error != null)
        {
            StartCoroutine(MessageBox.PrintMessage("通信エラー", "接続状況を確認してください",0));
        }
        else
        {
            IList jsonlist = (IList)Json.Deserialize("[" + www.text + "]");
            foreach (IDictionary param in jsonlist)
            {
                NumberOfPeopleCame = (long)param["count"];
                Debug.Log("count:" + NumberOfPeopleCame.ToString());
            }
        }
    }
}
