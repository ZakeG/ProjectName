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

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void CheckSelectedForCombine()
    {
        foreach (ItemCombination ic in combinations)
        {
            combos = ic.GetList();
            foreach (Item i in combos)
            {
                //Check if item i in selectedItems exist in any combos if so, return a bool of true and run CombinationSucess()
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

    public void DeselectAll()
    {
        foreach (Item i in selectedItems)
        {
            //Dehighligt i
        }
        selectedItems.Clear();
    }
    public void CombinationSucess()
    {

    }
}