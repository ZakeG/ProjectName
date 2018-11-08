using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightButton : MonoBehaviour {

    public Condition currentState;
    public SceneController scene;

    private List<GameObject> DayObjectsFromScene = new List<GameObject>();
    private List<GameObject> NightObjectsFromScene = new List<GameObject>();
    private Condition lightStaff;

    private void Start()
    {
        scene = GameObject.Find("SceneController").GetComponent<SceneController>();
        scene.AfterSceneLoad += CheckLights;
    }

    public void OnClick()
    {
        ToggleLights();
    }

    public void HandleOnObjects(List<GameObject> list)
    {
        DayObjectsFromScene.Clear();
        foreach (GameObject o in list)
        {
            DayObjectsFromScene.Add(o);
        }
    }

    public void HandleOffObjects(List<GameObject> list)
    {
        NightObjectsFromScene.Clear();
        foreach (GameObject o in list)
        {
            NightObjectsFromScene.Add(o);
        }
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }

    private void CheckLights()
    {
        if (currentState.satisfied == true)
        {
            foreach (GameObject go in DayObjectsFromScene)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in NightObjectsFromScene)
            {
                go.SetActive(false);
            }
        }
        else if(currentState.satisfied == false) {
            foreach (GameObject go in DayObjectsFromScene)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in NightObjectsFromScene)
            {
                go.SetActive(true);
            }
        }
    }

    private void ToggleLights()
    {
        currentState.satisfied = !currentState.satisfied;
        foreach (GameObject go in DayObjectsFromScene)
        {
            go.SetActive(currentState.satisfied);
        }
        foreach (GameObject go in NightObjectsFromScene)
        {
            go.SetActive(!currentState.satisfied);
        }
    }

}
