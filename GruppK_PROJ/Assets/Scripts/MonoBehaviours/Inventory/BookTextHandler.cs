using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookTextHandler : MonoBehaviour {

    public GameObject secondPage;
    public string textBeingShownP1;
    public string textBeingShownP2;
    public int currentPageNr;
    public int lookingAtPage;

    private List<Page> pages;
    private Text page1;
    private Text page2;
    private string currentPageP1;
    private string currentPageP2;
    private string textToAdd;
    private int workingOnPage;

    private const int maxCharacterCount = 480;
    private const int line = 24;

    public struct Page
    {
        public string text1;
        public string text2;
        public int pageNr;
    }

    public void Start()
    {
        lookingAtPage = 1;
        workingOnPage = 1;
        currentPageNr = 1;
        page1 = gameObject.GetComponent<Text>();
        page2 = secondPage.GetComponent<Text>();
        pages = new List<Page>();
        StartBook();
    }

    private void StartBook()
    {
        currentPageP1 = page1.text;
        currentPageP2 = page2.text;
        textBeingShownP1 = currentPageP1;
        textBeingShownP2 = currentPageP2;
        UpdateBookText();
    }

    public void AddText(string newText)
    {
        string textToInput = newText + System.Environment.NewLine + "-----------------------------------------";
        string testText1 = page1.text + textToInput;
        string testText2 = page2.text + textToInput;
        if (!(testText1.Length > maxCharacterCount)) {
            currentPageP1 = page1.text + newText;
        }
        else if (!(testText2.Length > maxCharacterCount))
        {
            currentPageP2 = page2.text + newText;
        }
        else
        {
            AddNewPageToBook();
            currentPageP1 = string.Empty + textToInput;
            currentPageP2 = string.Empty;
        }
        textBeingShownP1 = currentPageP1;
        textBeingShownP2 = currentPageP2;
        UpdateBookText();
    }

    public void TurnPageForward()
    {
        currentPageNr++;
        if (pages.Count > currentPageNr)
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
        if (pages.Count < currentPageNr)
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
    }
}
