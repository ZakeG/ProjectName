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


    private bool reactionsStarted;
    private int reactionOrderNumber;
    private float clicksNeeded;
    private TextManager textManager;
    private PlayerMovement playerMovementScript;
    private AudioSource audioSource;
    private Condition[] tempConditionInitList;
    private Condition playerisInteracting;
    private DelayedReaction interactableOffReaction;


    private void Awake ()
    {
        audioSource = GameObject.Find("VO").GetComponent<AudioSource>();
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        textManager = GameObject.Find("MessageCanvas").GetComponent<TextManager>();
        clicksNeeded = 0;
        tempConditionInitList = Resources.FindObjectsOfTypeAll<Condition>();
        foreach (Condition t in tempConditionInitList)
        {
            if (t.description == "PLAYERISINTERACTING")
            {
                playerisInteracting = t;
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
            else if (delayedReaction && delayedReaction.order == 1000 && delayedReaction is GameObjectReaction)
            {
                interactableOffReaction = delayedReaction;
            }
            else if (delayedReaction)
            {
                delayedReaction.Init();
                ManageDelayedReactions(delayedReaction, delayedReaction.order);
            }
            else
            {
                reactions[i].Init();
                ManageImmidiateReactions(reactions[i], 99);
            }

            if (delayedReaction != null && clicksNeeded < delayedReaction.order && delayedReaction.order != 1000)
            {
                clicksNeeded = delayedReaction.order;
            }
        }
        clicksNeeded = clicksNeeded + 1;
    }

    private void Update()
    {
        if (reactionsStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                reactionOrderNumber++;
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
                }

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
        playerMovementScript.PauseUnpauseReaction(true);
        playerMovementScript.PauseUnpauseCursorSwitch(true);
        reactionOrderNumber = 0;
        RunAllImmidiateReactions();
        RunNextReactions();

    }
    private void ReactionsAlmostFinished()
    {
        textManager.ClearText();
        textManager.HideTextArea();
        audioSource.Stop();
        playerisInteracting.satisfied = false;
        playerMovementScript.PauseUnpauseCursorSwitch(false);

    }

    private void ReactionsFinished()
    {
        playerMovementScript.PauseUnpauseReaction(false);
        reactionsStarted = false;
        if (interactableOffReaction != null)
        {
            interactableOffReaction.React(this);
        }
        
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
