using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private UILevel levelUI;
    //[SerializeField] private GameObject levelPopUp;

    private Transform levelSelectPanel;
    private int currentPage;
    private float pageNumber;
    private List<UILevel> levelList = new List<UILevel>(); // Lista de todos os botoes que representam os levels

    void Start()
    {
        levelSelectPanel = transform;

        for (int i = 0; i < levelController.levels.Count; i++) // Para cada Level que eu tenho eu vou adicionar um levelUI (UILevel script) na levelList.
        {
            levelList.Add(levelUI);
        }
        BuildLevelPage(0); // Primeira pagina deve aparecer quando o jogo acontece.
    }

    void BuildLevelPage(int page) // Metodo que instancia os elementos de acordo com a pagina correspondente
    {
        RemoveItensFromPage();
        currentPage = page;
        int pageSize = 10; // Quantidade de levels por pagina.
        pageNumber = Mathf.Round(levelList.Count / pageSize);

        // Pula o numero correspondente de elementos de acordo com a pagina e conta os 10 proximos (pageSize)
        List<UILevel> pageList = levelList.Skip(page * pageSize).Take(pageSize).ToList();

        for (int i = 0; i < pageList.Count; i++)
        {
            Level level = levelController.levels[(page * pageSize) + i]; // para cada i eu estou criando um Level correspondente.
            UILevel instance = Instantiate(pageList[i]);

            
            instance.SetStars(level.Stars);
            instance.transform.SetParent(levelSelectPanel);
            instance.GetComponent<RectTransform>().localScale = Vector3.one;
            instance.GetComponent<Button>().onClick.AddListener(() => SelectLevel(level));

            if (!level.Locked) // Se nao esta bloqueado.
            {
                instance.lockImage.SetActive(false);
                instance.levelTextID.text = level.ID.ToString();
            }
            else
            {
                instance.lockImage.SetActive(true);
                instance.levelTextID.text = "";
            }
        }
    }

    void RemoveItensFromPage() // Metodo que destroi a pagina anterior.
    {
        for (int i = 0; i < levelSelectPanel.childCount; i++)
        {
            Destroy(levelSelectPanel.GetChild(i).gameObject); 
        }
    }

    public void NextPage()
    {
        if (currentPage < pageNumber)
        {
            BuildLevelPage(currentPage + 1);
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            BuildLevelPage(currentPage - 1);
        }
    }

    void SelectLevel(Level level) // Metodo que checa se o level ta trancado ou nao no clique. Se sim, ele abre o popup e se nao, ele loada o level clicado.
    {
        if (level.Locked)
        {
            Debug.Log("Level is locked!");
        }

        else
        {
            levelController.StartLevel(level.LevelName);
        }
    }
}
