using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ItemCombination : ScriptableObject
{
    public List<Item> combination = new List<Item>();
    public Item result;

    public List<Item> GetList()
    {
        return combination;
    }

    public Item GetResultingItem()
    {
        return result;
    }
}