using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public bool onMenu = false;
    public bool onSettings = false;
    public bool isDead = false;
    private bool isShowingControlsTutorial = false;

    public int totalScore;
    public int totalLevelGems;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI lifeText;

    public static GameController instance;
    public GameObject gameOver;
    public GameObject ControlsTutorial;
    public TilemapCollider2D tileCollider;
    public TilemapRenderer tileRender;
    public ParticleSystem exitParticle;

    private bool blockerOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isDead = false;

        if (!onMenu){
            UpdateScoreText();
            UpdateLifeText();
        }        

    }

    private void Update() {

        verifyIsDead();

    }

    private void verifyIsDead(){
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                RestartGame();
            }
        }
    }

    private void OpenBlocker(){

        if (totalScore == totalLevelGems && !blockerOpened && !onMenu)
        {
            AudioController.instance.PlayOpenDoorEffect();
            tileCollider.enabled = false;
            tileRender.enabled = false;
            exitParticle.Play();
        }

    }

    public void UpdateScoreText(){

        scoreText.text = (totalScore + ScoreManager.instance.totalScore).ToString();

        OpenBlocker();
    }

    public void UpdateLifeText(){
        lifeText.text = ScoreManager.instance.life.ToString();
    }

    public void ShowGameOver(){

        UpdateLifeText();
        gameOver.SetActive(true);
        AudioController.instance.PlayDeathSoundEffect();
        isDead = true;

    }

    public void GotoMenuButton(){

        KeepCanvasPause.instance.pauseTimer();

        AudioController.instance.PlayClickSoundEffect();
        ScoreManager.instance.totalScore = 0;
        SceneManager.LoadScene("mainMenu");

    }

    public void StartGame(){

        KeepCanvasPause.instance.resumeTimer();

        AudioController.instance.PlayClickSoundEffect();

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.totalScore = 0;
        }
        SceneManager.LoadScene("nivel_1");

    }

    public void SelectScene(string sceneName){

        AudioController.instance.PlayClickSoundEffect();

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.totalScore = 0;
        }
        SceneManager.LoadScene(sceneName);

    }

    public void RestartGame(){

        ScoreManager.instance.life--;

        if (ScoreManager.instance.life <= 0)
        {
            SceneManager.LoadScene("mainMenu");
            ScoreManager.instance.life = 5;
        }else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        }

    }

    public void ToggleControlsTutorial()
    {
        if (isShowingControlsTutorial)
        {
            ControlsTutorial.SetActive(false);
            isShowingControlsTutorial = false;
        }
        else
        {
            ControlsTutorial.SetActive(true);
            isShowingControlsTutorial = true;
        }
    }

    public void GameQuit(){

        Application.Quit();

    }

}
