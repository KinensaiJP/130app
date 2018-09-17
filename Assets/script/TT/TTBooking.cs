using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTBooking : MonoBehaviour {

    public Text button;
    public Button buttonObject;
    public string id;

	public void OnClick()
    {
        GetComponentInParent<TTScroll>().AllButtonOff();
        if (UserData.instance.user.CheckBook(id))
            button.text = "通知をオフにする";
        else
            button.text = "通知をオンにする";
        buttonObject.gameObject.SetActive(true);
        
    }


}
