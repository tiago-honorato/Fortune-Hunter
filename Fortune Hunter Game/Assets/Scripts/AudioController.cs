using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioClip[] backgroundSongs;
    private bool isPlaying = true;
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

        if (backgroundSongs.Length > 0)
        {
            AudioClip musicaFundoFase = backgroundSongs[0];
            audioSourceMusicaFundo.clip = musicaFundoFase;
            audioSourceMusicaFundo.Play();
        }
    }
        public void ToggleMusic()
    {
        if (isPlaying)
        {
            audioSourceMusicaFundo.Pause();
            isPlaying = false;
        }
        else
        {
            audioSourceMusicaFundo.Play();
            isPlaying = true;
        }
    }

}
