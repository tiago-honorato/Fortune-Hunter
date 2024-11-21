using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public BoxCollider2D coll;

    public Animator anim;

    public ParticleSystem chestParticle;
    public ParticleSystem itemParticle;

    private void Start() {
        


    }

    void OnTriggerEnter2D(Collider2D collider) {
        
        if (collider.gameObject.tag == "Player")
        {


            coll.enabled = false;
            anim.SetTrigger("open");
            chestParticle.Stop();
            itemParticle.Play();

            AudioController.instance.PlayCollectGemSoundEffect();

        }

    }


}
