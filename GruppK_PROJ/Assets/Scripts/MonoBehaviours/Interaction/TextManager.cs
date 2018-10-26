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

    private PlayerMovement playerMovementScript;
    private List<Instruction> instructions = new List<Instruction> ();
    private float clearTime;
    private bool dialugeStarted;
    private int messageNumber;

    private void Start()
    {
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
                    messageNumber++;
                }
                else if(messageNumber >= instructions.Count)
                {
                    DialougeStopped();
                }
            }
        }
    }

    public void DisplayMessage(string message, Color textColor, float displayOrder)
    {  
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
        text.text = instructions[0].message;
        text.color = instructions[0].textColor;
        messageNumber = 1;
        dialugeStarted = true;
        playerMovementScript.PauseUnpauseInteraction(false);
    }
    private void DialougeStopped()
    {
        dialugeStarted = false;
        playerMovementScript.PauseUnpauseInteraction(true);
        text.text = string.Empty;
        instructions.Clear();
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

