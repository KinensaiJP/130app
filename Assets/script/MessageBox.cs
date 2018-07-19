using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MessageBox : MonoBehaviour {

    public Text title, message, e_title, e_message;
    public GameObject box, e_box;
    public GameObject parent;
    public Button ok,e_ok;

    public IEnumerator PrintMessage(string title_, string message_, bool mode_, bool error_)
    {
        parent.SetActive(true);
        ok.enabled = false;
        e_ok.enabled = false;

        if (error_)
        {
            e_ok.gameObject.SetActive(true);
            e_box.SetActive(true);
            e_title.text = title_;
            e_message.text = message_;
            if (mode_) e_ok.enabled = true;
            yield return e_ok.OnClickAsObservable().First().ToYieldInstruction();
        }
        else
        {
            ok.gameObject.SetActive(true);
            box.SetActive(true);
            title.text = title_;
            message.text = message_;
            if (mode_) ok.enabled = true;
            yield return ok.OnClickAsObservable().First().ToYieldInstruction();
        }
        e_ok.gameObject.SetActive(false);
        e_box.SetActive(false);
        ok.gameObject.SetActive(false);
        box.SetActive(false);
        ok.enabled = false;
        e_ok.enabled = false;
        parent.SetActive(false);
    }

}
