using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KougaiMapEvent : MonoBehaviour {

    public void OnChange2D()
    {
        SceneManager.LoadScene("kounaimap");
    }

    public void OnBackHome()
    {

        SceneManager.LoadScene("mainhome");
    }
    public void OnClick()
    {
        GameObject mapController = GameObject.Find("MapController");
        KougaiMapController kmc = mapController.GetComponent<KougaiMapController>();

        kmc.CallClick(this.name);
    }


}
