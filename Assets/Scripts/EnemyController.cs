using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

	public enum EnemyList { Static, Horizontal, Vertical };
	public EnemyList EnemyType;
	public GameObject enemy;	

	public bool isAnEnemy = false;
	public float timeUntilRespawn = 0f;
	
	private bool goingUp; // Booleana auxilar para definir o tipo de movimentação vertical.
	private bool goingRight; // Boolena auxilar para definir o tipo de movimentação horizontal.

	[Header("Enemy Vertical Properties")]
	public float topLimit; // Float que determina o ponto máximo que a movimentação do inimigo vertical chega antes de voltar a descer.
	public float bottomLimit; // Float que determina o ponto mímino que a movimentação do inimigo vertical chega antes de voltar a subir.
	public float verticalIncrement; // Incremento do movimento do inimigo vertical.

	[Header("Enemy Horizontal Properties")]
	public float leftLimit; // Float que determina o ponto máximo que a movimentação a esquerda do inimigo horizontal chega antes de voltar para direita.
	public float rightLimit; // Float que determina o ponto máximo a direita que a movimentação do inimigo horizontal chega antes de voltar para esquerda.
	public float horizontalIncrement; // Incremento do movimento do inimigo horizontal.


	void Update () {
		switch (EnemyType)
		{
			case EnemyList.Static:
				// Fazer aqui o que o inimigo estático faz.
				break;

			// Caso o Inimigo seja do tipo horizontal.
			case EnemyList.Horizontal:
				if (goingRight == true)
				{
					if (enemy.gameObject.transform.localPosition.x > rightLimit)
					{
						goingRight = false;
					}
					else
					{
						enemy.gameObject.transform.localPosition = enemy.gameObject.transform.localPosition + new Vector3(horizontalIncrement, 0f, 0f);
					}
				}
				else
				{
					if (enemy.gameObject.transform.localPosition.x < leftLimit)
					{
						goingRight = true;
					}
					else
					{
						enemy.gameObject.transform.localPosition = enemy.gameObject.transform.localPosition + new Vector3(-horizontalIncrement, 0f, 0f);
					}
				}
				break;
			
			// Caso o inimigo seja do tipo vertical.
			case EnemyList.Vertical:
				if (goingUp == true)
				{
					if (enemy.gameObject.transform.localPosition.y > topLimit)
					{
						goingUp = false;
					}
					else
					{
						enemy.gameObject.transform.localPosition = enemy.gameObject.transform.localPosition + new Vector3(0f, verticalIncrement, 0f);
					}
				}
				else
				{
					if (enemy.gameObject.transform.localPosition.y < bottomLimit)
					{
						goingUp = true;
					}
					else
					{
						enemy.gameObject.transform.localPosition = enemy.gameObject.transform.localPosition + new Vector3(0f, -verticalIncrement, 0f);
					}
				}
				break;

			default:
				break;
		}
	}

	// coll = objeto que colide no inimigo.
	// Caso eu queria destruir os objetos, descomentar o método abaixo!

	private IEnumerator OnCollisionEnter2D(Collision2D coll)
	{
		if (isAnEnemy == true && coll.gameObject.tag == "Movable Objects")
		{
			Destroy(coll.gameObject);
			yield return new WaitForSeconds(timeUntilRespawn);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
			
			
	}


}
