using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBarFuncionalities : MonoBehaviour {

	private bool isPaused = false;
	
	public void Pause()
	{
		if (isPaused == false)
		{
			Time.timeScale = 0f;
		}

		else if (isPaused == true)
		{
			Time.timeScale = 1f;
		}

		isPaused = !isPaused;
	}

	public void RestartLevel()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}
}
