using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGrid : MonoBehaviour
{
	private float origin;
	private float firstOrigin;
	private float targetOrigin;
	private float width;	

	private bool snapping = false;

	private int currentGrid = 1;

	[Header("Grid Movement Attributes")]
	public float speed; // Mede a velocidade do lerp/smooth entre grids
	public float reachThreshold = 0.5f;

	[Header("Buttons")]
	public Button nextGridButton;
	public Button previousGridButton;

	// Use this for initialization
	void Start ()
	{
		origin = transform.position.x;
		firstOrigin = origin; // para guardar o valor da origem "original" que é transform.position = 0;
		width = Screen.width;

		previousGridButton.interactable = false; // Como começa na primeira página, você deve desativar o botão de grid anterior.	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// rever isso aqui, porque me parece muito custoso!
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			Vector3 childNewPosition = child.position;
			childNewPosition.x = origin + width * i;
			child.position = childNewPosition;
		}

		if (snapping)
		{
			origin = Mathf.SmoothStep(origin, targetOrigin, Time.deltaTime * speed); // saio da origem atual para a proxima (esquerda ou direita, dependendo do botão clicado).
			if (Mathf.Abs(origin - targetOrigin) < reachThreshold) // limite que para de fazer o movimento de lerp.
			{
				origin = targetOrigin;
				snapping = false; // acabou o movimento de transição 
			}
		}
	}

	public void MoveGrid()
	{
		targetOrigin = firstOrigin - width * (currentGrid - 1);
		snapping = true; // começar o movimento de "slide.
	}

	public void MoveToNextGrid()
	{
		if (currentGrid < transform.childCount)
		{
			currentGrid++;
			MoveGrid();
		}

		if (currentGrid >= transform.childCount)
		{
			nextGridButton.interactable = false;
		}

		if (currentGrid <= transform.childCount)
		{
			previousGridButton.interactable = true;
		}
	}

	public void MoveToPreviousGrid()
	{
		if (currentGrid > 1)
		{
			currentGrid--;
			MoveGrid();
		}

		if (currentGrid == 1)
		{
			previousGridButton.interactable = false;
		}

		if (currentGrid < transform.childCount)
		{
			nextGridButton.interactable = true;
		}
	}
}
