using UnityEngine;

public class AudioReaction : DelayedReaction
{
    public AudioSource audioSource;
    public AudioClip audioClip;


    protected override void ImmediateReaction()
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}