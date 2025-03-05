using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private Animator anim;
    public Rigidbody2D playerRb;

    private void Start() {
        
        anim = GetComponent<Animator>();

    }

    public float jumpForce;

    void OnCollisionEnter2D(Collision2D coll) {
        
        if (coll.gameObject.tag == "Player")
        {
            anim.SetTrigger("jump");
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0f);
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            AudioController.instance.PlayTrampolineSoundEffect();
        }

    }
}
