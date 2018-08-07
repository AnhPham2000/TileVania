using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

	private float levelLoadDelay = 2f;
	private float slowMotionTime = 0.5f;

	void OnTriggerEnter2D(Collider2D col)
	{
		StartCoroutine(LoadNextLevel());
	}

	IEnumerator LoadNextLevel()
	{
		Time.timeScale = slowMotionTime;
		yield return new WaitForSecondsRealtime(levelLoadDelay);
		Time.timeScale = 1f;
		var sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneIndex + 1);
	}

}
