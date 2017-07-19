using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	private AudioSource audiosource;
	public static SoundManager instance;
	// Use this for initialization

	public AudioClip clip;
	public AudioClip pause;
	void Awake(){
		if (instance == null)
			instance = this;
	}

	void Start () {
		audiosource = this.gameObject.GetComponent<AudioSource> ();
	}

	public void playItem(){
		audiosource.PlayOneShot (clip);
	}

	public void playPause(){
		audiosource.PlayOneShot (pause);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
