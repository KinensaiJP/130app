using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kikakubuttonclick : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("kikakuhome");
    }

}