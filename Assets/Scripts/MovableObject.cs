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
            Vector3 DirectionResultant = Direction - transform.position;
            Debug.DrawLine(transform.position, Direction, Color.blue);
            Debug.DrawLine(transform.position, Direction * ForceIntensity, Color.red);
            Debug.DrawLine(transform.position, DirectionResultant, Color.green);

            DirectionResultant.Normalize(); // So that, no matter where on the screen the player touches, the resulting force will be the same
            Debug.DrawLine(transform.position, DirectionResultant, Color.yellow);

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
