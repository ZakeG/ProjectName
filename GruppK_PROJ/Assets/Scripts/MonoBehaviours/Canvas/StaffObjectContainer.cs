using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffObjectContainer : MonoBehaviour {
    public List<GameObject> DayObjects = new List<GameObject>();
    public List<GameObject> NightObjects = new List<GameObject>();
    private DayNightButton button;

    void Initialize()
    {
        button = GameObject.Find("StaffButton").GetComponent<DayNightButton>();
        button.HandleOnObjects(DayObjects);
        button.HandleOffObjects(NightObjects);
    }

}
