using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaivor : MonoBehaviour {
    
    private Animator charAnimator;

    void Start()
    {
        charAnimator = GetComponent<Animator>();
    }

    public void PlayMagnetAnimation()
    {
        charAnimator.SetTrigger("PowerOn");
    }
}
