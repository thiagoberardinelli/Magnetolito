using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLevelEndAreas : MonoBehaviour
{
	private List<EndLevelArea> EndLevelAreas = new List<EndLevelArea>();

	public GameObject winPanel;
	public GameObject forceManager;

	public List<MovableObject> StopAllObjects = new List<MovableObject>();

	private float timerCheckObjects = 0f;
	private float timeVariation = 1f;
	private float timeLimit = 3f;

	private bool levelCompleted;


	private void Update()
	{
		CheckEndLevelAreas();
	}

	public void RegisterEndGameArea(EndLevelArea endLevelArea)
	{
		EndLevelAreas.Add(endLevelArea);
	}

	private void CheckEndLevelAreas()
	{
		foreach (EndLevelArea Area in EndLevelAreas)
		{
			if (!Area.HasAllObjects)
			{
				timerCheckObjects = 0f;
				return;
			}

			if (Area.HasAllObjects)
			{
				if (levelCompleted == false)
				{
					timerCheckObjects += timeVariation * Time.deltaTime;					
				}

				if (timerCheckObjects >= timeLimit)
				{
					// All objects in their respective areas!
					// Go to next level.

					// Those commands runs after the objetive is complete.
					levelCompleted = true;
					timerCheckObjects = 0f;
					winPanel.SetActive(true);

					// Condition that unlocks new levels
					if (PlayerPrefs.GetInt("maxReachedLevel") <= SceneManager.GetActiveScene().buildIndex - 2)
					{
						PlayerPrefs.SetInt("maxReachedLevel", SceneManager.GetActiveScene().buildIndex - 1);
					}

					// Force all objects to cease movement after the objective is complete.
						foreach (MovableObject Item in StopAllObjects)
					{
						Item.CeaseMovement();
					}
				}
			}
		}
	}
}
