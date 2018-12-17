using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulScript : MonoBehaviour {

    public List<GameObject> gameObjectList;
    private bool christmasIsOn;

	void Update () {
        if (gameObjectList.Count != 0)
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
        foreach (GameObject go in gameObjectList)
        {
            go.SetActive(true);
        }
    }

    private void TurnOffChristmas()
    {
        foreach (GameObject go in gameObjectList)
        {
            go.SetActive(false);
        }
    }
}
