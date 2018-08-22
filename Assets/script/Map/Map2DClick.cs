using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map2DClick : MonoBehaviour {


    public void OnChange3D()
    {
        SceneManager.LoadScene("kougaimap");
    }

    public void OnBackHome()
    {
        SceneManager.LoadScene(UserData.instance.lastMode.Pop());
    }

    public void OnClick()
    {
        GameObject.Find("MapMaster").GetComponent<Map2DMove>().OnClassClick(this.name);
    }

}
