using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextManager : MonoBehaviour
{
    public struct Instruction
    {
        public string message;
        public Color textColor;
        public float order;
    }

    public Text text;
    public GameObject background;

    private int messageNumber;
    private string savedString;

    private void Start()
    {
        text.text = string.Empty;
        savedString = string.Empty;
    }

    public void DisplayMessage(string message, Color textColor)
    {
        if (!savedString.Equals(string.Empty))
        {
            text.text = savedString + "\n" + message;
        }
        else if(text.color != textColor)
        {
            text.text = string.Empty;
            text.color = textColor;
            text.text = message;
        }
        else
        {
            text.color = textColor;
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

