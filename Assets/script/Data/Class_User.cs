using System.Collections.Generic;
using System;

[Serializable]
public class User
{
    public long id;                         //ユーザーID
    public int anke1;                       //アンケート1
    public string[] anke23 = new string[3]; //アンケート1-5(その他),2,3
    public int anke4;                       //アンケート4
    public string[] booking;

    public void PushBooking(string _str)
    {
        string[] tmp = booking;
        booking = new string[booking.Length + 1];
        for(int i = 0; i < tmp.Length; i++)
        {
            booking[i] = tmp[i];
        }
        booking[tmp.Length] = _str;
        UserData.instance.Save();
        UserData.instance.Load();
    }

    public bool CheckBook(string _str)
    {
        foreach(string tmp in booking)
        {
            if (_str == tmp) return true;
        }
        return false;
    }

    public void Remove(string _str)
    {
        string[] tmp = booking;
        booking = new string[booking.Length - 1];
        int j = 0;
        for (int i = 0; i < tmp.Length - 1; i++)
        {
            if (_str != tmp[i]) booking[i] = tmp[j];
            else
            {
                j++;
                booking[i] = tmp[j];
            }
            j++;
        }
        UserData.instance.Save();
        UserData.instance.Load();
    }
}