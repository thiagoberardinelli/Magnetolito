using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	private int maxReachedLevel;
	
	public List<ButtonMenuController> homeButtons = new List<ButtonMenuController>();

	void Awake()
	{
		if (!PlayerPrefs.HasKey("firstTimeEnters"))
		{
			PlayerPrefs.SetInt("maxReachedLevel", 1);
			PlayerPrefs.SetInt("firstTimeEnters", 0);
		}
	}


	void Start ()
    {
        ProgressChecker();
	}

	// Public method that resets the PlayerPrefs Maximum Reached Level to default for tests purposes. Should be removed later.
	public void RestartPlayerPrefs()
	{
		PlayerPrefs.SetInt("maxReachedLevel", 1);
	}

    // Unlocks all levels for test purporses. Should be removed later.
    public void UnlockAllLevels()
    {
        PlayerPrefs.SetInt("maxReachedLevel", 10);
        ProgressChecker();
    }

    private void ProgressChecker()
    {
        maxReachedLevel = PlayerPrefs.GetInt("maxReachedLevel");
        for (int i = 0; i < maxReachedLevel; i++)
        {
            homeButtons[i].UnlockLevel();
        }
    }
}
