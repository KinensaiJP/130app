using System.Collections;
using System.IO;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using MiniJSON;
using LitJson;
using System;
using UniRx;


public class UserData : MonoBehaviour
{
    public User user;
    public GameObject messageBoxObject;
    public Vector2 swipeDif;
    public long numberOfPeopleCame;
    public IList classTT;
    public List<ClassProjectList> classProject;
    public List<TT> kodoTT, stageTT;
    public Stack<string> lastMode;
    public string[] path = new string[3];
    public string[] versions = new string[5];
    public int[] touchVal;
    public string command;
    public static UserData instance;
    public static Vector2 screenSize;
    public FlickGesture flickGesture;

    private MessageBox messageBox;
    private Vector2 lastTouchPos;
    private Queue<string> notice;
    private float timeInterval;
    private bool noticeflag;

    void Start()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
        path[0] = "./Assets\\script\\Data\\";
#elif UNITY_IPHONE
        Debug.Log("Unity iPhone");
        path[0] = Application.persistentDataPath;
#elif UNITY_ANDROID
        Debug.Log("Unity Android");
        path[0] = Application.persistentDataPath;
#endif
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(messageBoxObject);
        messageBox = messageBoxObject.GetComponent<MessageBox>();
        lastMode = new Stack<string>();
        //StartCoroutine(CheckVersion());

        if (File.Exists(path[0]+"\\UserData.json") == false)
        {
            StartCoroutine(CreateUserID());
        }
        else
        {
            Load();
        }

        noticeflag = true;

        StartCoroutine(RequestProjects());
        StartCoroutine(RequestCount());
        StartCoroutine(UpAnswer());
        //StartCoroutine(RequestLatency());
        StartCoroutine(RequestTT(true));
        StartCoroutine(RequestTT(false));
        touchVal = new int[] { 0, 0, 0 };
    }

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
        timeInterval += Time.deltaTime;
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
        if (timeInterval >= 3f && noticeflag && notice.Count > 0)
        {
            noticeflag = false;
            StartCoroutine(Notice());
            timeInterval = 0f;
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
        notice = new Queue<string>(user.booking);
        //user.Encode();
    }

    public IEnumerator CreateUserID()
    {
        int cnt = 0;
        while (true)
        {
            WWWForm form = new WWWForm();
            form.AddField("from", "app");
            WWW www = new WWW("https://api.kinensai.jp/AddUser.php", form);
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
        WWW www = new WWW("https://api.kinensai.jp/count.php");
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
        WWW www = new WWW("https://api.kinensai.jp/ClassProject.php");
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

    public IEnumerator RequestTT(bool place)
    {
        WWWForm form = new WWWForm();
        if (place) form.AddField("place", "講堂");
        else       form.AddField("place", "ステージ");
        WWW www = new WWW("https://api.kinensai.jp/TT.php", form);
        yield return www;
        if (www.error != null)
        {
            StartCoroutine(messageBox.PrintMessage("通信エラー", "接続状況を確認してください", true, true));
        }
        else
        {
            Debug.Log(www.text);
            if (place)
                kodoTT = JsonMapper.ToObject<List<TT>>("[" + www.text + "]");
            else
                stageTT = JsonMapper.ToObject<List<TT>>("[" + www.text + "]");
        }

    }

    public IEnumerator UpAnswer()
    {
        Save();
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
        WWW www = new WWW("https://api.kinensai.jp/Answer.php", form);
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

    public IEnumerator Notice()
    {
        long now = Int64.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
        string id = notice.Dequeue();
        foreach (TT tt in kodoTT)
        {
            if (tt.ID.ToString() == id)
            {
                if (Int64.Parse(tt.ntime) - 1500 < now && Int64.Parse(tt.ntime) > now)
                {
                    StartCoroutine(
                     messageBox.PrintMessage(
                      "まもなく開始", tt.name + "\n日時:" + tt.dtime + "\n場所:" + tt.place, true, false));
                }
                else notice.Enqueue(id);
            }
        }
        foreach (TT tt in stageTT)
        {
            if (tt.ID.ToString() == id)
            {
                if (Int64.Parse(tt.ntime) - 1500 < now && Int64.Parse(tt.ntime) > now)
                {
                    StartCoroutine(
                     messageBox.PrintMessage(
                      "まもなく開始", tt.name + "\n日時:" + tt.dtime + "\n場所:" + tt.place, true, false));
                }
                else notice.Enqueue(id);
            }
        }
        foreach (ClassProjectList tt in classProject)
        {
            if (tt.className.ToString() == id)
            {
                bool flag = false;
                foreach (string time in tt.TT.Split('\n'))
                {
                    if (Int64.Parse(time) - 1500 < now && Int64.Parse(time) > now)
                    {
                        flag = true;
                        string place = "";
                        if (tt.className.ToString() == "H") place = "高校";
                        else place = "中学";
                        StartCoroutine(
                         messageBox.PrintMessage(
                          "まもなく開始", tt.title + "\n日時:" + time.Substring(4,2) + "月" + time.Substring(6,2) + "日 " + time.Substring(8,2) + "時" + time.Substring(10,2) + "分" + "\n場所: " + place + tt.className.Remove(0, 1), true, false));
                    }
                }
                if (flag == false) notice.Enqueue(id);
            }
        }
        yield return messageBox.ok.OnClickAsObservable().First().ToYieldInstruction();
        noticeflag = true;
    }

}
