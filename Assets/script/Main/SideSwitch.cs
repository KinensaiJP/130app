using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSwitch : MonoBehaviour {

	public void OnClick()
    {
        var a = GetComponentInParent<SideMenu>();
        if (a.enable) a.enable = false;
        else a.enable = true;
    }

}
