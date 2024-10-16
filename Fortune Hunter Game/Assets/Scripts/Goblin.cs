using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        //anim.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        rig.velocity = new Vector2(speed, rig.velocity.y);
        
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1;
        }

    }

    void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;

            if (height > 0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5);
                //anim.SetTrigger("die");
                Destroy(gameObject, 0.2f);
            }

        }

        



    }
}
