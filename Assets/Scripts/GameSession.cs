using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : Singleton<GameSession> {

	private int live = 5;

	// Use this for initialization
	void Start () {
		
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
	}

	void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}

}
