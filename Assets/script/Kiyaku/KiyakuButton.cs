using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KiyakuButton : MonoBehaviour {

    public Text text;

    public void OnClick()
    {
        GetComponentInParent<SideMenu>().enable = false;

        if (text.text == "利用規約")
        {
            UserData.instance.lastMode.Push(SceneManager.GetActiveScene().name);
            UserData.instance.command = "kiyaku";
            SceneManager.LoadScene("Kiyaku");
        }
        else
        {
            UserData.instance.lastMode.Push(SceneManager.GetActiveScene().name);
            UserData.instance.command = "";
            SceneManager.LoadScene("Kiyaku");
        }
    }
}
