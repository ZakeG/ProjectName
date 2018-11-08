using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightButton : MonoBehaviour {

    public Condition currentState;
    public SceneController scene;

    private List<GameObject> DayObjectsFromScene = new List<GameObject>();
    private List<GameObject> NightObjectsFromScene = new List<GameObject>();
    private Condition lightStaff;
    private StaffObjectContainer currentSceneLightContainer;

    private void Start()
    {
        scene = GameObject.Find("SceneController").GetComponent<SceneController>();
        scene.AfterSceneLoad += OnSceneTransition;
        HideButton();
    }

    public void OnClick()
    {
        ToggleLights();
    }

    private void HandleDayObjects(List<GameObject> list)
    {
        DayObjectsFromScene.Clear();
        foreach (GameObject o in list)
        {
            DayObjectsFromScene.Add(o);
        }
    }

    private void HandleNightObjects(List<GameObject> list)
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
                if (!(go==null)) {
                    go.SetActive(false);
                }
            }
            foreach (GameObject go in NightObjectsFromScene)
            {
                if (!(go == null))
                {
                    go.SetActive(true);
                }
            }
        }
    }
    private void OnSceneTransition()
    {
        currentSceneLightContainer = null;
        currentSceneLightContainer = GameObject.FindWithTag("LightsList").GetComponent<StaffObjectContainer>();
        HandleDayObjects(currentSceneLightContainer.GetDayList());
        HandleNightObjects(currentSceneLightContainer.GetNightList());
        CheckLights();
    }

    private void ToggleLights()
    {
        currentState.satisfied = !currentState.satisfied;
        foreach (GameObject go in DayObjectsFromScene)
        {
            if (!(go == null))
            {
                go.SetActive(currentState.satisfied);
            }
        }
        foreach (GameObject go in NightObjectsFromScene)
        {
            if (!(go == null))
            {
                go.SetActive(!currentState.satisfied);
            }
        }
    }

}
