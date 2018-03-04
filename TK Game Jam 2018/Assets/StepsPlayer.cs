using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsPlayer : MonoBehaviour {
	AudioSource myAudioSrc;
	[SerializeField]
	AudioClip[] stepSounds;
	// Use this for initialization
	void Start () {
		myAudioSrc = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayStepSound(){
		myAudioSrc.clip = stepSounds [Random.Range (0, stepSounds.Length)];
		myAudioSrc.Play ();
	}
}
