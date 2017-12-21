using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Função que faz a troca de cenas. A referência é feita pelo nome da Cena.
	public void GoToLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	// Função que fecha o aplicativo
	public void ExitGame()
	{
		Application.Quit();
	}
}
