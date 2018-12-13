using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCursor : MonoBehaviour {

    public PointerContainer pc;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private bool paused;
    private bool notSwitchedToInteracting;
    private PlayerMovement player;


    public void Start()
    {
        notSwitchedToInteracting = true;
        Cursor.SetCursor(pc.feet, hotSpot, cursorMode);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        paused = player.GetInteractionBool();

        if (paused && notSwitchedToInteracting)
        {
            Cursor.SetCursor(pc.interacting, hotSpot, cursorMode);
            notSwitchedToInteracting = false;
        }
        if (!paused)
        {
            notSwitchedToInteracting = true;
        }
    }

    public void OnMouseExit()
    {
        if (!paused) {
            Cursor.SetCursor(pc.feet, hotSpot, cursorMode);
        }
    }

    public void OnMouseEnter()
    {
        if (!paused)
        {
            Cursor.SetCursor(pc.hand, hotSpot, cursorMode);
        }
    }
}
