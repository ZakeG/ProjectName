using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButton : MonoBehaviour {

    [SerializeField]
    private Sprite openBag;
    [SerializeField]
    private Sprite closedBag;
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private GameObject newIcon;
    [SerializeField]
    private Image bagIcon;


    private Image activeBorder;
    private Color originalColor;



	void Start () {
        activeBorder = gameObject.GetComponent<Image>();
        originalColor = activeBorder.color;
        newIcon.SetActive(false);
        inventory.SetActive(false);
    }

    public void OnClick()
    {
        HideNewIcon();
        if (inventory.activeSelf)
        {
            activeBorder.color = originalColor;
            bagIcon.sprite = closedBag;
            inventory.SetActive(false);
        }
        else
        {
            activeBorder.color = Color.yellow;
            bagIcon.sprite = openBag;
            inventory.SetActive(true);
        }
    }

    public void HideNewIcon()
    {
        newIcon.SetActive(false);
    }

    public void ShowNewIcon()
    {
        if (inventory.activeSelf)
        {
            return;
        }
        else
        {
            newIcon.SetActive(true);
        }
    }
}
