using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kikakubuttonclick : MonoBehaviour
{
    public void Onclick()
    {
        UserData.instance.command = "H1A";
        SceneManager.LoadScene("Projects");
    }

}