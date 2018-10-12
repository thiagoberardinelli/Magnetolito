using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelFuncionalities : MonoBehaviour {

    private LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    public void ReturnToMainMenu()
    {
        levelController.StartLevel("_LevelMenu");
    }

    public void RestartLevel()
    {
        levelController.RestartLevel();
    }

    public void LoadNextLevel()
    {
        levelController.LoadNextLevel();
    }
}
