using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map2DSelectController : MonoBehaviour {


    public void OnClick()
    {
        GameObject.Find("MapMaster").transform.position =  Vector3.zero;
        GameObject.Find("MapMaster").transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

    }



}
