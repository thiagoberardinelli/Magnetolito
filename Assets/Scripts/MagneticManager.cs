﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MagneticManager : MonoBehaviour
{
	public List<MovableObject> AffectedObjects = new List<MovableObject>();
    public CharacterBehaivor mainChar;

	public float MagneticForceIntensity = 1f;

	private void FixedUpdate()
	{
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
		{
            if (! IsInsideMagnetismNullifyingArea())
            {
                MoveMoveableObjects();
                mainChar.PlayMagnetAnimation();
			}
		}
	}

    private bool IsInsideMagnetismNullifyingArea()
    {
        Ray Raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D Hit = Physics2D.Raycast(Raycast.origin, Raycast.direction, Mathf.Infinity);
        if (Hit.collider != null)
        {
            MagnetismNullifierArea Area = Hit.collider.gameObject.GetComponent<MagnetismNullifierArea>();
            if (Area != null)
            {
                return true;
            }
        }

        return false;
    }

    private void MoveMoveableObjects()
    {
        Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Camera.main.ScreentoWorld point retona o valor da posição do mouse em relação ao mundo.

        foreach (MovableObject Item in AffectedObjects)
        {
            Item.ApplyForce(Direction, MagneticForceIntensity);
        }
    }
}

