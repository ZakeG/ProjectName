using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour {

    private GameObject inventory;

	// Use this for initialization
	void Start () {
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
    }
    public void OnClick()
    {
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }
}
