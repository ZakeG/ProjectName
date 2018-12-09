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
    private ContrastEnhance contrastScript;

    private void Start()
    {
        sc.AfterSceneLoad += FindContrastScript;
    }

    private void FindContrastScript()
    {
        contrastScript = GameObject.Find("Camera").GetComponent<ContrastEnhance>();
    }

    public void OnContrastClick()
    {
        contrastCondition.satisfied =! contrastCondition.satisfied;
        if (contrastCondition.satisfied)
        {
            contrastText.text = "On";
            contrastScript.enabled = true;
        }
        else
        {
            contrastText.text = "Off";
            contrastScript.enabled = false;
        }
    }

    public void OnZoomClick()
    {
        zoomCondition.satisfied = !zoomCondition.satisfied;
        if (zoomCondition.satisfied)
        {
            zoomText.text = "On";
        }
        else
        {
            zoomText.text = "Off";
        }
    }

}
