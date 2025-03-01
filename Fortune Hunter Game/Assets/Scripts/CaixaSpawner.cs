using System.Collections;
using UnityEngine;

public class CaixaSpawner : MonoBehaviour
{
    public GameObject caixaPrefab;  // O prefab da caixa
    public float intervalo = 2f;    // Tempo entre spawn
    public float minX = -5f;        // Posição mínima no eixo X
    public float maxX = 5f;         // Posição máxima no eixo X

    void Start()
    {
        StartCoroutine(SpawnCaixas());
    }

    IEnumerator SpawnCaixas()
    {
        while (true)
        {
            float posX = Random.Range(minX, maxX); // Posição X aleatória
            Vector2 spawnPos = new Vector2(posX, transform.position.y);

            Instantiate(caixaPrefab, spawnPos, Quaternion.identity); // Cria a caixa

            yield return new WaitForSeconds(intervalo); // Espera antes de criar outra
        }
    }
}
