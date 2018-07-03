using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kikakubuttonclick : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("kikakuhome");
    }

}