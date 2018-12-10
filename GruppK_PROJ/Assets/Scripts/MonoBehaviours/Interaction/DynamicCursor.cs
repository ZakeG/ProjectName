using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCursor : MonoBehaviour {

    public Texture2D feet;
    public Texture2D hand;
    public Condition playerIsInteractingCondition;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private bool paused;
    private PlayerMovement player;

    public void Start()
    {
        Cursor.SetCursor(hand, hotSpot, cursorMode);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        paused = player.GetInteractionBool();

    }

    public void OnMouseEnter()
    {
        if (!playerIsInteractingCondition.satisfied)
        {
            if (!paused)
            {
                Cursor.SetCursor(hand, hotSpot, cursorMode);
            }
        }
    }

    public void OnMouseExit()
    {
        if (!playerIsInteractingCondition.satisfied)
        {
            if (!paused)
            {
                Cursor.SetCursor(feet, hotSpot, cursorMode);
            }
        }
    }

    
}
