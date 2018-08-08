using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : Singleton<ScenePersist> {

	private int StartSceneIndex;

	// Use this for initialization
	void Start () {
		StartSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex != StartSceneIndex)
			Destroy(gameObject);
	}
}
