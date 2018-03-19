using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public float timeToLoadNextScene;

	private void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			Invoke("LoadNextLevel", timeToLoadNextScene);
		}
	}
	
	public void GoToLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
