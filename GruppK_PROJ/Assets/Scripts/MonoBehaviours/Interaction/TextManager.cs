using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextManager : MonoBehaviour
{
    public struct Instruction
    {
        public string message;
        public Color textColor;
        public float order;
    }

    public Text text;
    public GameObject background;

    private PlayerMovement playerMovementScript;
    private List<Instruction> instructions = new List<Instruction> ();
    private bool dialugeStarted;
    private Texture2D[] tempIntList;
    private Texture2D cursorIneracting;
    private Texture2D cursorArrow;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private int messageNumber;

    private void Start()
    {
        tempIntList = Resources.FindObjectsOfTypeAll<Texture2D>();
        foreach (Texture2D t in tempIntList)
        {
            if (t.name == "pointer_talk")
            {
                cursorIneracting = t;
            }
            if (t.name == "pointer_walk")
            {
                cursorArrow = t;
            }
        }
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text.text = string.Empty;
        dialugeStarted = false;
    }

    private void Update ()
    {
        if (dialugeStarted) {
            if (Input.GetButtonDown("Fire1"))
            {
                if (messageNumber < instructions.Count)
                {
                    ShowNextMessage();
                    
                }
                else if (messageNumber == instructions.Count)
                {
                    DialougeStopping();
                }
                else if(messageNumber > instructions.Count)
                {
                    DialougeStopped();
                    return;
                }
                messageNumber++;
            }
        }
    }

    public void DisplayMessage(string message, Color textColor, float displayOrder)
    {
        background.SetActive(true);
        float order = displayOrder;
        Instruction newInstruction = new Instruction
        {
            message = message,
            textColor = textColor,
            order = order
        };
        instructions.Add(newInstruction);
        SortInstructions();

        if (!dialugeStarted) {
            DialougeStarted();
        }

    }

    private void DialougeStarted()
    {
        Cursor.SetCursor(cursorIneracting, hotSpot, cursorMode);
        dialugeStarted = true;
        playerMovementScript.PauseUnpauseDialouge(true);
        text.text = instructions[0].message;
        text.color = instructions[0].textColor;
        messageNumber = 1;

    }
    private void DialougeStopped()
    { 

        dialugeStarted = false;
        instructions.Clear();
        playerMovementScript.PauseUnpauseDialouge(false);
    }
    private void DialougeStopping()
    {
        Cursor.SetCursor(cursorArrow, hotSpot, cursorMode);
        background.SetActive(false);
        text.text = string.Empty;
    }

    private void ShowNextMessage()
    {
        text.text = instructions[messageNumber].message;
        text.color = instructions[messageNumber].textColor;
    }

    private void SortInstructions ()
    {
        for (int i = 0; i < instructions.Count; i++)
        {
            bool swapped = false;

            for (int j = 0; j < instructions.Count; j++)
            {
                if (instructions[i].order > instructions[j].order)
                {
                    Instruction temp = instructions[i];
                    instructions[i] = instructions[j];
                    instructions[j] = temp;

                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
    }
}

