using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class KougaiTestScript : MonoBehaviour {

    public GameObject target;

    RectTransform rt;

    private void Start()
    {
        rt = target.GetComponent<RectTransform>();
    }

    private void Update()
    {
        rt.position = (RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position));
    }

}
