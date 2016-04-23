using UnityEngine.SceneManagement;
using UnityEngine;
using Util;

public class GameManager : Singleton<GameManager>
{
	bool playerIsSafe = false;

	public GameState CurrentGameState { get; private set; }

	protected override void Awake () {
		base.Awake();
		//Directly jump to the
		CurrentGameState=GameState.Ingame;
	}

	public enum GameState
	{
		TitleScreen,
		Ingame,
		PlayerDead,
		Won
	}

	public void Win() {
		if (SceneManager.GetActiveScene ().buildIndex + 1 == SceneManager.sceneCount && CurrentGameState != GameState.Won) {
			CurrentGameState = GameState.Won;
			AudioManager.Instance.Win ();
		} else {
			SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1)%SceneManager.sceneCount);
		}
	}

	public void Die()
	{
		CurrentGameState=GameState.PlayerDead;
		AudioManager.Instance.Die();
	}

	public void SetPlayerSafe(bool safe) {
		playerIsSafe = safe;
	}

	void Update() {

		if (CurrentGameState == GameState.PlayerDead && Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			CurrentGameState=GameState.Ingame;
		}
	}
}
