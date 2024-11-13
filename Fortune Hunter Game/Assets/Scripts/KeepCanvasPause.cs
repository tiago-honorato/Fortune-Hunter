using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCanvasPause : MonoBehaviour
{

    private static KeepCanvasPause instance;

    public GameObject gamePause;

    private bool isPaused = false;



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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            
            ShowGamePause();

        }
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
}
