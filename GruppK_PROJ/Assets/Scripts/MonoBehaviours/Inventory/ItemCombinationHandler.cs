using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombinationHandler : MonoBehaviour {

    public List<ItemCombination> combinations = new List<ItemCombination>();
    public Inventory inventory;
    private Reaction getResultingItem;
    private Reaction removeUsedItems;
    private List<Item> selectedItems = new List<Item>();
    private List<Item> combos;
    private bool combineable;
    private bool compatible;

    private void Start()
    {
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
            if (combineable)
            {
                Debug.Log("Nu händer det grejjer vettu");
                CombinationSucess(ic);
                DeselectAll();
                return;
            }
            }

        }
        Debug.Log("Nu händer det INTE grejjer vettu");
    }

    public void OnInventorySlotClick(GameObject itemSlot)
    {
        if (itemSlot.GetComponent<InventoySlot>().GetItem() != null) {
            Item item = itemSlot.GetComponent<InventoySlot>().GetItem();
            if (selectedItems.Contains(item))
            {
                Deselect(item);
            }
            else
            {
                Select(item);
            }
        }
    }

    public void DeselectAll()
    {
        foreach (Item i in selectedItems)
        {
            //Dehighlight i
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
            inventory.GetComponent<Inventory>().RemoveItem(i);
        }
        inventory.GetComponent<Inventory>().AddItem(combinationRecepie.GetResultingItem());
    }
}