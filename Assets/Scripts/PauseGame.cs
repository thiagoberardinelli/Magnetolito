using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

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
}
