using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextManager : MonoBehaviour
{

    public Text text;
    public GameObject background;
    private int messagenumber;
    private string savedString;

    private void Start()
    {
        text.text = string.Empty;
        savedString = string.Empty;
    }

    public void DisplayMessage(string message)
    {
        if (!savedString.Equals(string.Empty))
        {
            text.text = savedString + "\n" + message;
        }
        else
        {
            text.text = message;
        }
        savedString = message;
    }

    public void ClearText()
    {
        text.text = string.Empty;
        savedString = string.Empty;
    }

    public void ShowTextArea()
    {
        background.SetActive(true);
    }

    public void HideTextArea()
    {
        background.SetActive(false);
    }

}

