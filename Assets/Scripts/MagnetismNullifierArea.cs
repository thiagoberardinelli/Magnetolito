﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MagnetismNullifierArea : MonoBehaviour
{
	
	private void OnTriggerEnter2D(Collider2D collision)
    {
        MovableObject Movable = collision.gameObject.GetComponent<MovableObject>();
        if (Movable != null)
        {
            Movable.CeaseMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovableObject Movable = collision.gameObject.GetComponent<MovableObject>();
        if (Movable != null)
        {
            Movable.ResumeMovement();
        }
    }
}
