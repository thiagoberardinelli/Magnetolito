using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    private bool isMenuButtonsActive;
    private Image buttonImage;
    private Color buttonColor;
    private float colorVariation = 0.25f;

    private float timer = 0f;
    private float timerLimit = 3f;
    private float timerVariation = 1f;
    	
    public List<GameObject> menuContent = new List<GameObject>();
	

	private void Start()
	{
        buttonImage = GetComponent<Image>();
        buttonColor = buttonImage.color;
   	}

    private void Update()
    {
        if (timer < timerLimit)
        {
            timer += timerVariation * Time.deltaTime;
        }

        if (timer >= timerLimit)
        {
            if (buttonColor.a >= 0.5f && isMenuButtonsActive == false)
            {
                buttonColor.a -= colorVariation * Time.deltaTime;
                buttonImage.color = buttonColor;
            }
        }
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

        // Sets back the alpha of the button to its maximum.
        buttonColor.a = 1f;
        buttonImage.color = buttonColor;
	}

	// Function that deactivates the menu slider if its on.
	void MenuDeactivation()
	{
		foreach (GameObject Item in menuContent)
		{
			Item.SetActive(false);
		}
		isMenuButtonsActive = false;

        // Restarts the timer so it can counts 3 seconds before the button fades again.
        timer = 0f;
	}
}
