using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EndLevelArea : MonoBehaviour
{
	public CheckLevelEndAreas checkLevelEndAreas;

	public List<EndLevelObject> RequiredTriggerObjects = new List<EndLevelObject>();

    public bool HasAllObjects
    {
        get
        {
            foreach (EndLevelObject LevelObject in RequiredTriggerObjects)
            {
                if (! LevelObject.InsideArea)
                {
                    return false;
                }
            }
            return true;
        }
    }

    private void Awake()
    {
        if (checkLevelEndAreas != null)
        {
            checkLevelEndAreas.RegisterEndGameArea(this);
        }
        else
        {
            throw new System.Exception("No LevelManager present in a EndLevelArea component.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovableObject OtherMovable = collision.gameObject.GetComponent<MovableObject>();
        if (OtherMovable != null)
        {
            foreach (EndLevelObject LevelObject in RequiredTriggerObjects)
            {
                if (LevelObject.Movable.Equals(OtherMovable))
                {
                    LevelObject.InsideArea = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovableObject OtherMovable = collision.gameObject.GetComponent<MovableObject>();
        if (OtherMovable != null)
        {
            foreach (EndLevelObject LevelObject in RequiredTriggerObjects)
            {
                if (LevelObject.Movable.Equals(OtherMovable))
                {
                    LevelObject.InsideArea = false;
                }
            }
        }
    }

}

[System.Serializable]
public class EndLevelObject
{
    public MovableObject Movable;
    [HideInInspector] public bool InsideArea;
}

