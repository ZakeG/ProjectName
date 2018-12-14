using UnityEngine;
public class QuestLogReaction : Reaction
{
    public string message;

    private BookTextHandler bookTextManager;
    private BookTextHandler[] tempList;

    public void ConstructionInit(string m)
    {
        message = m;
        SpecificInit();
    }

    protected override void SpecificInit()
    {

        tempList = Resources.FindObjectsOfTypeAll<BookTextHandler>();
        foreach (BookTextHandler bth in tempList)
        {
            if (bth.CompareTag("QuestText0"))
            {
                bookTextManager = bth;
            }
        }
    }

    protected override void ImmediateReaction()
    {
        bookTextManager.AddText(message);
    }
}
