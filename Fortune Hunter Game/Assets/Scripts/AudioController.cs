using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioSource audioSourceSoundEffects;
    public AudioClip[] backgroundSongs;
    public AudioClip[] SoundEffects;
    public bool isPlaying = true;
    public static AudioController instance;

    public float volumeStep = 0.2f;


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

    public void IncreaseVolume()
    {
        audioSourceMusicaFundo.volume = Mathf.Clamp(audioSourceMusicaFundo.volume + volumeStep, 0f, 1f);
    }

    public void DecreaseVolume()
    {
        audioSourceMusicaFundo.volume = Mathf.Clamp(audioSourceMusicaFundo.volume - volumeStep, 0f, 1f);
    }

    public void PlayjumpSoundEffect(){

        AudioClip jumpSound = SoundEffects[0];
        audioSourceSoundEffects.PlayOneShot(jumpSound);

    }
    public void PlayCollectGemSoundEffect(){

        AudioClip collectGemSound = SoundEffects[1];
        audioSourceSoundEffects.PlayOneShot(collectGemSound);

    }

    public void PlayDeathSoundEffect(){

        AudioClip deathSound = SoundEffects[2];
        audioSourceSoundEffects.PlayOneShot(deathSound);

    }

    public void PlayClickSoundEffect(){

        AudioClip clickSound = SoundEffects[3];
        audioSourceSoundEffects.PlayOneShot(clickSound);

    }

    public void PlayTrampolineSoundEffect(){

        AudioClip trampolineSound = SoundEffects[4];
        audioSourceSoundEffects.PlayOneShot(trampolineSound);

    }

    public void PlayEnemyDeathSoundEffect(){

        AudioClip EnemyDeathSound = SoundEffects[5];
        audioSourceSoundEffects.PlayOneShot(EnemyDeathSound);

    }

    public void PlayOpenDoorEffect(){

        AudioClip openSound = SoundEffects[6];
        audioSourceSoundEffects.PlayOneShot(openSound);

    }

}
