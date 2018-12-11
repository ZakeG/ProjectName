using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Image[] highlightImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public GameObject[] itemSlots = new GameObject[numItemSlots];
    public Item staffItem;


    public const int numItemSlots = 12;

    private BagButton bagButton;
    private GameObject staffButton;
    private bool hasStaff;

    private const float speed = 10.0f;
    private GameObject pickUpImageGameObject;
    private Image pickUpImage;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool animationStarted;

    void Start()
    {
        pickUpImageGameObject = GameObject.Find("PickUpImage");
        pickUpImage = pickUpImageGameObject.GetComponent<Image>();
        staffButton = GameObject.Find("StaffButton");
        bagButton = GameObject.Find("BagButton").GetComponent<BagButton>();
        startPosition = pickUpImageGameObject.transform.position;
        endPosition = bagButton.transform.position;

        DehighlightAll();
        pickUpImageGameObject.SetActive(false);
    }
    private void Update()
    {
        PlayPickUpAnimation();
        if (animationStarted && (pickUpImageGameObject.transform.position == endPosition))
        {
            ReturnPickUpAnimation();
            animationStarted = false;
        }
    }

    public void AddItem(Item itemToAdd)
    {
        if (!hasStaff && itemToAdd == staffItem)
        {
            staffItem.pickUpCondition.satisfied = true;
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
        ItemPickedUp(itemToAdd);
    }
    private void ItemPickedUp(Item i)
    {
        pickUpImageGameObject.SetActive(true);
        pickUpImage.sprite = i.sprite;
        animationStarted = true;

    }

    private void PlayPickUpAnimation()
    {
        if (!animationStarted)
        {
            pickUpImageGameObject.transform.position = Vector2.MoveTowards(pickUpImageGameObject.transform.position, endPosition, 1);
        }
        
    }

    private void ReturnPickUpAnimation()
    {
        pickUpImageGameObject.transform.position = startPosition;
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

    public void DehighlightAll()
    {
        for(int i = 0; i < items.Length; i++)
        {
            highlightImages[i].enabled = false;
        }

    }

    public Item[] GetItemList()
    {
        return items;
    }
}