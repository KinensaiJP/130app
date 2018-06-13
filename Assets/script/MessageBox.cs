using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MessageBox : MonoBehaviour {

    public Text Title, Message;
    public GameObject parent;
    [SerializeField]
    public Button Yes, No, OK;
    private string Result;
	
	void Start () {

	}
	
	void Update () {
    }

    public IEnumerator PrintMessage(string Title_, string Message_,int Mode)
    {
        parent.SetActive(true);

        Title.text = Title_;
        Message.text = Message_;

        if (Mode == 0)
        {
            OK.gameObject.SetActive(true);
            Yes.gameObject.SetActive(false);
            No.gameObject.SetActive(false);

            yield return OK.OnClickAsObservable().First().ToYieldInstruction();
        }
        parent.SetActive(false);
    }

}
