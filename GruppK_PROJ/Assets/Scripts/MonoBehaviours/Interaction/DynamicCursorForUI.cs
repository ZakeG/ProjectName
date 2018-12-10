using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCursorForUI : MonoBehaviour {
    public Texture2D hand;
    public Texture2D feet;
    public Condition playerIsInteractingCondition;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    public void Enter()
    {
        if (!playerIsInteractingCondition.satisfied)
        {
            Cursor.SetCursor(hand, hotSpot, cursorMode);
        }
    }

    public void Exit()
    {
        if (!playerIsInteractingCondition.satisfied)
        {
            Cursor.SetCursor(feet, hotSpot, cursorMode);
        }
    }
}
