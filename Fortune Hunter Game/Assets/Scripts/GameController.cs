using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.SocialPlatforms.Impl;

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
    public GameObject CheckedBtn;
    public GameObject UncheckedBtn;
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
        
        if (ScoreManager.instance.infiniteLifeIsOn)
        {
            lifeText.text = "∞";
            
            lifeText.rectTransform.anchoredPosition += new Vector2(0, 20);

        }else
        {
            lifeText.text = ScoreManager.instance.life.ToString();
            
            lifeText.rectTransform.anchoredPosition = new Vector2(lifeText.rectTransform.anchoredPosition.x, 0);

        }
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
        KeepCanvasPause.instance.ResetTimer();

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

            KeepCanvasPause.instance.pauseTimer();

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

    //CHEATS FUNCTIONS

    public void ToggleInfiniteLife(){

        if (ScoreManager.instance.infiniteLifeIsOn == false)
        {
            ScoreManager.instance.infiniteLifeIsOn = true;
            ScoreManager.instance.life = 9999;

            CheckedBtn.SetActive(true);
            UncheckedBtn.SetActive(false);

        }else
        {
            ScoreManager.instance.infiniteLifeIsOn = false;
            ScoreManager.instance.life = 5;
            UncheckedBtn.SetActive(true);
            CheckedBtn.SetActive(false);
        }

    }

    public void ToggleInfiniteJump(){

        //...

    }

}
