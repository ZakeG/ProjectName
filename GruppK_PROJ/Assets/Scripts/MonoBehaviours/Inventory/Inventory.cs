using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public int[] combinedHashes = new int[5];

    public const int numItemSlots = 4;

    private Item itemA;
    private Item itemB;
    private int combinedHashOne;
    private int combinedHashTwo;
    private string itemName;
    private int itemANameHash;
    private int itemBNameHash;

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }


    public void RemoveItem (Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void OnInventoryClick(Item clickedItem)
    {
        if (itemA == null)
        {
            itemA = clickedItem;
            itemANameHash = int.Parse(itemA.itemName);
        }
        else if(itemB == null)
        {
            itemB = clickedItem;
            itemBNameHash = int.Parse(itemB.itemName);
            combinedHashOne = itemANameHash + itemBNameHash;
            combinedHashTwo = itemBNameHash + itemANameHash;

            for (int i = 0; i < combinedHashes.Length; i++)
            {
                if (combinedHashOne == combinedHashes[i])
                {

                }
                else if (combinedHashTwo == combinedHashes[i])
                {

                }

            }
        }
    }
}
