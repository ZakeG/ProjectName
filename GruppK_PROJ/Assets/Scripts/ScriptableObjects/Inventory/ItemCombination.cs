using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ItemCombination : ScriptableObject
{
    public List<Item> combination = new List<Item>();
    public List<Item> result;

    public string[] QLReactions;

    private List<QuestLogReaction> questLogReactionList = new List<QuestLogReaction>();
    private QuestLogReaction qlrTemp;

    private void Awake()
    {

        if (QLReactions != null)
        {
            foreach (string s in QLReactions)
            {
                qlrTemp = ScriptableObject.CreateInstance("QuestLogReaction") as QuestLogReaction;
                qlrTemp.ConstructionInit(s);
                questLogReactionList.Add(qlrTemp);
            }
        }
    }

    public List<Item> GetList()
    {
        return combination;
    }

    public List<Item> GetResultingItemList()
    {
        return result;
    }

    public List<QuestLogReaction> GetQuestLogReactions()
    {
        return questLogReactionList;
    }
}