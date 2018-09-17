using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTNoticeSwitch : MonoBehaviour {

    public Text text;
    private TTBooking ttBooking;
    private ScrollRect scrollRect;

    public void OnClick()
    {
        if (text.text == "通知をオンにする")
        {
            UserData.instance.user.PushBooking(ttBooking.id);
        }
        else
        {
            UserData.instance.user.Remove(ttBooking.id);
        }
        gameObject.SetActive(false);
        
    }

    void Start()
    {
        ttBooking = GetComponentInParent<TTBooking>();
        scrollRect = GetComponentInParent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(HideButton);
    }

    public void HideButton(Vector2 direction)
    {
        gameObject.SetActive(false);
    }
}
