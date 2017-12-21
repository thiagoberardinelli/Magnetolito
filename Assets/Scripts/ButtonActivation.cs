using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation : MonoBehaviour {

	public enum ButtonList { SoundEffects, Music }; // Emum que contém os botões presentes no jogo.
	public ButtonList AudioType; // Nome da button list que contem o enum.
	private Button button; // O botão a ser referênciado.
	public Sprite buttonOff; // Sprite do botão Off.
	public Sprite buttonOn; // Sprite do botão On.
	private bool active = false;

	public void Start()
	{
		button = this.GetComponent<Button>(); // Digo que o botão em questão é o componente botão do objeto que o script está atrelado.
		button.GetComponent<Image>().sprite = buttonOn; // Por default, os dois botões de áudio começam ativados.
	}

	public void ButtonMusicStatus()
	{

		// Condição que troca os sprites dos botões. Essa ação é comum aos dois botões, dessa forma é chamada sempre pela função. 
		active = !active; 

		if (active == false)
		{
			button.GetComponent<Image>().sprite = buttonOn;
		}
			
		if (active == true)
		{
			button.GetComponent<Image>().sprite = buttonOff;
		}

		// Switch responsável por determinar qual botão está sendo chamado pelo enum. Perceba que cada botão, tem também sua função individual. 
		switch (AudioType) 
		{
			case ButtonList.SoundEffects:
				Debug.Log("SoundEffects");
				break;
			case ButtonList.Music:
				Debug.Log("Music");
				break;
		}
	}
	
}

