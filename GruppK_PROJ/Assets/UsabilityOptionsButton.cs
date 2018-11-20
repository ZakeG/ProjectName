using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsabilityOptionsButton : MonoBehaviour {

    public Condition optionsCondition;
    public Text optionsText;

    void Start()
    {
        optionsCondition.satisfied = false;
        UpdateText();
    }

    public void OnClick()
    {
        if (optionsCondition.satisfied == true)
        {
            optionsCondition.satisfied = false;
        }
        else
        {
            optionsCondition.satisfied = true;
        }
        UpdateText();
    }
    private void UpdateText()
    {
        if (optionsCondition.satisfied == false)
        {
            optionsText.text = "Options: OFF";
        }
        else
        {
            optionsText.text = "Options: ON";
        }
    }

}
