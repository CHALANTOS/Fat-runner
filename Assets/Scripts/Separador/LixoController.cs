using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] SpawnItens;
    int randomIndex;
    float randomPosition;
    public float tempoSpawn;
    public float spawnDelay;
    public bool dropou;
    public float pontos;

    void Start()
    {
        //InvokeRepeating("SpawnRandom", tempoSpawn, spawnDelay);
    }

    // void SpawnRandom()
    // {
    //     randomIndex = Random.Range(0, SpawnItens.Length);
    //     float randomX = Random.Range(-4.0f, 7.47f);
    //     float yPosition = 7.13f;
    //     GameObject objetoInstanciado = Instantiate(SpawnItens[randomIndex], canvas.transform);
    //     RectTransform rectTransform = objetoInstanciado.GetComponent<RectTransform>();
    //     rectTransform.anchoredPosition = new Vector2(randomX, yPosition);
    // }

    void Reciclou()
    {

    }
}
