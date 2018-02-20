using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticManager : MonoBehaviour
{
	public List<MovableObject> AffectedObjects = new List<MovableObject>();

	public float MagneticForceIntensity = 1f;

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Camera.main.ScreentoWorld point retona o valor da posição do mouse em relação ao mundo.

			foreach (MovableObject Item in AffectedObjects)
			{
                Item.ApplyForce(Direction, MagneticForceIntensity);
			}
		}
	}
}

