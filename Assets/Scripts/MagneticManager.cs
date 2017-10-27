using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticManager : MonoBehaviour
{
	public List<GameObject> AffectedObjects = new List<GameObject>();

	public float MagneticForceIntensity = 1f;
	Vector3? PrevDirection;
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Debug.Log("Mouse position: " + Input.mousePosition);
			Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Camera.main.ScreentoWorld point retona o valor da posição do mouse em relação ao mundo.
			Debug.Log("Direction: " + Direction);

			foreach (GameObject Item in AffectedObjects)
			{
				Vector3 DirectionResultant = Direction - Item.transform.position; // Resultante da posição de onde o mouse na hora do clique menos a posição atual dele (em outras palavras, para onde o círculo 
				if (PrevDirection.HasValue) // Checa se o movimento anterior é diferente de nulo.
				{
					Item.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Freia o movimento antes de começar um novo.
				}

				Item.GetComponent<Rigidbody2D>().AddForce(DirectionResultant * MagneticForceIntensity); // Aplicação da força nos items da lista. A variável MagneticForceIntensy é a constante que influência na "velocidade" de movimentos dos itens.
				PrevDirection = DirectionResultant;
			}
		}

		// Conversar com o Thiagão o objeto ter que seguir o outro depois que o jogador parar de aplicar a força. Um deve simplesmente

		//else
		//{
		//	AffectedObjects[0].transform.position = AffectedObjects[1].transform.position;

		//}
	}
}

