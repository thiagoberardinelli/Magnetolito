using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation : MonoBehaviour {

	private Button button;
	public Sprite buttonOff;
	public Sprite buttonOn;
	private bool active = false;

	public void Start()
	{
		button = this.GetComponent<Button>();
		button.GetComponent<Image>().sprite = buttonOn;
	}

	public void ButtonStatus()
	{
		active = !active;

		if (active == false)
		{
			button.GetComponent<Image>().sprite = buttonOn;
		}

		if (active == true)
		{
			button.GetComponent<Image>().sprite = buttonOff;
		}
	}
}
