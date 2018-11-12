using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsIntervalls : MonoBehaviour {

	private AudioSource[] sources; 
	public AudioClip Footsteps1;
	public AudioClip Footsteps2;
	public AudioClip Creak;


	public float minDelay;
	public float maxDelay; 


	// Use this for initialization
	void Start () {
		sources = GetComponents<AudioSource> ();
		sources[0].clip = Footsteps1;
		sources[1].clip = Footsteps2;
		sources[2].clip = Creak;



	}

	// Update is called once per frame
	void Update () {

		if (!sources [0].isPlaying) {

			float d = Random.Range (minDelay, maxDelay);

			sources [0].PlayDelayed (d);

		}
		if (!sources [1].isPlaying) {

			float d = Random.Range (minDelay, maxDelay);

			sources [1].PlayDelayed (d);

		}
		if (!sources [2].isPlaying) {

			float d = Random.Range (minDelay, maxDelay);

			sources [2].PlayDelayed (d);

		}
	}
}
