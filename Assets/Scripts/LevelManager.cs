using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private List<EndLevelArea> EndLevelAreas = new List<EndLevelArea>();

	public void GoToLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

    public void RegisterEndGameArea(EndLevelArea endLevelArea)
    {
        EndLevelAreas.Add(endLevelArea);
    }

    private void Update()
    {
        CheckEndLevelAreas();
    }

    private void CheckEndLevelAreas()
    {
        foreach (EndLevelArea Area in EndLevelAreas)
        {
            if (! Area.HasAllObjects)
            {
                return;
            }
        }
        // All objects in their respective areas!
        // Go to next level.
        Debug.Log("AEEEEE venceu a fazi!!!");
    }
}
