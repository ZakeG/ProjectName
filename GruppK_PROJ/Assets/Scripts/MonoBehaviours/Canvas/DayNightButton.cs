using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayNightButton : MonoBehaviour {

    public Condition currentState;
    public SceneController scene;

    [SerializeField]
    private Image staffPicRefrence;
    private List<GameObject> DayObjectsFromScene = new List<GameObject>();
    private List<GameObject> NightObjectsFromScene = new List<GameObject>();
    private Condition lightStaff;
    private StaffObjectContainer currentSceneLightContainer;
    private Color nightColor;
    private bool day;

    [SerializeField]
    private GameObject arrow;
    private bool arrowActive;

    
    private void Start()
    {
        day = true;
        arrowActive = true;
        nightColor = new Color(0/255, 208/255, 255/255);
        currentState.satisfied = true;
        scene.AfterSceneLoad += OnSceneTransition;
        HideButton();
    }

    public void OnClick()
    {
        if (arrowActive && arrow != null)
        {
            arrow.SetActive(false);
            arrowActive = false;
        }
        ToggleLights();
    }

    public void UpdateLightList()
    {
        HandleDayObjects(currentSceneLightContainer.GetDayList());
        HandleNightObjects(currentSceneLightContainer.GetNightList());
    }

    private void HandleDayObjects(List<GameObject> list)
    {
        DayObjectsFromScene.Clear();
        foreach (GameObject o in list)
        {
            if (!(o == null) && !o.CompareTag("RemovedByReaction"))
            {
                DayObjectsFromScene.Add(o);
            }
        }
    }

    private void HandleNightObjects(List<GameObject> list)
    {
        NightObjectsFromScene.Clear();
        foreach (GameObject o in list)
        {
            if (!(o == null) && !o.CompareTag("RemovedByReaction"))
            {
                NightObjectsFromScene.Add(o);
            }
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
                if (!(go == null))
                {
                    go.SetActive(true);
                }
            }
            foreach (GameObject go in NightObjectsFromScene)
            {
                if (!(go == null))
                {
                    go.SetActive(false);
                }
            }
        }
        else if(currentState.satisfied == false) {
            foreach (GameObject go in DayObjectsFromScene)
            {
                if (!(go == null))
                {
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
        if (gameObject.activeSelf == false)
        {
            HandleDayObjects(currentSceneLightContainer.GetDayList());
            HandleNightObjects(currentSceneLightContainer.GetNightList());
        }
        else
        {
            StartCoroutine(GracePeriod());
        }
        CheckLights();
        CheckIcon();
    }

    IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(1);
        HandleDayObjects(currentSceneLightContainer.GetDayList());
        HandleNightObjects(currentSceneLightContainer.GetNightList());
    }

    private void CheckIcon()
    {
        if (day)
        {
            staffPicRefrence.color = Color.white;
        }
        else
        {
            staffPicRefrence.color = nightColor;
        }
    }

    private void ToggleLights()
    {
        currentState.satisfied = !currentState.satisfied;
        if (day)
        {
            day = false;
        }
        else
        {
            day = true;
        }
        CheckLights();
        CheckIcon();
    }

}
