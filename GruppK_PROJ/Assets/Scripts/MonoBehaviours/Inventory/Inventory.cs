using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Image[] highlightImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public GameObject[] itemSlots = new GameObject[numItemSlots]; 
    public const int numItemSlots = 4;
    private BagButton bagButton;
    private GameObject staffButton;
    private Item staffItem;
    private Object[] resourceArray;
    private bool hasStaff;

    void Start()
    {
        resourceArray = Resources.LoadAll("");
        staffItem = Resources.Load("/Items") as Item;
        staffButton = GameObject.Find("StaffButton");
        bagButton = GameObject.Find("Bag").GetComponent<BagButton>();
        for (int i = 0; i < items.Length; i++)
        {
                highlightImages[i].enabled = false;
        }
    }
    public void AddItem(Item itemToAdd)
    {
        Debug.Log("To add: " + itemToAdd + " Compared to staff: " + staffItem);
        if (!hasStaff && itemToAdd == staffItem)
        {
            staffButton.SetActive(true);
            hasStaff = true;
            return;
        }

        bagButton.ShowNewIcon();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                itemSlots[i].GetComponent<InventoySlot>().SetItem(itemToAdd);
                itemToAdd.pickUpCondition.satisfied = true;
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        bagButton.ShowNewIcon();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                itemSlots[i].GetComponent<InventoySlot>().RemoveItem();
                itemToRemove.pickUpCondition.satisfied = false;
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void HighlightSlot(Item slottedItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == slottedItem)
            {
                highlightImages[i].enabled = true;
            }
        }
    }
    public void DehighlightSlot(Item slottedItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == slottedItem)
            {
                highlightImages[i].enabled = false;
            }
        }
    }

    public Item[] GetItemList()
    {
        return items;
    }
    /*private Item FindStaffItem(Object[] array)
    {
        foreach(Object o in array)
        {
            if (Object.name)
            {

            }
        }
    }*/
}