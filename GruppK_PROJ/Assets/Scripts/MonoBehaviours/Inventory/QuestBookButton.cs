using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBookButton : MonoBehaviour {

    public GameObject book;
    public GameObject newIcon;
    public bool bookOpen;
    public Condition playerReadingCondition;
    private SceneController sceneController;
    

    void Start () {
        bookOpen = true;
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        sceneController.BeforeSceneUnload += OpenBook;
    }

    private void Update()
    {
        if (book.activeSelf == true)
        {
            playerReadingCondition.satisfied = true;
        }
        if (book.activeSelf == false)
        {
            playerReadingCondition.satisfied = false;
        }
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
        newIcon.SetActive(false);
        bookOpen = true;
        book.SetActive(bookOpen);
    }

    public void CloseBook()
    {
        bookOpen = false;
        book.SetActive(bookOpen);
    }

}
