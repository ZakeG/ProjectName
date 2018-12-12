using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour {

    private GameObject inventory;
    private GameObject newIcon;

	void Start () {
        newIcon = GameObject.Find("NewIcon");
        newIcon.SetActive(false);
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
    }

    public void OnClick()
    {
        HideNewIcon();
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
        else
        {
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
