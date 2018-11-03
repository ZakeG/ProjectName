using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffObjectContainer : MonoBehaviour {
    public List<GameObject> ToTurnOn = new List<GameObject>();
    public List<GameObject> ToTurnOff = new List<GameObject>();
    private DayNightButton button;



    void Start () {
        button = GameObject.Find("Staff Button").GetComponent<DayNightButton>();
        button.HandleOnObjects(ToTurnOn);
        button.HandleOffObjects(ToTurnOff);
    }



}
