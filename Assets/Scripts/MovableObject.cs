using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public bool CanMove = true;

    public void ApplyForce(Vector3 Direction, float ForceIntensity)
    {
        if (CanMove)
        {
            Debug.DrawLine(transform.position, Direction, Color.blue);

            Vector3 DirectionResultant = Direction - transform.position;
            DirectionResultant.Normalize(); // So that, no matter where on the screen the player touches, the resulting force will be the same

            GetComponent<Rigidbody2D>().AddForce(DirectionResultant * ForceIntensity);
        }
    }

    public void CeaseMovement()
    {
        CanMove = false;
    }

    public void ResumeMovement()
    {
        CanMove = true;
    }
}
