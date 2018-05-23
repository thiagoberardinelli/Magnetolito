using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaivor : MonoBehaviour {


    [HideInInspector]
    public bool isAnimationPlaying;
    public static CharacterBehaivor instance;

    public List<Animator> animations;


    // TO DO: Animation state is not playing when called. See if there is a another way to play a specific animation!

    void Start()
    {
        isAnimationPlaying = false;
        InvokeRepeating("PowerAnimation", 1f, 1f);
    }

    public void PowerEffectCaller()
    {
        StartCoroutine(PowerAnimation());
    }

    // Method that calls the magnet power animation.
    public IEnumerator PowerAnimation()
    {
        print("to aqui");
        foreach (var anim in animations)
        {
            isAnimationPlaying = true;
            anim.Play("MagnetPower");
            yield return new WaitForSeconds(1f);
            isAnimationPlaying = false;
        }
    }
}
