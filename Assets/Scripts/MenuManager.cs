using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	private int maxReachedLevel;
	public List<ButtonMenuController> homeButtons = new List<ButtonMenuController>();
	

	void Start () {
		maxReachedLevel = PlayerPrefs.GetInt("maxReachedLevel");
		for (int i = 0; i < maxReachedLevel; i++)
		{
			homeButtons[i].UnlockLevel();
		}
	}
}
