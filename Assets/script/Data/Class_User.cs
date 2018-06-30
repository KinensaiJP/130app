using System.Collections.Generic;
using System;

[Serializable]
public class User
{
    public long id;                         //ユーザーID
    public bool[] anke1 = new bool[5];      //アンケート1
    public string[] anke23 = new string[3]; //アンケート1-5(その他),2,3
    public bool[] anke4 = new bool[3];      //アンケート4
    public IList<int> booking;
    public int lastMode;
}