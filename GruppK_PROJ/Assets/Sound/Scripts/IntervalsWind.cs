using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalsWind : MonoBehaviour {

	private AudioSource[] sources; 
	public AudioClip creak;


	public float minDelay;
	public float maxDelay; 


	// Use this for initialization
	void Start () {
		sources = GetComponents<AudioSource> ();
		sources[0].clip = creak;




	}

	// Update is called once per frame
	void Update () {

		if (!sources [0].isPlaying) {

			float d = Random.Range (minDelay, maxDelay);

			sources [0].PlayDelayed (d);

		}
	}
}
