using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelEndAreas : MonoBehaviour {

	private List<EndLevelArea> EndLevelAreas = new List<EndLevelArea>();

	public GameObject winPanel;
	public GameObject forceManager;
	
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
					Debug.Log(timerCheckObjects);
				}

				if (timerCheckObjects >= timeLimit)
				{
					// All objects in their respective areas!
					// Go to next level.
					Debug.Log("Level Complete");
					levelCompleted = true;
					timerCheckObjects = 0f;					
					winPanel.SetActive(true);
					forceManager.GetComponent<MagneticManager>().enabled = false;
				}
			}
		}
	}
}
