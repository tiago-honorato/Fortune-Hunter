using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioSource audioSourceSoundEffects;
    public AudioClip[] backgroundSongs;
    public AudioClip[] SoundEffects;
    private bool isPlaying = true;
    public static AudioController instance;


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

    public void PlayjumpSoundEffect(){

        AudioClip jumpSound = SoundEffects[0];
        audioSourceSoundEffects.PlayOneShot(jumpSound);

    }
    public void PlayCollectGemSoundEffect(){

        AudioClip collectGemSound = SoundEffects[1];
        audioSourceSoundEffects.PlayOneShot(collectGemSound);

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
