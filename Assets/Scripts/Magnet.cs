using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float MagnetStrength = .75f;

    private Vector3 ThisMagnetPosition;

    private List<MovableObject> MovableList = new List<MovableObject>();

    private void Awake()
    {
        // This assumes this Magnet is of a fixed position. This will NOT work
        // if this Magnet moves! Beware!
        ThisMagnetPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovableObject Movable = collision.gameObject.GetComponent<MovableObject>();
        if (Movable != null)
        {
            MovableList.Add(Movable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovableObject Movable = collision.gameObject.GetComponent<MovableObject>();
        if (Movable != null)
        {
            MovableList.Remove(Movable);
        }
    }

    private void FixedUpdate()
    {
        Vector3 Direction = ThisMagnetPosition;

        foreach (MovableObject Movable in MovableList)
        {
            Movable.ApplyForce(Direction, MagnetStrength);
        }
    }
}
