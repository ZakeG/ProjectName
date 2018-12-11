using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ItemCombination : ScriptableObject
{
    public List<Item> combination = new List<Item>();
    public List<Item> result;

    public List<Item> GetList()
    {
        return combination;
    }

    public List<Item> GetResultingItemList()
    {
        return result;
    }
}