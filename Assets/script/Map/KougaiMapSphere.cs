using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class KougaiMapSphere : MonoBehaviour {
    //体育館とか表示
    // Use this for initialization
    List<string> list;


    void Start () {
        list = new List<string>();
    }
	
	// Update is called once per frame
	void Update () {

        String str = string.Join(", ", list.ToArray());
        Debug.Log(str);
    }


    private void AddCollection(string name)
    {
        list.Add(name);
        List<string> resultArray = list.Distinct().ToList<string>();
        list = resultArray;
    }
    private void DeleteCollection(string name)
    {
        list.Remove(name);
    }


    private void OnTriggerEnter(Collider c)
    {
        AddCollection(c.name);
    }


    private void OnTriggerStay(Collider c)
    {
    }

    private void OnTriggerExit(Collider c)
    {
        DeleteCollection(c.name);
    }



}
