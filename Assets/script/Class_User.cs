using System.Collections.Generic;
using System;

[Serializable]
public class User
{
    public long ID;                         //ユーザーID
    public bool[] Anke1 = new bool[5];      //アンケート1
    public string[] Anke23 = new string[3]; //アンケート1-5(その他),2,3
    public bool[] Anke4 = new bool[3];      //アンケート4
    public DateTime[] Update = new DateTime[4]; //データベースの更新日
}