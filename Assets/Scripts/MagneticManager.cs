using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticManager : MonoBehaviour
{
	public List<GameObject> AffectedObjects = new List<GameObject>();

	public float MagneticForceIntensity = 1f;

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Camera.main.ScreentoWorld point retona o valor da posição do mouse em relação ao mundo.

			foreach (GameObject Item in AffectedObjects)
			{
				Vector3 DirectionResultant = Direction - Item.transform.position; // Resultante da posição de onde o mouse na hora do clique menos a posição atual dele (em outras palavras, para onde o círculo
                DirectionResultant.Normalize(); // So that, no matter where on the screen the player touches, the resulting force will be the same

				Item.GetComponent<Rigidbody2D>().AddForce(DirectionResultant * MagneticForceIntensity); // Aplicação da força nos items da lista. A variável MagneticForceIntensy é a constante que influência na "velocidade" de movimentos dos itens.
			}
		}
	}
}

