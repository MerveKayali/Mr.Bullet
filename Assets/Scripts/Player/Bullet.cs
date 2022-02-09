using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public AudioClip boxHit, plankHit, groundHit, explodeHit;
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Box")
        {
            SoundManager.instance.PlaySoundFX(boxHit, 1f);
            Destroy(target.gameObject);
        }

        if (target.gameObject.tag == "Ground")
        {
            SoundManager.instance.PlaySoundFX(groundHit, 1f);
            Destroy(target.gameObject);
        }/*
        if (target.gameObject.tag == "Plank")
        {
            SoundManager.instance.PlaySoundFX(plankHit, 1f);
            Destroy(target.gameObject);
        }*/

        if (target.gameObject.tag == "TntBox")
        {
            SoundManager.instance.PlaySoundFX(explodeHit, 1f);
            Destroy(target.gameObject);
        }


    }
}
