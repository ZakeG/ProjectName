using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookTextHandler : MonoBehaviour
{

    public GameObject secondPage;
    public string textBeingShownP1;
    public string textBeingShownP2;
    public int currentPageNr;
    public GameObject newIcon;
    public QuestBookButton bookButtonScript;
    public GameObject rightArrow;
    public GameObject leftArrow;

    private List<Page> pages;
    private Text page1;
    private Text page2;
    private string currentPageP1;
    private string currentPageP2;
    private string textToAdd;
    private int workingOnPage;
    private bool workingOnFirstSheet;

    private const int maxCharacterCount = 300;
    private const int line = 43;

    public struct Page
    {
        public string text1;
        public string text2;
        public int pageNr;
    }

    public void Start()
    {
        pages = new List<Page>();
        workingOnPage = 0;
        currentPageNr = 0;
        page1 = gameObject.GetComponent<Text>();
        page2 = secondPage.GetComponent<Text>();
        StartBook();
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }

    private void StartBook()
    {
        currentPageP1 = page1.text;
        currentPageP2 = page2.text;
        textBeingShownP1 = currentPageP1;
        textBeingShownP2 = currentPageP2;
        UpdateBookText();
        workingOnFirstSheet = true;
    }

    public void AddText(string newText)
    {
        if (!bookButtonScript.bookOpen)
        {
            newIcon.SetActive(true);
        }
        string textToInput = newText += "\n----\n";
        string testText1 = page1.text + textToInput;
        string testText2 = page2.text + textToInput;
        if (!(testText1.Length > maxCharacterCount) && workingOnFirstSheet)
        {
            currentPageP1 = page1.text + newText;
        }
        else if (!(testText2.Length > maxCharacterCount))
        {
            workingOnFirstSheet = false;
            currentPageP2 = page2.text + newText;
        }
        else
        {
            AddNewPageToBook();
            currentPageNr++;
            currentPageP1 = string.Empty + textToInput;
            currentPageP2 = string.Empty;
            workingOnFirstSheet = true;
        }
        textBeingShownP1 = currentPageP1;
        textBeingShownP2 = currentPageP2;
        UpdateBookText();
    }

    public void TurnPageForward()
    {
        currentPageNr++;
        if (currentPageNr >= pages.Count + 1)
        {
            currentPageNr--;
            return;
        }
        else
        {
            TurnPage();
        }

    }

    public void TurnPageBackward()
    {
        currentPageNr--;
        if (currentPageNr < 0)
        {
            currentPageNr++;
            return;
        }
        else
        {
            TurnPage();
        }

    }

    public void TurnPage()
    {
        if (currentPageNr == pages.Count)
        {
            textBeingShownP1 = currentPageP1;
            textBeingShownP2 = currentPageP2;
            UpdateBookText();
        }
        else
        {
            foreach (Page p in pages)
            {
                if (p.pageNr == currentPageNr)
                {
                    textBeingShownP1 = p.text1;
                    textBeingShownP2 = p.text2;
                    UpdateBookText();
                    return;
                }
            }
        }
        if ((currentPageNr - 1) < 0)
        {
            HideLeftArrow();
        }
        else if ((currentPageNr + 1) > pages.Count)
        {
            HideRightArrow();
        }
    }
    private void HideLeftArrow()
    {
        leftArrow.SetActive(false);
    }

    private void HideRightArrow()
    {
        rightArrow.SetActive(false);
    }

    private void UpdateBookText()
    {
        page1.text = textBeingShownP1;
        page2.text = textBeingShownP2;
    }

    private void AddNewPageToBook()
    {
        Page newPage = new Page
        {
            text1 = currentPageP1,
            text2 = currentPageP2,
            pageNr = workingOnPage
        };
        pages.Add(newPage);
        workingOnPage++;
        Debug.Log(pages.Count);
    }
}
