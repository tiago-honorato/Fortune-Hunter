using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private Animator anim;

    private void Start() {
        
        anim = GetComponent<Animator>();

    }

    public float jumpForce;

    void OnCollisionEnter2D(Collision2D coll) {
        
        if (coll.gameObject.tag == "Player")
        {
            anim.SetTrigger("jump");
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
}
