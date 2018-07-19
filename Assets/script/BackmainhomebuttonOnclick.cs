using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackmainhomebuttonOnclick : MonoBehaviour
{
    public void Onclick()
    {
        UserData.instance.lastMode = 4;
        SceneManager.LoadScene("mainhome");
    }

}