using UnityEngine;

public class AudioReaction : DelayedReaction
{
    public AudioSource audioSource;
    public AudioClip audioClip;


    protected override void ImmediateReaction()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}