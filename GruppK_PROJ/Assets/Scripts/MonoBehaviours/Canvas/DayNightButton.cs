using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightButton : MonoBehaviour {

    public GameObject[] objects = new GameObject[30];
    public ReactionCollection turnOnReactionCollection;
    public ReactionCollection turnOffReactionCollection;

    private Condition lightStaff;
    private bool lightsOn = true;


    public void OnClick()
    {
        if (lightsOn)
        {
            turnOffReactionCollection.ReactImmidiateReactions();
        }
        else
        {
            turnOnReactionCollection.ReactImmidiateReactions();
        }
        LightSwitch();
    }

    public void LightSwitch()
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

    public void LetThereBeLight()
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(true);
        }
        lightsOn = true;
    }

    public void LightsOut()
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(false);
        }
        lightsOn = false;
    }

}
