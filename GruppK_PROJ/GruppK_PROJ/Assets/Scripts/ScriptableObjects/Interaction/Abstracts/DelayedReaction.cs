using UnityEngine;
using System.Collections;

public abstract class DelayedReaction : Reaction
{
    public float order;

    public new void Init ()
    {

        SpecificInit ();
    }


    public new void React (MonoBehaviour monoBehaviour)
    {
        ImmediateReaction();
    }
}
