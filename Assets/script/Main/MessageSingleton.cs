using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSingleton : MonoBehaviour
{
    private static MessageSingleton instance = null;

    public static MessageSingleton Instance
    {
        get { return MessageSingleton.instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}