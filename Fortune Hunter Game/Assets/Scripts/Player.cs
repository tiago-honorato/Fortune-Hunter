using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        Jump();
    }

    void Move(){

        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f , 0f);
        }
        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f , 0f);
        }
        if (movement == 0f)
        {
            anim.SetBool("walk", false);
        }

    }

    void Jump(){

        if (Input.GetKeyDown(KeyCode.W)){
            if (!isJumping){
                
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);

            } 
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.layer == 6)
        {

            isJumping = false;
            anim.SetBool("jump", false);
            
        }

        if (collision.gameObject.tag == "Spike")
        {
            anim.SetTrigger("die");
            GameController.instance.ShowGameOver();
            Destroy(gameObject, 0.3f);
        }
        if (collision.gameObject.tag == "Saw")
        {
            anim.SetTrigger("die");
            GameController.instance.ShowGameOver();
            Destroy(gameObject, 0.3f);
        }

    }

        void OnCollisionExit2D(Collision2D collision) {
        
        if (collision.gameObject.layer == 6)
        {

            isJumping = true;
            
        }

    }

}