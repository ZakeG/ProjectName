using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class FailedItemCombination : ScriptableObject
{
    public List<Item> failCombination = new List<Item>();
    public string failMessage;

    public List<Item> GetList()
    {
        return failCombination;
    }

    public string GetFailMessage()
    {
        return failMessage;
    }
}