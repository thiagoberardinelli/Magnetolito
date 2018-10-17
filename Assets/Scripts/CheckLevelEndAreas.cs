using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckLevelEndAreas : MonoBehaviour
{
	private List<EndLevelArea> EndLevelAreas = new List<EndLevelArea>();

	public GameObject forceManager;
    public List<Image> radials;

	public List<MovableObject> StopAllObjects = new List<MovableObject>();

	private float timerCheckObjects = 0f;
	private float timeVariation = 1f;
	private float timeLimit = 3f;

    private bool isAreasChecked;
	private bool levelCompleted;


    private EnemyController[] enemyController;
    private GameController gameController;


	public void Start()
	{
		Time.timeScale = 1f; // secures that in the beggining of the level the time is passing fas as realtime.
        enemyController = FindObjectsOfType<EnemyController>();
        gameController = FindObjectOfType<GameController>();
	}

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
                foreach (var rad in radials)
                {
                    rad.fillAmount = 0f;
                }
                return;
			}

			if (Area.HasAllObjects)
			{
				if (levelCompleted == false)
				{
					timerCheckObjects += timeVariation * Time.deltaTime;
                    foreach (var rad in radials)
                    {
                        rad.fillAmount = timerCheckObjects/timeLimit;
                    }
				}

				if (timerCheckObjects >= timeLimit)
				{
                    // All objects in their respective areas!
                    // Go to next level.

                    // Those commands runs after the objetive is complete.                 
                    if (isAreasChecked == false)
                    {
                        gameController.CheckPerformance();
                        isAreasChecked = true;
                    }

                    // Force all objects (enemies and movable objects) to cease movement after the objective is complete.

                    foreach (var enemy in enemyController)
                    {
                        enemy.canMove = false;
                    }
					
					foreach (MovableObject Item in StopAllObjects)
					{
						Item.CeaseMovement();
					}
				}
			}
		}
	}
}
