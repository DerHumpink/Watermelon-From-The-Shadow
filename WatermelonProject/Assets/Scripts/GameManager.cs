using UnityEngine.SceneManagement;
using UnityEngine;
using Util;

public class GameManager : Singleton<GameManager>
{
	bool playerIsSafe = false;

	public static GameState CurrentGameState { get; private set; }

	protected override void Awake () {
		base.Awake();
		//Directly jump to the

		if (CurrentGameState != GameState.PlayerDead) CurrentGameState=GameState.Ingame;
	}

	public enum GameState
	{
		TitleScreen,
		Ingame,
		PlayerDead,
		Won
	}

	public void Win() {
				if (SceneManager.GetActiveScene ().buildIndex + 2 == SceneManager.sceneCountInBuildSettings && CurrentGameState != GameState.Won) {
			CurrentGameState = GameState.Won;
			AudioManager.Instance.Win ();
		} else {
			SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1)%SceneManager.sceneCountInBuildSettings);
		}
	}

	public static int lastScene = 0;
	public void Die()
	{
		if (!playerIsSafe) {
			CurrentGameState = GameState.PlayerDead;
			lastScene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (SceneManager.sceneCountInBuildSettings - 1);
			AudioManager.Instance.Die ();
		}
	}

	public void SetPlayerSafe(bool safe) {
		playerIsSafe = safe;
	}

	void Update() {
		if (CurrentGameState == GameState.PlayerDead && Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene (lastScene);
			CurrentGameState=GameState.Ingame;
		}

		if (CurrentGameState == GameState.Won && Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene (0);
			CurrentGameState=GameState.Ingame;
		}
	}
}
