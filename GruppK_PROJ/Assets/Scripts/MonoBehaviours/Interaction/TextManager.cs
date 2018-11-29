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
    private int messageNumber;

    private void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text.text = string.Empty;
        dialugeStarted = false;
    }

 /*   private void Update ()
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
    }*/

    public void HandleTextMessages(List<Reaction> txtReactions)
    {
        foreach (TextReaction txtr in txtReactions)
        {
        Instruction newInstruction = new Instruction
        {
            message = txtr.message,
            textColor = txtr.textColor,
            order = txtr.order
        };
        instructions.Add(newInstruction);
        SortInstructions();
        }
    }

    public void DisplayMessage()
    {
        if (!dialugeStarted) {
            DialougeStarted();
        }
        else if (messageNumber == instructions.Count)
        {
            DialougeStopped();
            return;
        }
        else
        {
            ShowNextMessage();
        }
        messageNumber++;
    }

    private void DialougeStarted()
    {
        dialugeStarted = true;
        background.SetActive(true);
        text.text = instructions[0].message;
        text.color = instructions[0].textColor;
        messageNumber = 1;
    }

    private void DialougeStopped()
    {
        background.SetActive(false);
        dialugeStarted = false;
        instructions.Clear();
        background.SetActive(false);
        text.text = string.Empty;
    }

    private void ShowNextMessage()
    {
        text.text = instructions[messageNumber].message;
        text.color = instructions[messageNumber].textColor;
        messageNumber++;

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

