using System.Collections.Generic;
using System;

[Serializable]
public class User
{
    public long ID;                      //ユーザーID
    public string[] Questionnaires;             //アンケート
    public DateTime[] Update = new DateTime[4]; //データベースの更新日


}