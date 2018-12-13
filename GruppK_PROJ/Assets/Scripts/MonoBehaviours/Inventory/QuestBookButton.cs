using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBookButton : MonoBehaviour {

    public GameObject book;
    public GameObject newIcon;
    public bool bookOpen;
    public GameObject activeIconGameObject;
    private SpriteRenderer activeIconSpriteRenderer;
    private SceneController sceneController;
    private Color blackColor;
    private Color yellowColor;

    void Start () {
        blackColor = new Color.black;
        yellowColor = new Color.yellow;
        activeIconSpriteRenderer = activeIconGameObject.GetComponent<SpriteRenderer>();
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
        activeIconGameObject.SetActive(true);
        activeIconSpriteRenderer.Color = yellowColor;
        newIcon.SetActive(false);
        bookOpen = true;
        book.SetActive(bookOpen);
    }

    public void CloseBook()
    {
        activeIconGameObject.SetActive(false);
        activeIconSpriteRenderer.Color = blackColor;
        bookOpen = false;
        book.SetActive(bookOpen);
    }

}
