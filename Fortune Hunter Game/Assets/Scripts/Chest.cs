using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public BoxCollider2D coll;
    public Animator anim;
    public ParticleSystem chestParticle;
    public ParticleSystem upParticle;
    public ParticleSystem itemParticle;
    public SpriteRenderer itemRender;
    public CircleCollider2D itemCollider;

    public GameObject collected;

    private void Start() {
        


    }

    void OnTriggerEnter2D(Collider2D collider) {
        
        if (collider.gameObject.tag == "Player")
        {

            collected.SetActive(true);

            coll.enabled = false;
            anim.SetTrigger("open");
            chestParticle.Stop();
            itemCollider.enabled = true;
            itemRender.enabled = true;
            upParticle.Play();
            itemParticle.Play();
            
            AudioController.instance.PlayCollectGemSoundEffect();

        }

    }


}
