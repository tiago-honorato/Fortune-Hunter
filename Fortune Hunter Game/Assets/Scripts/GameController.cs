using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public bool onMenu = false;
    public bool onSettings = false;
    public bool onVolumeSettings = false;
    public bool isDead = false;
    private bool isShowingControlsTutorial = false;
    private bool isShowingStatistics = false;

    public int totalScore;
    public int totalLevelGems;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI lifeText;

    public static GameController instance;
    public GameObject gameOver;
    public GameObject ControlsTutorial;
    public GameObject Statistics;
    public TilemapCollider2D tileCollider;
    public TilemapRenderer tileRender;
    public ParticleSystem exitParticle;
    public GameObject BG_Map;
    public GameObject Map;

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
        verifyGoToMenu();

    }

    private void verifyGoToMenu()
    {

        if (onMenu && Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("MainMenu");

        }


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
            
            //lifeText.rectTransform.anchoredPosition += new Vector2(0, 20);
            lifeText.rectTransform.anchoredPosition = new Vector2(lifeText.rectTransform.anchoredPosition.x, 20);

        }else
        {
            lifeText.text = ScoreManager.instance.life.ToString();
            
            //lifeText.rectTransform.anchoredPosition = new Vector2(lifeText.rectTransform.anchoredPosition.x, 0);
            lifeText.rectTransform.anchoredPosition = new Vector2(lifeText.rectTransform.anchoredPosition.x, 0);
        }
    }

    public void ShowGameOver(){

        UpdateLifeText();
        gameOver.SetActive(true);
        AudioController.instance.PlayDeathSoundEffect();
        isDead = true;

        if (Map != null)
        {
            Map.SetActive(false);
            BG_Map.SetActive(false);
        }
        

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

    public void ToogleMap(){

        AudioController.instance.PlayClickSoundEffect();

        if (Map.activeSelf)
        {
            Map.SetActive(false);
            BG_Map.SetActive(false);
        }else
        {
            if(!isDead){
            Map.SetActive(true);
            BG_Map.SetActive(true);
            }
        }

    }

    public void ToggleControlsTutorial()
    {

        AudioController.instance.PlayClickSoundEffect();

        if (isShowingControlsTutorial)
        {
            ControlsTutorial.SetActive(false);
            isShowingControlsTutorial = false;
        }
        else
        {
            ControlsTutorial.SetActive(true);
            isShowingControlsTutorial = true;

            Statistics.SetActive(false);
            isShowingStatistics = false;
        }
    }
        public void ToggleStatistics()
    {

        AudioController.instance.PlayClickSoundEffect();

        if (isShowingStatistics)
        {
            Statistics.SetActive(false);
            isShowingStatistics = false;
        }
        else
        {
            Statistics.SetActive(true);
            isShowingStatistics = true;

            ControlsTutorial.SetActive(false);
            isShowingControlsTutorial = false;
        }
    }

    public void GameQuit(){

        Application.Quit();

    }

    //CHEATS FUNCTIONS

    public void ToggleInfiniteLife(){

        AudioController.instance.PlayClickSoundEffect();

        if (ScoreManager.instance.infiniteLifeIsOn == false)
        {
            ScoreManager.instance.infiniteLifeIsOn = true;
            ScoreManager.instance.life = 9999;

            KeepCanvasPause.instance.LifeCheckedBtn.SetActive(true);
            KeepCanvasPause.instance.LifeUncheckedBtn.SetActive(false);

        }else
        {
            ScoreManager.instance.infiniteLifeIsOn = false;
            ScoreManager.instance.life = 5;
            KeepCanvasPause.instance.LifeUncheckedBtn.SetActive(true);
            KeepCanvasPause.instance.LifeCheckedBtn.SetActive(false);
        }

    }

    public void ToggleInfiniteJump(){

        AudioController.instance.PlayClickSoundEffect();

        if (Player.infiniteJump == false && onSettings)
        {
            Player.infiniteJump = true;

            KeepCanvasPause.instance.JumpCheckedBtn.SetActive(true);
            KeepCanvasPause.instance.JumpUncheckedBtn.SetActive(false);

        }else
        {
            Player.infiniteJump = false;
            KeepCanvasPause.instance.JumpUncheckedBtn.SetActive(true);
            KeepCanvasPause.instance.JumpCheckedBtn.SetActive(false);
        }

    }

}
