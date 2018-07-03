using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSingleton : MonoBehaviour
{
    private static UserSingleton instance = null;

    public static UserSingleton Instance
    {
        get { return UserSingleton.instance; }
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