using UnityEngine;

public class TextReaction : DelayedReaction
{
    public string message;
    public Color textColor = Color.white;


    private TextManager textManager;


    protected override void SpecificInit()
    {
        textManager = FindObjectOfType<TextManager> ();
    }


    protected override void ImmediateReaction()
    {
        textManager.DisplayMessage(message);
    }
}