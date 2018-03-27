using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuController : MonoBehaviour
{

	private Button button;
	private GameObject lockImage;
	private GameObject buttonText;

	void Start ()
	{
		button = GetComponent<Button>();
		lockImage = GetComponentsInChildren<GameObject>()[0];
		buttonText = GetComponentsInChildren<GameObject>()[1];
	}

	public void UnlockLevel()
	{
		button.interactable = true;
		lockImage.SetActive(false);
		buttonText.SetActive(true);
	}
}
