using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    public Animator PlayerAnim;
    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

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

    bool playerDestroyed = false;
    void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;

            if (height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;

                AudioController.instance.PlayEnemyDeathSoundEffect();

                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }else{

                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                PlayerAnim.SetTrigger("die");
                anim.SetTrigger("idle");
                speed = 0;
                Destroy(col.gameObject, 0.3f);
            }

        }

        



    }
}
