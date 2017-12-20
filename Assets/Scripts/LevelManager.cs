﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void GoToLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
