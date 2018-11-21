using UnityEngine;
public class QuestLogReaction : Reaction
{
    public string message;

    private BookTextHandler questTextManager;


    protected override void SpecificInit()
    {
        Debug.Log("Message som kommer att visas i denna scen: \n" + message);
        questTextManager = FindObjectOfType<BookTextHandler>();
    }


    protected override void ImmediateReaction()
    {
        questTextManager.AddText(message);
    }
}
