using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCursor : MonoBehaviour {

    public Texture2D arrow;
    public Texture2D hand;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    public void Start()
    {
        Cursor.SetCursor(arrow, hotSpot, cursorMode);
    }

    public void ChangeToArrow()
    {
        Cursor.SetCursor(arrow, hotSpot, cursorMode);
    }

    public void ChangeToHand()
    {
        Cursor.SetCursor(hand, hotSpot, cursorMode);
    }
}
