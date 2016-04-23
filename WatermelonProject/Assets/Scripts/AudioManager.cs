using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance;

	public AudioClip gameOverMusic;
	public AudioClip dieSound;
	public AudioClip gameMusic;
	public AudioClip sucessSound;
	public AudioClip sucessMusic;

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
		if (SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1 && source.isPlaying && source.clip != gameMusic) {
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

	public void Win() {
		source.Stop ();
		source.PlayOneShot (sucessSound);
		source.clip = sucessMusic;
		source.Play ();
	}
}
