﻿using UnityEngine;
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

    private TextManager textManager;
    private PlayerMovement playerMovementScript;
    private bool reactionsStarted;
    private int reactionOrderNumber;
    private AudioSource audioSource;
    private Texture2D[] tempIntList;
    private Texture2D cursorIneracting;
    private Texture2D cursorArrow;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private float clicksNeeded;

    private void Start ()
    {
        clicksNeeded = 0;
        textManager = GameObject.Find("MessageCanvas").GetComponent<TextManager>();
        audioSource = GameObject.Find("VO").GetComponent<AudioSource>();
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
        for (int i = 0; i < reactions.Length; i++)
        {
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction && delayedReaction is AudioReaction)
            {
                if (delayedReaction.order == 0)
                {
                    delayedReaction.Init();
                    ManageDelayedReactions(delayedReaction, delayedReaction.order);
                }
                else
                {
                    delayedReaction.Init();
                    ManageDelayedReactions(delayedReaction, (delayedReaction.order-1));
                }
            } 
            else if (delayedReaction)
            {
                delayedReaction.Init();
                ManageDelayedReactions(delayedReaction, delayedReaction.order);
                if (clicksNeeded < delayedReaction.order)
                {
                    clicksNeeded = delayedReaction.order + 1;
                }
            }
            else
            {
                reactions[i].Init();
                ManageImmidiateReactions(reactions[i], 99);
            }
        }
        Debug.Log(gameObject.name + " has " + clicksNeeded);
    }

    private void Update()
    {
        if (reactionsStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (reactionOrderNumber < clicksNeeded)
                {
                    RunNextReactions();
                }
                else if(reactionOrderNumber == clicksNeeded)
                {
                    ReactionsAlmostFinished();
                }
                else if (reactionOrderNumber > clicksNeeded)
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
        textManager.ShowTextArea();
        Cursor.SetCursor(cursorIneracting, hotSpot, cursorMode);
        playerMovementScript.PauseUnpauseReaction(true);
        reactionOrderNumber = 0;
        RunAllImmidiateReactions();
        RunNextReactions();
        reactionOrderNumber++;

    }
    private void ReactionsAlmostFinished()
    {
        textManager.ClearText();
        textManager.HideTextArea();
        audioSource.Stop();
        Cursor.SetCursor(cursorArrow, hotSpot, cursorMode); 
    }

    private void ReactionsFinished()
    {   
        reactionsStarted = false;
        playerMovementScript.PauseUnpauseReaction(false);
    }
    
    public void React ()
    {
        reactionsStarted = true;
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
