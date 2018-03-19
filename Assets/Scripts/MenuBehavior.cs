using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{

	private GameObject menuButton;
	public List<GameObject> menuContent = new List<GameObject>();
	private bool isMenuButtonsActive;

	void Start()
	{
		menuButton = GetComponent<GameObject>();
	}

	// Function that checks the currently state of the button slider. Must be public because it's called in the inspector. 
	public void MenuSlider()
	{
		if (isMenuButtonsActive == false)
		{
			MenuActivation();
		}

		else if (isMenuButtonsActive == true)
		{
			MenuDeactivation();
		}
	}

	// Function that activates the menu slider if its off.
	void MenuActivation()
	{
		foreach (GameObject Item in menuContent)
		{
			Item.SetActive(true);
		}
		isMenuButtonsActive = true;
	}

	// Function that deactivates the menu slider if its on.
	void MenuDeactivation()
	{
		foreach (GameObject Item in menuContent)
		{
			Item.SetActive(false);
		}
		isMenuButtonsActive = false;
	}
}
