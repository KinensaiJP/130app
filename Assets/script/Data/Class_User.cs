using System.Collections.Generic;
using System;

[Serializable]
public class User
{
    public long id;                         //ユーザーID
    public int anke1;                       //アンケート1
    public string[] anke23 = new string[3]; //アンケート1-5(その他),2,3
    public int anke4;                       //アンケート4
    public IList<int> booking;

    public void Encode()
    {
        for (int i = 0; i < 3; i++)
        {
            byte[] str = System.Text.Encoding.UTF8.GetBytes(anke23[i]);
            anke23[i] = System.Text.Encoding.UTF8.GetString(str);
        }
    }
}