using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovementOnCollision : MonoBehaviour
{

	//void OnCollisionEnter2D(Collision2D col)
	//{

	//	Debug.Log("Colidiu");
	//	col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	//	//col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
	//}

	void OnCollisionStay2D(Collision2D col)
	{
		//col.gameObject.GetComponent<AddForce>().enabled = false;
		col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	
	}
}

