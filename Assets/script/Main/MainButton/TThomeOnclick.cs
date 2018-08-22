using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TThomeOnclick : MonoBehaviour
{
    public void Onclick()
    {
        UserData.instance.lastMode.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("tthome");
    }

}
