using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombinationHandler : MonoBehaviour {

    public List<ItemCombination> combinations = new List<ItemCombination>();
    public Inventory inventory;
    public Inventory inventoryScript;
    private List<Item> selectedItems;
    private List<Item> combos;
    private List<Item> comboResults;
    private bool combineable;
    private bool compatible;
    public AudioClip done;
    public AudioClip fail;
    public AudioSource audioSource;

    private void Start()
    {
        inventoryScript = inventory.GetComponent<Inventory>();
        selectedItems = new List<Item>();
        DeselectAll();

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
                audioSource.PlayOneShot(done, 0.7F);
                return;
            }
            else if(!combineable)
            {
  //              audioSource.PlayOneShot(fail, 0.7F);
            }
            
        }
        DeselectAll();
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
            inventoryScript.DehighlightSlot(i);
        }
        selectedItems.Clear();
    }

    private void Select(Item item)
    {
        inventoryScript.HighlightSlot(item);
        selectedItems.Add(item);
    }

    private void Deselect(Item item)
    {
        inventoryScript.DehighlightSlot(item);
        selectedItems.Remove(item);
    }

    private void CombinationSucess(ItemCombination combinationRecepie)
    {
        DeselectAll();
        combos = combinationRecepie.GetList();
        comboResults.Clear();
        comboResults = combinationRecepie.GetResultingItemList();
        foreach (Item i in combos)
        {
            inventory.GetComponent<Inventory>().RemoveItem(i);
        }
        foreach(Item i in comboResults)
        {
            inventoryScript.AddItem(i);
        }
    }
}