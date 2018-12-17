using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    public GameObject toolTipBackground;
    public Text toolTipText;
    public Vector3 offset;
    private bool tooltipBeingShown;
    private Vector3 originalPosition;


    private void Awake()
    {
        toolTipBackground.SetActive(false);
        originalPosition = transform.position;
    }

    void Update()
    {
        if(tooltipBeingShown)
        {
            transform.position = Input.mousePosition + offset;
        }
        
    }

    public void ShowTooltip(GameObject itemSlot)
    {
        if (itemSlot.GetComponent<InventoySlot>().GetItem() != null) {
            tooltipBeingShown = true;
            toolTipBackground.SetActive(true);
            toolTipText.text = itemSlot.GetComponent<InventoySlot>().GetItem().GetToolTipMessage();
        }
    }

    public void HideToolTip()
    {
        tooltipBeingShown = false;
        transform.Translate(originalPosition);
        toolTipText.text = string.Empty;
        toolTipBackground.SetActive(false);
    }
}
