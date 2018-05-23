using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuController : MonoBehaviour
{

	private Button button;
	private GameObject lockImage;
	private GameObject buttonText;

	private void Awake ()
    {
		button = GetComponent<Button>();
		lockImage = button.transform.GetChild(0).gameObject;
		buttonText = button.transform.GetChild(1).gameObject;
        button.interactable = false;
	}

    public void UnlockLevel()
	{
		button.interactable = true;
		lockImage.SetActive(false);
		buttonText.SetActive(true);
	}
}
