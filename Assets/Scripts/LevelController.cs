using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    public List<Level> levels;    

    private void Awake()
    {
        if (FindObjectsOfType<LevelController>().Length > 1)
        {            
            Destroy(gameObject);
        }   

        DontDestroyOnLoad(gameObject);

        // Listar aqui todos os levels.
        levels = new List<Level>
        {
            new Level(0, "Level00", false, 0, false),
            new Level(1, "Level01", false, 0, false),
            new Level(2, "Level02", false, 0, false),
            new Level(3, "Level03", false, 0, false),
            new Level(4, "Level04", false, 0, false),
            new Level(5, "Level05", false, 0, false),
            new Level(6, "Level06", false, 0, false),
            new Level(7, "Level07", false, 0, false),
            new Level(8, "Level08", false, 0, false),
            new Level(9, "Level09", false, 0, false),
            new Level(10, "Leve10", false, 0, false),
            new Level(11, "Leve11", false, 0, false),
            new Level(12, "Leve12", false, 0, false),
            new Level(12, "Leve13", false, 0, false)
        };

        print(levels[0].Stars);
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CompleteLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Complete(); // Procura na lista de Levels o level correspondente e muda seu status para completo.
    }

    public void CompleteLevel(string levelName, int stars)
    {        
        levels.Find(i => i.LevelName == levelName).Complete(stars); // Igual o de cima mas tambem colocar o numero de estrelas obtidas no final do level.
    }

    public void LockLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Lock();
    }

    public void UnlockLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Unlock();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
 }
