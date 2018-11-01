using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombinationHandler : MonoBehaviour {

    public List<ItemCombination> combinations = new List<ItemCombination>();
    public Reaction getResultingItem;
    public Reaction removeUsedItems;
    private List<Item> selectedItems = new List<Item>();
    private List<Item> combos;
    private Inventory inventory;
    private bool combineable;
    private bool compatible;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void CheckSelectedForCombine()
    {
        foreach (ItemCombination ic in combinations)
        {
            combos = ic.GetList();
            compatible = true;
            foreach (Item i in combos)
            {
                if (selectedItems.Contains(i) && compatible)
                {
                    combineable = true;
                }
                else
                {
                    compatible = false;
                    combineable = false;
                }
            }
            if (combineable)
            {
                CombinationSucess(ic);
                return;
            }
        }
    }

    public void OnInventorySlotClick(Item item)
    {
        if (selectedItems.Contains(item))
        {
            Deselect(item);
        }
        else
        {
            Select(item);
        }
    }

    public void DeselectAll()
    {
        foreach (Item i in selectedItems)
        {
            //Dehighligt i
        }
        selectedItems.Clear();
    }

    private void Select(Item item)
    {
        //Highlight item
        selectedItems.Add(item);
    }

    private void Deselect(Item item)
    {
        //Dehighlight item
        selectedItems.Remove(item);
    }

    private void CombinationSucess(ItemCombination combinationRecepie)
    {
        combos = combinationRecepie.GetList();
        foreach(Item i in combos)
        {
            inventory.RemoveItem(i);
        }


    }
}