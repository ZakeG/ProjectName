using UnityEngine;
using UnityEngine.Audio;

public class PickedUpItemReaction : DelayedReaction
{
    public Item item;


    private Inventory inventory;
    private AudioClip pickup;
    private AudioClip[] tempIntList;
    private AudioSource audioSource;

    protected override void SpecificInit()
    {
        tempIntList = Resources.FindObjectsOfTypeAll<AudioClip>();
        foreach (AudioClip ac in tempIntList)
        {
            if (ac.name == "Small_Bell_Jingle")
            {
                pickup = ac;
            }
        }
        audioSource = GameObject.Find("FX").GetComponent<AudioSource>();
        inventory = FindObjectOfType<Inventory>();
    }


    protected override void ImmediateReaction()
    {
        audioSource.PlayOneShot(pickup);
        inventory.DehighlightAll();
        inventory.AddItem(item);
    }
}
