using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Util;

public class GameManager : Singleton<GameManager>
{
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
		PlayerDead
	}

	public void Win() {
		SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1)%SceneManager.sceneCount);
	}
}
