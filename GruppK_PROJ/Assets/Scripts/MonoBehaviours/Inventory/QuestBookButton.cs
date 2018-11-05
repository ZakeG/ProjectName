using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBookButton : MonoBehaviour {

    public GameObject book;
    private bool bookOpen;

	void Start () {
        bookOpen = true;
    }
    public void ToggleBookOpen()
    {
        if (!bookOpen)
        {
            OpenBook();
        }
        else
        {
            CloseBook();
        }
    }
    public void OpenBook()
    {
        bookOpen = true;
        book.SetActive(bookOpen);
    }

    public void CloseBook()
    {
        bookOpen = false;
        book.SetActive(bookOpen);
    }

}
