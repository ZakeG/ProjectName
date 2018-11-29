using UnityEngine;
public class QuestLogReaction : Reaction
{
    public string message;

    private BookTextHandler questTextManager;
    private BookTextHandler[] tempList;

    public QuestLogReaction(string m)
    {
        message = m;
    }

    protected override void SpecificInit()
    {

        tempList = Resources.FindObjectsOfTypeAll<BookTextHandler>();
        foreach (BookTextHandler bth in tempList)
        {
            if (bth.CompareTag("QuestText0"))
            {
                questTextManager = bth;
            }
        }
    }

    protected override void ImmediateReaction()
    {
        questTextManager.AddText(message);
    }
}
