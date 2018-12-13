using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour {

    [SerializeField]
    private GameObject optionsMenu;
    private Image activeBorder;

    private Color originalColor;
    private bool optionsMenuOpen;

    private void Start()
    {
        optionsMenuOpen = false;
        activeBorder = gameObject.GetComponent<Image>();
        originalColor = activeBorder.color;
    }

    public void OnClick()
    {
        if (!optionsMenuOpen)
        {
            OpenOptionsMenu();
        }
        else
        {
            CloseOptionsMenu();
        }
    }

    public void OpenOptionsMenu()
    {
        activeBorder.color = Color.yellow;
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        activeBorder.color = originalColor;
        optionsMenu.SetActive(false);
    }
    
}
