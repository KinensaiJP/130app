using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MessageBox : MonoBehaviour {

    public Text title, message;
    public GameObject parent;
    public Button ok;

    public IEnumerator PrintMessage(string title_, string message_, int mode_)
    {
        parent.SetActive(true);
        if (mode_ == 0)
        {
            ok.enabled = true;
        }

        title.text = title_;
        message.text = message_;

        yield return ok.OnClickAsObservable().First().ToYieldInstruction();

        ok.enabled = false;
        parent.SetActive(false);
    }

}
