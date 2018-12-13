using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class IngameOptions : MonoBehaviour {

    public Condition contrastCondition;
    public Condition zoomCondition;
    public Text contrastText;
    public Text zoomText;
    public SceneController sc;
    public GameObject UsabilityOptionsContainer;
    public GameObject AreYouSureContainer;
    private ContrastEnhance contrastScript;


    private void Start()
    {
        sc.AfterSceneLoad += UpdateContrast;
        sc.AfterSceneLoad += UpdateZoom;
        UsabilityOptionsContainer.SetActive(false);
        AreYouSureContainer.SetActive(false);
        gameObject.SetActive(false);
    }
        
    public void OnContrastClick()
    {
        contrastCondition.satisfied =! contrastCondition.satisfied;
        UpdateContrast();
    }

    public void OnZoomClick()
    {
        zoomCondition.satisfied = !zoomCondition.satisfied;
        UpdateZoom();
    }

    private void UpdateZoom()
    {
        if (zoomCondition.satisfied)
        {
            zoomText.text = "On";
        }
        else
        {
            zoomText.text = "Off";
        }
    }

    private void UpdateContrast()
    {
        if (contrastCondition.satisfied)
        {
            contrastText.text = "On";
        }
        else
        {
            contrastText.text = "Off";
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
