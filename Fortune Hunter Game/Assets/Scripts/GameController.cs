using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public int totalLevelGems;
    public TextMeshProUGUI scoreText;
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
        UpdateScoreText();
    }

    private void OpenBlocker(){

        if (totalScore == totalLevelGems && !blockerOpened)
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

    public void ShowGameOver(){

        gameOver.SetActive(true);

    }

    public void RestartGame(string lvlName){

        SceneManager.LoadScene(lvlName);

    }

    public void GameQuit(){

        Application.Quit();

    }

}
