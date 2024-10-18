using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class luta : MonoBehaviour
{
    public PlayerJson playerJ;
    public GameObject player;
    // public string str;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Encontra um único objeto com a tag "Player"
        if (player == null)
        {
            Debug.LogError("Player não encontrado!");
        }
    }

    private void Update()
    {
        playerJ = new PlayerJson();
        playerJ.LoadGame();
        if (player != null && Vector2.Distance(player.transform.position, transform.position) < 2)
        {
            if (player != null && Vector2.Distance(player.transform.position, transform.position) < 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (gameObject.name)
                    {
                        case "LABIRINTO":
                            if (playerJ.faseAtual == "veio")
                            {
                                Debug.Log("Missão Iniciada no LABIRINTO!");
                                SceneManager.LoadScene("Lab");
                            }
                            break;

                        case "Separador":
                            if (playerJ.faseAtual == "labirinto")
                            {
                                Debug.Log("Missão Iniciada em Separador!");
                                SceneManager.LoadScene("SeparadorDeItens");
                            }
                            break;

                        case "Lenhador":
                            if (playerJ.faseAtual == "separador")
                            {
                                Debug.Log("Missão Iniciada em Lenhador!");
                                SceneManager.LoadScene("Luta");
                            }
                            break;

                        default:
                            Debug.Log("Nenhuma missão iniciada.");
                            break;
                    }
                }
            }
        }
    }
}
// if (Input.GetKeyDown(KeyCode.E))
// {
//     Debug.Log("Missão Iniciada!");
//     SceneManager.LoadScene(str);
// }