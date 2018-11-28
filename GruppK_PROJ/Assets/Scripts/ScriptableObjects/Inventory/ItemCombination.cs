using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ItemCombination : ScriptableObject
{
    public List<Item> combination = new List<Item>();
    public List<Item> result;

    public GameObject[] GOReactions;
    public bool[] activeStateList;
    public bool[] isAffectedByStaffList;

    public string[] QLReactions;

    private List<GameObjectReaction> gameObjectReactionList;
    private List<QuestLogReaction> questLogReactionList;
    private GameObjectReaction gorTemp;
    private QuestLogReaction qlrTemp;

    private void Awake()
    {
        if (QLReactions.Length > 0) {
            foreach (string s in QLReactions)
            {
                qlrTemp = new QuestLogReaction(s);
                questLogReactionList.Add(qlrTemp);
            }
        }
        if (GOReactions.Length > 0)
        {
            for(int i = 0; i > GOReactions.Length; i++ )
            {
                gorTemp = new GameObjectReaction(GOReactions[i], activeStateList[i], isAffectedByStaffList[i]);
                gameObjectReactionList.Add(gorTemp);
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
    
    public List<GameObjectReaction> GetGameObjectReactions()
    {
            return gameObjectReactionList;
    }

    public List<QuestLogReaction> GetQuestLogReactions()
    {
            return questLogReactionList;
    }
}