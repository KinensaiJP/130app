using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MessageBox : MonoBehaviour {

    public Text Title, Message;
    public GameObject parent;
    [SerializeField]
    public Button OK;
    private string Result;

    public IEnumerator PrintMessage(string Title_, string Message_, int Mode)
    {
        parent.SetActive(true);
        if (Mode == 0)
        {
            OK.enabled = true;
        }

        Title.text = Title_;
        Message.text = Message_;

        yield return OK.OnClickAsObservable().First().ToYieldInstruction();

        OK.enabled = false;
        parent.SetActive(false);
    }

}
