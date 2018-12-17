using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulScript : MonoBehaviour {

    public List<GameObject> christmasObjects;
    public List<GameObject> nonChristmasObjects;
    private bool christmasIsOn;

	void Update () {
        if (christmasObjects.Count != 0 && nonChristmasObjects.Count != 0)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (christmasIsOn)
                {
                    TurnOffChristmas();
                }
                else
                {
                    TurnOnChristmas();
                }
            }
        }
	}

    private void TurnOnChristmas()
    {
        foreach (GameObject go in christmasObjects)
        {
            go.SetActive(true);
        }
        foreach (GameObject ngo in nonChristmasObjects)
        {
            ngo.SetActive(false);
        }
    }

    private void TurnOffChristmas()
    {
        foreach (GameObject go in christmasObjects)
        {
            go.SetActive(false);
        }
        foreach (GameObject ngo in nonChristmasObjects)
        {
            ngo.SetActive(true);
        }
    }
}
