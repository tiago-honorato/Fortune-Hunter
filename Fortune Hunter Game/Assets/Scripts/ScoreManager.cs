using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton para acesso global
    public int totalScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantém entre cenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicações
        }
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        
    }

}

/*
GameController:
atualiza o txt do score(método)

Diamond:
adicionar Score ao totalScore na instancia ScoreManager

Chama instancia do GameController pra atualizar o txt

ScoreManager

Tem o totalScore e é DontDestroyOnLoad


:::::::DEPOIS::::::::

totalScore do gameController usar como LOCAL.
totalScore do ScoreManager usar como NUVEM.

A cada inicio de cena GameController pega totalScore de NUVEM.


*/