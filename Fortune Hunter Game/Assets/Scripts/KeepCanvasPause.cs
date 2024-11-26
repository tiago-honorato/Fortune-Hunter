using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeepCanvasPause : MonoBehaviour
{

    public static KeepCanvasPause instance;

    public GameObject gamePause;

    private bool isPaused = false;
    private bool timerActive = false;
    public GameObject timer;
    public bool timerRunning = false;
    public TextMeshProUGUI timerText;
    public GameObject timerOptions;
    private float elapsedTime;

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
        
    }

    // Update is called once per frame
    void Update()    
    {

        ShowTimer();

        if (GameController.instance.onSettings)
        {
            timerOptions.SetActive(true);
        } else if(!GameController.instance.onSettings){

            timerOptions.SetActive(false);

        }

        if (!GameController.instance.onMenu)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            
            ShowGamePause();

        }
    }

    public void ShowGamePause(){

        if (isPaused)
        {
            timerText.color = Color.white;
            Time.timeScale = 1;
            isPaused = false;
            gamePause.SetActive(false);

        }else{
            timerText.color = Color.red;
            Time.timeScale = 0;
            isPaused = true;
            gamePause.SetActive(true);

        }

    }

        public void RestartLevel(){

        AudioController.instance.PlayClickSoundEffect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ShowGamePause();

    }

    public void ToggleTimer(){

        ResetTimer();

        if (!timerActive)
        {
            timerText.color = Color.white;
            timer.SetActive(true);
            timerActive=true;
        }else{
            timer.SetActive(false);
            timerActive=false;
        }
    }

    public void ResetTimer(){

        elapsedTime = 0f;
        timerText.text = "00:00";

    }

    public void ShowTimer(){

        if (!timerRunning) return;

        elapsedTime += Time.deltaTime;
        int min = Mathf.FloorToInt(elapsedTime/60);
        int sec = Mathf.FloorToInt(elapsedTime%60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);

    }

    public void pauseTimer(){
        timerText.color = Color.red;
        timerRunning = false;
    }

    public void resumeTimer(){
        timerText.color = Color.white;
        timerRunning = true;
    }

    public void GotoMenuButton(){

        pauseTimer();

        AudioController.instance.PlayClickSoundEffect();
        ScoreManager.instance.totalScore = 0;
        SceneManager.LoadScene("mainMenu");
        ShowGamePause();

    }
}
