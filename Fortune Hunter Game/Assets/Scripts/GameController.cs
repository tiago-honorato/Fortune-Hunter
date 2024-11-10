using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public bool onMenu = false;

    private bool isPaused = false;

    public int totalScore;
    public int totalLevelGems;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI lifeText;

    public static GameController instance;
    public GameObject gameOver;
    public GameObject gamePause;
    public TilemapCollider2D tileCollider;
    public TilemapRenderer tileRender;
    public ParticleSystem exitParticle;

    private bool blockerOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (!onMenu){
            UpdateScoreText();
            UpdateLifeText();
        } 
        

    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !onMenu)
        {
            
            ShowGamePause();

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

    }

    public void ShowGamePause(){

        if (isPaused)
        {

            Time.timeScale = 1;
            isPaused = false;
            gamePause.SetActive(false);
        }else{

            Time.timeScale = 0;
            isPaused = true;
            gamePause.SetActive(true);

        }

    }

    public void GotoMenuButton(){

        AudioController.instance.PlayClickSoundEffect();
        ScoreManager.instance.totalScore = 0;
        SceneManager.LoadScene("mainMenu");

    }

    public void SelectScene(string sceneName){

        AudioController.instance.PlayClickSoundEffect();

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.totalScore = 0;
        }
        SceneManager.LoadScene(sceneName);

    }

    public void RestartGame(string lvlName){

        ScoreManager.instance.life--;

        if (ScoreManager.instance.life <= 0)
        {
            SceneManager.LoadScene("mainMenu");
            ScoreManager.instance.life = 5;
        }else
        {
            SceneManager.LoadScene(lvlName);   
        }

    }

    public void GameQuit(){

        Application.Quit();

    }

}
