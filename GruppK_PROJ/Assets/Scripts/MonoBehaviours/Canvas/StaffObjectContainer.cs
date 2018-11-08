using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffObjectContainer : MonoBehaviour {
    public List<GameObject> DayObjects = new List<GameObject>();
    public List<GameObject> NightObjects = new List<GameObject>();

    public List<GameObject> GetDayList()
    {
        return DayObjects;
    }
    public List<GameObject> GetNightList()
    {
        return NightObjects;
    }

}
