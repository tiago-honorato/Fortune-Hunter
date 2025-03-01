using UnityEngine;

public class BoxKiller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("box"))
        {
            Destroy(other.gameObject); // Destrói a caixa
        }
    }
}
