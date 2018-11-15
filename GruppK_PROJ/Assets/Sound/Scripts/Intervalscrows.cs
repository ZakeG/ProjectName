using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intervalscrows : MonoBehaviour {


    private AudioSource[] sources;
    public AudioClip CrowCall;


    public float minDelay;
    public float maxDelay;


    // Use this for initialization
    void Start()
    {
        sources = GetComponents<AudioSource>();
        sources[1].clip = CrowCall;

    }

    // Update is called once per frame
    void Update()
    {

        if (!sources[0].isPlaying)
        {

            float d = Random.Range(minDelay, maxDelay);

            sources[0].PlayDelayed(d);


        }
    }
}
