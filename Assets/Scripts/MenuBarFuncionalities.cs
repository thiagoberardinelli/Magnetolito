﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBarFuncionalities : MonoBehaviour 
{
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

    public void ExitGame()
    {
        levelController.ExitGame();
    }

    public void LoadNextLevel()
    {
        levelController.LoadNextLevel();
    }
}
