﻿using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance;

	public AudioClip gameOverMusic;
	public AudioClip dieSound;
	public AudioClip gameMusic;

	AudioSource source;

	void Awake () {
		if (Instance != null && Instance != this) {
			DestroyImmediate (gameObject);
		} else {
			Instance = this;
			DontDestroyOnLoad (gameObject);
			source = GetComponent<AudioSource> ();
		}
	}

	public void OnLevelWasLoaded() {
		if (source.isPlaying && source.clip != gameMusic) {
			source.Stop ();
			source.clip = gameMusic;
			source.Play ();
		}
	}

	public void Die() {

		source.Stop ();
		source.PlayOneShot (dieSound);
		source.clip = gameOverMusic;
		source.Play ();
	}
}
