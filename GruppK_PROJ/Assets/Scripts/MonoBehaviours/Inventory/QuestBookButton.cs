using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBookButton : MonoBehaviour {

    public GameObject book;
    public GameObject newIcon;
    public bool bookOpen;
    private Image activeBorder;
    private SceneController sceneController;
    private Color originalColor;

    void Start () {
        activeBorder = gameObject.GetComponent<Image>();
        originalColor = activeBorder.color;
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
        activeBorder.color = Color.yellow;
        newIcon.SetActive(false);
        bookOpen = true;
        book.SetActive(bookOpen);
    }

    public void CloseBook()
    {
        activeBorder.color = originalColor;
        bookOpen = false;
        book.SetActive(bookOpen);
    }

}
