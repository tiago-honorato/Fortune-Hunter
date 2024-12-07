using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public ParticleSystem upParticle;
    public ParticleSystem itemParticle;


    public GameObject collected;
    public int Score;


    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collider) {
        
        if (collider.gameObject.tag == "Player")
        {
            
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            upParticle.Stop();
            itemParticle.Stop();


            AudioController.instance.PlayCollectGemSoundEffect();

            ScoreManager.instance.AddLife(1);
            GameController.instance.UpdateLifeText();

            Destroy(gameObject, 0.25f);

        }

    }

}
