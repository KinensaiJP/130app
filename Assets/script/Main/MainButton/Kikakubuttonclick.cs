using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kikakubuttonclick : MonoBehaviour
{
    public void Onclick()
    {
        UserData.instance.lastMode.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("kikakuhome");
    }

}