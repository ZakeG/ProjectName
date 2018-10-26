using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform interactionLocation;
    public float interactionDuration = 0; //Endast för POC
    public ConditionCollection[] conditionCollections = new ConditionCollection[0];
    public ReactionCollection defaultReactionCollection;


    public void Interact ()
    {
        for (int i = 0; i < conditionCollections.Length; i++)
        {
            if (conditionCollections[i].CheckAndReact ())
                return;
        }

        defaultReactionCollection.React ();
    }
}
