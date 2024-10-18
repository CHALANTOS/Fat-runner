using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class luta : MonoBehaviour
{
    public PlayerJson playerJ;
    public GameObject player;
    public TMPro.TextMeshProUGUI fases_sequencia;
    public GameObject textoFases;
    public Animator animTexto;
    
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
                            if (playerJ.faseAtual == "veio" || playerJ.faseAtual == "labirinto" || playerJ.faseAtual == "separador")
                            {
                                Debug.Log("Missão Iniciada no LABIRINTO!");
                                SceneManager.LoadScene("Lab");
                            }
                            else if(playerJ.faseAtual == "")
                            {
                                textoFases.SetActive(true);
                                animTexto.Play("Texto_fases",-1,0f);
                                fases_sequencia.text = "Converse com o Walter antes de iniciar a fase";
                            }
                            break;

                        case "Separador":
                            if (playerJ.faseAtual == "labirinto" || playerJ.faseAtual == "separador")
                            {
                                Debug.Log("Missão Iniciada em Separador!");
                                SceneManager.LoadScene("SeparadorDeItens");
                            }
                            else if(playerJ.faseAtual == "veio")
                            {
                                textoFases.SetActive(true);
                                animTexto.Play("Texto_fases",-1,0f);
                                fases_sequencia.text = "Vá no labirinto primeiro (Dados)";
                            }
                            else if(playerJ.faseAtual == "")
                            {
                                textoFases.SetActive(true);
                                animTexto.Play("Texto_fases",-1,0f);
                                fases_sequencia.text = "Converse com o Walter antes de iniciar a fase";
                            }
                            break;

                        case "Lenhador":
                            if (playerJ.faseAtual == "separador")
                            {
                                Debug.Log("Missão Iniciada em Lenhador!");
                                SceneManager.LoadScene("Luta");
                            }
                            else if(playerJ.faseAtual == "labirinto")
                            {
                                textoFases.SetActive(true);
                                animTexto.Play("Texto_fases",-1,0f);
                                fases_sequencia.text = "Separe o lixo primeiro";
                            }
                            else if(playerJ.faseAtual == "veio")
                            {
                                textoFases.SetActive(true);
                                animTexto.Play("Texto_fases",-1,0f);
                                fases_sequencia.text = "Vá no labirinto primeiro (Dados)";
                            }
                            else if(playerJ.faseAtual == "")
                            {
                                textoFases.SetActive(true);
                                animTexto.Play("Texto_fases");
                                fases_sequencia.text = "Converse com o Walter antes de iniciar a fase";
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