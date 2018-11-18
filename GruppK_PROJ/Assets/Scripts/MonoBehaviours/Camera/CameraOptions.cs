using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOptions : MonoBehaviour {

    public Condition CameraOptionCondition;
    public Text text;
    // Use this for initialization

    public void ToggleOptionsOnOff()
    {
        Debug.Log("Comment for text change needs to be removed before text is updated");
        Debug.Log("");
        if (CameraOptionCondition.satisfied == true)
        {
//            text.text = "off";
            CameraOptionCondition.satisfied = false;
        }else
        {
//            text.text = "on";
            CameraOptionCondition.satisfied = true;
        }
    }
}
