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
        if ( Input.GetMouseButtonDown(0) )
        {
            Debug.Log("Mouse position: " + Input.mousePosition);
			Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Camera.main.ScreentoWorld point retona o valor da posição do mouse em relação ao mundo.
			Debug.Log("Direction: " + Direction);

            foreach(GameObject Item in AffectedObjects)
            {
				Vector3 Dir = Direction - Item.transform.position;
				if (PrevDirection.HasValue)
				{
					Item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				}
			
				Item.GetComponent<Rigidbody2D>().AddForce(Dir * MagneticForceIntensity);
				PrevDirection = Dir;


			}
        }
            
                
                
                // se houver o evento touch
            // pegar o x e o y da origem do touch
            // para cada objeto na List
                // adicione uma força
                // intensidade Intensity
                // sentido o x e o y do touch
    }
}
