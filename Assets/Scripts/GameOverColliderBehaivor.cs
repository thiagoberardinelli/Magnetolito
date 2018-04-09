using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverColliderBehaivor : MonoBehaviour
{

	private EdgeCollider2D gameOverCollider;

	public float extraHorinzotal;
	public float extraVertical;
	private float timeUntilRespawn = 2; // float that controls the respawn timer after the player "death".

	// Each vector represents a especific edge of the collider.
	private Vector2 lowerLeftPoint;
	private Vector2 upperLeftPoint;
	private Vector2 lowerRightPoint;
	private Vector2 upperRightPoint;

	void Start()
	{
		// This gameObject EdgeCollider
		gameOverCollider = GetComponent<EdgeCollider2D>();
		// Main Camera instance.
		Camera camera = Camera.main;

		lowerLeftPoint = camera.ScreenToWorldPoint(new Vector3(-extraHorinzotal, -extraVertical, 0));
		upperLeftPoint = camera.ScreenToWorldPoint(new Vector3(-extraHorinzotal, Screen.height + extraVertical, 0f));
		upperRightPoint = camera.ScreenToWorldPoint(new Vector3(Screen.width + extraHorinzotal, Screen.height + extraVertical, 0f));
		lowerRightPoint = camera.ScreenToWorldPoint(new Vector3(Screen.width + extraHorinzotal, -extraVertical, 0f));

		gameOverCollider.points = new Vector2[5] { lowerLeftPoint, upperLeftPoint, upperRightPoint, lowerRightPoint, lowerLeftPoint };
	}

	private IEnumerator OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Movable Objects")
		{
			Destroy(collision.gameObject);
			yield return new WaitForSeconds(timeUntilRespawn);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
