using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectReaction : DelayedReaction
{
    public GameObject gameObject;
    public bool activeState;
    public bool isAffectedByStaff;
    private GameObject[] tempIntList;
    private DayNightButton buttonScript;

    protected override void SpecificInit()
    {
        tempIntList = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject o in tempIntList)
        {
            if (o.name == "StaffButton")
            {
                buttonScript = o.GetComponent<DayNightButton>();
            }
        }
    }

    protected override void ImmediateReaction()
    {
        gameObject.SetActive (activeState);
        if (activeState == false && isAffectedByStaff)
        {
            gameObject.tag = "RemovedByReaction";
            UpdateList();
        }
    }

    public void UpdateList()
    {
        buttonScript.UpdateLightList();
    }

}