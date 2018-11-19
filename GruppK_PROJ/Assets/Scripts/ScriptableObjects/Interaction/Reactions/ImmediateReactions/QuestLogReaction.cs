using UnityEngine;
public class QuestLogReaction : Reaction
{
    public string message;

    private BookTextHandler questTextManager;


    protected override void SpecificInit()
    {
        questTextManager = FindObjectOfType<BookTextHandler>();
    }


    protected override void ImmediateReaction()
    {
        questTextManager.AddText(message);
    }
}
