using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBookButton : MonoBehaviour {

    public GameObject book;
    public GameObject newIcon;
    public bool bookOpen;
    private SceneController sceneController;

    void Start () {
        bookOpen = true;
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        sceneController.BeforeSceneUnload += OpenBook;
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
