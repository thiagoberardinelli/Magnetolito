using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation : MonoBehaviour {

	public enum ButtonList { SoundEffects, Music }; // Emum que contém os botões presentes no jogo.
	public ButtonList AudioType; // Nome da button list que contem o enum.
	public Button button; // O botão a ser referênciado.
	public Sprite buttonOff; // Sprite do botão Off.
	public Sprite buttonOn; // Sprite do botão On.
	private bool active = false;
	private bool isPaused = false;

	public void OnEnable()
	{
		switch (AudioType)
		{
			case ButtonList.SoundEffects:
				AudioManager.instance.buttonSFX = this;
				AudioManager.instance.VerifySoundPrefs(Sound.SoundType.SFX, false);
				break;
			case ButtonList.Music:
				AudioManager.instance.buttonMusic = this;
				AudioManager.instance.VerifySoundPrefs(Sound.SoundType.Music, false);
				break;
			default:
				break;
		}
	}

	public void ButtonMusicStatus()
	{

		if (active == false)
		{
			button.GetComponent<Image>().sprite = buttonOff;
		}
			
		if (active == true)
		{
			button.GetComponent<Image>().sprite = buttonOn;
		}

		// Condição que troca os sprites dos botões. Essa ação é comum aos dois botões, dessa forma é chamada sempre pela função. 		
		active = !active;

		// Switch responsável por determinar qual botão está sendo chamado pelo enum. Perceba que cada botão, tem também sua função individual. 
		switch (AudioType) 
		{
			case ButtonList.SoundEffects:
				AudioManager.instance.MuteSoundByType(Sound.SoundType.SFX);				
				break;
			case ButtonList.Music:
				AudioManager.instance.MuteSoundByType(Sound.SoundType.Music);			
				break;
		}

	}

	public void changeButtonSprite(bool setOn)
	{
		active = !setOn;

		if (setOn == true)
		{
			button.GetComponent<Image>().sprite = buttonOn;
		}

		if (setOn == false)
		{
			button.GetComponent<Image>().sprite = buttonOff;
		}
	}

	public void PauseOnClick()
	{
		if (isPaused == false)
		{
			Time.timeScale = 0f;
		}

		else if (isPaused == true)
		{
			Time.timeScale = 1f;
		}

		isPaused = !isPaused;
	}

}

