using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
	public void ApplyForce(Vector3 Direction, float ForceIntensity)
    {
        Vector3 DirectionResultant = Direction - transform.position;
        DirectionResultant.Normalize(); // So that, no matter where on the screen the player touches, the resulting force will be the same

        GetComponent<Rigidbody2D>().AddForce(DirectionResultant * ForceIntensity);
    }
}
