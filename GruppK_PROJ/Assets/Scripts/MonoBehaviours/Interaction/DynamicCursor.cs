using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCursor : MonoBehaviour {

    public Texture2D arrow;
    public Texture2D hand;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private bool paused;
    private PlayerMovement player;

    public void Start()
    {
        Cursor.SetCursor(arrow, hotSpot, cursorMode);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        paused = player.GetInteractionBool();

    }

    public void ChangeToFeet()
    {
        if (!paused) {
            Cursor.SetCursor(arrow, hotSpot, cursorMode);
        }
    }

    public void ChangeToPaw()
    {
        if (!paused)
        {
            Cursor.SetCursor(hand, hotSpot, cursorMode);
        }
    }
}
