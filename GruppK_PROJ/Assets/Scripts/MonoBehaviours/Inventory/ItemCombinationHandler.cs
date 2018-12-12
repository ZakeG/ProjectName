using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCombinationHandler : MonoBehaviour {

    public List<ItemCombination> combinations = new List<ItemCombination>();
    public List<FailedItemCombination> failCombinations = new List<FailedItemCombination>();
    public Inventory inventory;
    public AudioClip done;
    public AudioClip fail;
    public AudioSource audioSource;


    private Inventory inventoryScript;
    private List<Item> selectedItems;
    private List<Item> combos;
    private List<Item> failCombos;
    private List<Item> comboResults;
    private List<QuestLogReaction> questLogReactionList;
    private bool allSelectedItemsInCombo;
    [SerializeField]
    private GameObject failMessageCanvasBackground;
    [SerializeField]
    private Text failText;

    private void Awake()
    {
        inventoryScript = inventory.GetComponent<Inventory>();
        selectedItems = new List<Item>();

    }

    private void Start()
    {
        DeselectAll();
    }

    public void CheckSelectedForCombine()
    {
        foreach (ItemCombination ic in combinations)
        {
            combos = ic.GetList();
            allSelectedItemsInCombo = true;
            foreach (Item i in combos)
            {
                if (selectedItems.Contains(i) && combos.Count == selectedItems.Count)
                {
                    allSelectedItemsInCombo = true;
                }
                else
                {
                    allSelectedItemsInCombo = false;
                    break;
                }
            }
            if (allSelectedItemsInCombo)
            {
                CombinationSucess(ic);
                audioSource.PlayOneShot(done, 0.7F);
                break;
            }
        }
        if (!allSelectedItemsInCombo)
        {
            CombinationFail();
            audioSource.PlayOneShot(fail, 0.7F);
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
        comboResults = combinationRecepie.GetResultingItemList();
        questLogReactionList = combinationRecepie.GetQuestLogReactions();
        foreach (Item i in combos)
        {
            inventory.GetComponent<Inventory>().RemoveItem(i);
        }
        foreach (Item i in comboResults)
        {
            inventoryScript.AddItem(i);
        }
        foreach (QuestLogReaction qlr in questLogReactionList)
        {
            qlr.React(this);
        }
    }
    private void CombinationFail()
    {
        foreach (FailedItemCombination FIC in failCombinations) {
            failCombos = FIC.GetList();
            allSelectedItemsInCombo = true;
            foreach (Item i in failCombos)
            {
                if (selectedItems.Contains(i) && failCombos.Count == selectedItems.Count)
                {
                    allSelectedItemsInCombo = true;
                }
                else
                {
                    allSelectedItemsInCombo = false;
                    break;
                }
            }
            if (allSelectedItemsInCombo)
            {
                StartCoroutine(ShowFailMessage(FIC));
                break;
            }
        }
        if (!allSelectedItemsInCombo)
        {
            StartCoroutine(ShowDefaultFailMessage());
        }
    }
    IEnumerator ShowFailMessage(FailedItemCombination fic)
    {
        failMessageCanvasBackground.SetActive(true);
        failText.text = fic.GetFailMessage();
        yield return new WaitForSeconds(2);
        failText.text = string.Empty;
        failMessageCanvasBackground.SetActive(false);
    }
    IEnumerator ShowDefaultFailMessage()
    {
        failMessageCanvasBackground.SetActive(true);
        failText.text = "That doesn't work";
        yield return new WaitForSeconds(2);
        failText.text = string.Empty;
        failMessageCanvasBackground.SetActive(false);
    }

}

