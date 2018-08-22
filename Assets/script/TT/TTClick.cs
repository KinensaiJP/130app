using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TTClick : MonoBehaviour {
    public string text;

    public void OnClick()
    {
        UserData.instance.command = text;
        UserData.instance.lastMode.Push("tthome");
        SceneManager.LoadScene("Projects");
    }
}
