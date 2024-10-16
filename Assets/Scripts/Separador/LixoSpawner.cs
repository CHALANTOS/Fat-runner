using System.Collections;
using UnityEngine;

public class LixoSpawner : MonoBehaviour
{
    public GameObject[] lixos;
    public RectTransform canvas;
    public float spawnY = 6f;
    public float minSpawnX = -429f;
    public float maxSpawnX = 898f;
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 5f;
    private bool isSpawning = false;
    public bool inJogo;

    void Update()
    {
        if(inJogo == true)
        {
            StartCoroutine(SpawnLixo());
        }
    }

    IEnumerator SpawnLixo()
    {
            if (!isSpawning)
            {
                isSpawning = true;

                float spawnX = Random.Range(minSpawnX, maxSpawnX);
                Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

                Vector2 canvasPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Camera.main.WorldToScreenPoint(spawnPosition), Camera.main, out canvasPosition);

                GameObject lixo = Instantiate(lixos[Random.Range(0, lixos.Length)], canvasPosition, Quaternion.identity, canvas);

                float velocidadeAleatoria = Random.Range(2f, 6f);
                lixo.GetComponent<Lixo>().SetVelocidade(velocidadeAleatoria);

                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

                isSpawning = false;
            }
    }
}