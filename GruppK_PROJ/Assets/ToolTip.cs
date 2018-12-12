using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    public GameObject toolTipBackground;
    public Text toolTipText;
    public Vector3 offset;


    private void Awake()
    {
        toolTipBackground.SetActive(false);
    }

    void Update()
    {
        transform.position = Input.mousePosition + offset;
    }

    public void ShowTooltip(GameObject itemSlot)
    {
        if (itemSlot.GetComponent<InventoySlot>().GetItem() != null) {
            toolTipBackground.SetActive(true);
            toolTipText.text = itemSlot.GetComponent<InventoySlot>().GetItem().GetToolTipMessage();
        }
    }

    public void HideToolTip()
    {
        toolTipText.text = string.Empty;
        toolTipBackground.SetActive(false);
    }
}
