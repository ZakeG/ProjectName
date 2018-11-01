using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoySlot : MonoBehaviour {

    private Item itemInSlot;

    public Item GetItem()
    {
        if (itemInSlot == null)
        {
            return null;
        }
        else
        {
            return itemInSlot;
        }
    }
    public void SetItem(Item i)
    {
        itemInSlot = i;
    }
    public void RemoveItem()
    {
        itemInSlot = null;
    }
}
