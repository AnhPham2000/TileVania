using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : Singleton<GameSession> {

	[SerializeField] Text liveText;
	[SerializeField] Text ScoreText;

	private int live = 5;
	private int Score = 0;

	// Use this for initialization
	void Start () {
		liveText.text = live.ToString();
		ScoreText.text = Score.ToString();
	}
	
	public void DeathEvent()
	{
		if (live > 1)
			TakeLive();
		else
			ResetGameSession();
	}

	void TakeLive()
	{
		live--;
		var sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneIndex);
		liveText.text = live.ToString();
	}

	void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}

	public void AddToScore(int PointToAdd)
	{
		Score += PointToAdd;
		ScoreText.text = Score.ToString();
	}

}
