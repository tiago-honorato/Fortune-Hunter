using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioClip[] backgroundSongs;
    private static AudioController instance;

    void Awake()
    {
        // Verificar se já existe uma instância do AudioController na cena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Impede que o objeto seja destruído ao trocar de cena
        }
        else
        {
            Destroy(gameObject); // Se já existe um, destrói o novo para evitar duplicação
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Configura e inicia a reprodução da música de fundo
        if (backgroundSongs.Length > 0)
        {
            AudioClip musicaFundoFase = backgroundSongs[0];
            audioSourceMusicaFundo.clip = musicaFundoFase;
            audioSourceMusicaFundo.Play();
        }
    }
}
