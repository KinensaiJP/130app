using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TTNoticeSwitch : MonoBehaviour {

    public Text text;
    public Text Name;
    private TTBooking ttBooking;
    private ScrollRect scrollRect;
    private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long FromDateTime(string id)
    {
        string time = "";
        foreach (TT tt in UserData.instance.stageTT)
        {
            if (tt.ID.ToString() == id) time = tt.ntime;
        }
        foreach (TT tt in UserData.instance.kodoTT)
        {
            if (tt.ID.ToString() == id) time = tt.ntime;
        }
        DateTime dateTime = DateTime.ParseExact(time, "yyyyMMddHHmmss", null);
        double nowTicks = (dateTime.ToUniversalTime() - UNIX_EPOCH).TotalSeconds;
        return (long)nowTicks;
    }

    public void OnClick()
    {
        if (text.text == "通知をオンにする")
        {
            UserData.instance.user.PushBooking(ttBooking.id); //通知するプロジェクトを保存リストに追加します
            AddNotice(FromDateTime(ttBooking.id).ToString());
        }
        else
        {
            UserData.instance.user.Remove(ttBooking.id); //通知するプロジェクトを保存リストから外します
            AddNotice(FromDateTime(ttBooking.id).ToString());
        }
        gameObject.SetActive(false);
        
    }

    void Start()
    {
        ttBooking = GetComponentInParent<TTBooking>();
        scrollRect = GetComponentInParent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(HideButton);
    }

    public void HideButton(Vector2 direction)
    {
        gameObject.SetActive(false);
    }

    public void AddNotice(string time_) //通知をオンにするときに呼びます
    {

    }

    public void CancellNotice(string time_) //通知をオフにするときに呼びます
    {

    }
}
