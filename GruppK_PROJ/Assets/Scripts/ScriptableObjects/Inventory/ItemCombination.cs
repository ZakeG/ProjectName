using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ItemCombination : ScriptableObject
{
    public List<Item> combination = new List<Item>();
    public List<Item> result;

    public GameObject[] gameObject;
    public bool[] activeState;
    public bool[] isAffectedByStaff;

    public string[] questLogReaction;

    private List<GameObjectReaction> gameObjectReactionList;
    private List<QuestLogReaction> questLogReactionList;
    private GameObjectReaction gorTemp;
    private QuestLogReaction qlrTemp;

    private void Awake()
    {
        if (questLogReaction != null) {
            foreach (string s in questLogReaction)
            {
                qlrTemp = new QuestLogReaction(s);
                questLogReactionList.Add(qlrTemp);
            }
        }
        if (gameObject != null)
        {
            for(int i = 0; i > gameObject.Length; i++ )
            {
                gorTemp = new GameObjectReaction(gameObject[i], activeState[i], isAffectedByStaff[i]);
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