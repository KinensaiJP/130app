using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSwitch : MonoBehaviour {
    public SideMenu sideMenu;
	public void OnClick()
    {
        
        if (sideMenu.enable) sideMenu.enable = false;
        else sideMenu.enable = true;
    }

}
