using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagneticManager : MonoBehaviour
{
	public List<MovableObject> AffectedObjects = new List<MovableObject>();

	public float MagneticForceIntensity = 1f;

	private void Update()
	{
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Camera.main.ScreentoWorld point retona o valor da posição do mouse em relação ao mundo.

			foreach (MovableObject Item in AffectedObjects)
			{
                Item.ApplyForce(Direction, MagneticForceIntensity);
			}
		}
	}
}

