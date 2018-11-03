using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightButton : MonoBehaviour {

    public Condition currentState; 

    private List<GameObject> onObjectsFromScene = new List<GameObject>();
    private List<GameObject> offObjectsFromScene = new List<GameObject>();
    private Condition lightStaff;
    private bool lightsOn = true;

    public void OnClick()
    {
        LightSwitch();
    }

    private void LightSwitch()
    {
        if (lightsOn)
        {
            LightsOut();
        }
        else
        {
            LetThereBeLight();
        }
    }

    private void LetThereBeLight()
    {
        currentState.satisfied = true;
        foreach (GameObject go in onObjectsFromScene)
        {
            go.SetActive(true);
        }
        foreach(GameObject go in offObjectsFromScene)
        {
            go.SetActive(false);
        }
        lightsOn = true;
    }
    
    private void LightsOut()
    {
        currentState.satisfied = false;
        foreach (GameObject go in onObjectsFromScene)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in offObjectsFromScene)
        {
            go.SetActive(true);
        }
        lightsOn = false;
    }

    public void HandleOnObjects(List<GameObject> list)
    {
        foreach (GameObject o in list)
        {
            onObjectsFromScene.Add(o);
        }
    }

    public void HandleOffObjects(List<GameObject> list)
    {
        foreach (GameObject o in list)
        {
            offObjectsFromScene.Add(o);
        }
    }


}
