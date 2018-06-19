using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackmainhomebuttonOnclick : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("mainhome");
    }

}