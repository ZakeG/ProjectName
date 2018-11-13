using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ReactionCollection : MonoBehaviour
{

    public struct Instruction
    {
        public Reaction reaction;
        public float order;
    }

    public Reaction[] reactions = new Reaction[0];
    private List<Instruction> immediateInstructions = new List<Instruction>();
    private List<Instruction> instructions = new List<Instruction>();

    private PlayerMovement playerMovementScript;
    private bool reactionsStarted;
    private int reactionOrderNumber;

    private Texture2D cursorIneracting;
    private Texture2D cursorArrow;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    private void Start ()
    {
        //Deklarera cursorIneracting med GetResource
        //Deklarera cursorArrow med GetResource
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        reactionsStarted = false;
        for (int i = 0; i < reactions.Length; i++)
        {
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
            {
                delayedReaction.Init();
                ManageDelayedReactions(delayedReaction, delayedReaction.order);
            }
            else
            {
                reactions[i].Init();
                ManageImmidiateReactions(reactions[i], 99);
            }
        }
            
    }

    private void Update()
    {
        if (reactionsStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (reactionOrderNumber < reactions.Length)
                {
                    RunNextReactions();
                }
                else if(reactionOrderNumber == reactions.Length)
                {
                    ReactionsAlmostFinished();
                }
                else if (reactionOrderNumber > reactions.Length)
                {
                    ReactionsFinished();
                    return;
                }
                reactionOrderNumber++;
            }
        }
    }
    public void ManageDelayedReactions(Reaction reaction, float displayOrder)
    {
        Instruction newInstruction = new Instruction
        {
            reaction = reaction,
            order = displayOrder
        };
        instructions.Add(newInstruction);
        SortInstructions();
    }
    public void ManageImmidiateReactions(Reaction reaction, float displayOrder)
    {
        Instruction newInstruction = new Instruction
        {
            reaction = reaction,
            order = displayOrder
        };
        immediateInstructions.Add(newInstruction);
    }

    private void RunNextReactions()
    {
        for (int i = 0; i < instructions.Count; i++)
        {
            if (instructions[i].order == reactionOrderNumber)
            {
                instructions[i].reaction.React(this);
            }
        }

    }
    private void RunAllImmidiateReactions()
    {
        foreach(Instruction a in immediateInstructions)
        {
            a.reaction.React(this);
        }
    }

    private void StartReactions()
    {
        //Cursor.SetCursor(cursorIneracting, hotSpot, cursorMode); När det finns en cursorIneracting ta bort kommentering
        reactionsStarted = true;
        playerMovementScript.PauseUnpauseReaction(true);
        RunAllImmidiateReactions();
        RunNextReactions();
        reactionOrderNumber = 1;

    }
    private void ReactionsAlmostFinished()
    {
        //Cursor.SetCursor(cursorArrow, hotSpot, cursorMode); När det finns en cursorIneracting ta bort kommentering
    }

    private void ReactionsFinished()
    {
        reactionsStarted = false;
        playerMovementScript.PauseUnpauseReaction(false);
    }
    
    public void React ()
    {
        StartReactions();
    }

    public void ReactImmidiateReactions()
    {
        RunAllImmidiateReactions();
    }

    private void SortInstructions()
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
