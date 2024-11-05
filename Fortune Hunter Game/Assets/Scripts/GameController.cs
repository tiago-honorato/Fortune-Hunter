using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public bool onMenu = false;
    public int totalScore;
    public int totalLevelGems;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI lifeText;

    public static GameController instance;
    public GameObject gameOver;
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

    private void OpenBlocker(){

        if (totalScore == totalLevelGems && !blockerOpened && !onMenu)
        {
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

    }

    public void GotoMenuButton(){

        ScoreManager.instance.totalScore = 0;
        SceneManager.LoadScene("mainMenu");

    }

    public void SelectScene(string sceneName){

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
