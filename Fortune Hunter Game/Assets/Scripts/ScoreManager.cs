using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton para acesso global
    public int totalScore;

    public int life = 5;

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

    public void AddLife(int amount){

        life += amount;

    }

}