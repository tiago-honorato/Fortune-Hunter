using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;// Velocidade do jogador.
    public float JumpForce;// Força do pulo do jogador.
    public bool isJumping; // Está pulando ou não.
    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();// Obtém o componente rigidbody do jogador.
        anim = GetComponent<Animator>();// Obtém o componente Animator do jogador.

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();// Chama o método move a cada tick.
        Jump();// Chama o método jump a cada tick.
    }

    // Método para mover o player.
    void Move(){

        float movement = Input.GetAxis("Horizontal");// Obtém a entrada horizontal, -1 pra esquerda, 1 para a direita e 0 parado.

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);// Adiciona o movimento multiplicado pela velocidade e manter o eixo y. 

        // Se o player tiver se movimentando para a direita(movement = 1).
        if (movement > 0f)
        {
            anim.SetBool("walk", true);// Habilita a animação walk.
            transform.eulerAngles = new Vector3(0f, 0f , 0f);// Gira o player para direita se estiver girado em 180 graus.
        }
        // Se o player tiver se movimentando para a esquerda(movement = -1).
        if (movement < 0f)
        {
            anim.SetBool("walk", true);// Habilita a animação walk.
            transform.eulerAngles = new Vector3(0f, 180f , 0f);// Gira o player em 180 graus.
        }
        // Se o player timer parado(movement = 0).
        if (movement == 0f)
        {
            anim.SetBool("walk", false);// Desabilita a animação walk.
        }

    }

    // Método para o player pular.
    void Jump(){

        // Verifica se "W" ou espaço está pressionado.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Jump")){
            if (!isJumping){
                
                // Zera velocidade vertical para evitar força acumulada.
                rig.velocity = new Vector2(rig.velocity.x, 0f);

                // Adiciona o impulso do pulo.
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                // Ativa a animação de pulo do player.
                anim.SetBool("jump", true);
                isJumping = true;

            // Chama o som de pulo a partir do AudioController
            AudioController.instance.PlayjumpSoundEffect();
            
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