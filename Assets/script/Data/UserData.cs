using System.Collections;
using System.IO;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using MiniJSON;
using LitJson;
using System;

public class UserData : MonoBehaviour
{
    public User user;
    public GameObject messageBoxObject;
    public Vector2 swipeDif;
    public long numberOfPeopleCame;
    public IList classTT, kodoProjct, kodoTT;
    public List<ClassProjectList> classProject;
    public string[] path = new string[3];
    public string[] versions = new string[5];
    public int[] touchVal;
    public int lastMode;
    public string command;
    public static UserData instance;
    public static Vector2 screenSize;

    private MessageBox messageBox;
    private Vector2 lastTouchPos;

    void Start()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
        path[0] = "./Assets\\script\\Data\\";
#elif UNITY_IPHONE
        Debug.Log("Unity iPhone");
#elif UNITY_ANDROID
        Debug.Log("Unity Android");
#endif
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(messageBoxObject);
        messageBox = messageBoxObject.GetComponent<MessageBox>();

        //StartCoroutine(CheckVersion());

        if (File.Exists(path[0]+"\\UserData.json") == false)
        {
            StartCoroutine(CreateUserID());
        }
        else
        {
            Load();
        }

        StartCoroutine(RequestProjects());
        StartCoroutine(RequestCount());
        StartCoroutine(UpAnswer());
        //StartCoroutine(RequestLatency());

        touchVal = new int[] { 0, 0, 0 };

    }

    public FlickGesture flickGesture;

    private void OnEnable()
    {
        flickGesture.Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        flickGesture.Flicked -= OnFlicked;
    }

    private void OnFlicked(object sender, EventArgs e)
    {
        Debug.Log("フリックされた: " + flickGesture.ScreenFlickVector);
        if (flickGesture.ScreenFlickVector.x < 0)
        {
            touchVal[0] = 3;
        }
        else
        {
            touchVal[0] = 4;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && touchVal[0] < 3)
        {
            touchVal[1] = Input.touchCount;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchVal[0] = 1;
                lastTouchPos = Input.mousePosition;
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                touchVal[0] = 2;
                swipeDif = (lastTouchPos - touch.position) / screenSize;
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchVal[0] = 2;
                swipeDif = (lastTouchPos - touch.position) / screenSize;
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchVal[0] = 0;
            }
        }
        else
        {
            touchVal[1] = 0;
        }
    }

    public void Save()
    {
        //user.Encode();
        string SaveData = JsonUtility.ToJson(user);
        File.WriteAllText(path[0] + "\\UserData.json", SaveData);
    }

    public void Load()
    {
        string LoadData = File.ReadAllText(path[0] + "\\UserData.json");
        JsonUtility.FromJsonOverwrite(LoadData, user);
        //user.Encode();
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
                yield return StartCoroutine(messageBox.PrintMessage("通信エラー", "接続状況を確認してください", true, true));
                cnt++;
                if (cnt >= 3)
                {
                    yield return StartCoroutine(messageBox.PrintMessage("通信エラー", "情報の取得に失敗しました\nアプリを終了し時間を空けて\nやり直してください。", false, true));
                }
                continue;
            }
            else
            {
                IList jsonlist = (IList)Json.Deserialize("[" + www.text + "]");
                foreach (IDictionary param in jsonlist)
                {
                    user.id = (long)param["COUNT(*)"] + 1;
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
            StartCoroutine(messageBox.PrintMessage("通信エラー", "接続状況を確認してください", true, true));
        }
        else
        {
            IList jsonlist = (IList)Json.Deserialize("[" + www.text + "]");
            foreach (IDictionary param in jsonlist)
            {
                numberOfPeopleCame = (long)param["count"];
            }
        }
    }

    public IEnumerator RequestProjects()
    {
        WWW www = new WWW("http://localhost/ClassProject.php");
        yield return www;
        if (www.error != null)
        {
            StartCoroutine(messageBox.PrintMessage("通信エラー", "接続状況を確認してください", true, true));
        }
        else
        {
            classProject = JsonMapper.ToObject<List<ClassProjectList>>("["+www.text+"]");
        }
    }

    public IEnumerator UpAnswer()
    {
        //user.Encode();
        WWWForm form = new WWWForm();
        form.AddField("from", "app");
        form.AddField("ID", user.id.ToString());
        form.AddField("a1", user.anke1);
        if (user.anke23[0] != "") form.AddField("a1_5", user.anke23[0]);
        else form.AddField("a1_5", "null");
        if (user.anke23[1] != "") form.AddField("a2", user.anke23[1]);
        else form.AddField("a2", "null");
        if (user.anke23[2] != "") form.AddField("a3", user.anke23[2]);
        else form.AddField("a3", "null");
        form.AddField("a4", user.anke4.ToString());
        WWW www = new WWW("http://localhost/Answer.php",form);
        yield return www;
        if (www.error != null)
        {
            StartCoroutine(messageBox.PrintMessage("通信エラー", "接続状況を確認してください", true, true));
        }
        else
        {
            Debug.Log(www.text);
        }

    }


}
