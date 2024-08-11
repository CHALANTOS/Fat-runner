using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LutaController : MonoBehaviour
{
    [Header("Imports")]
    [SerializeField]
    public GameObject cerebroObject;
    public Button Lutar;
    public Button Fugir;
    public GameObject botao;
    public Cerebro cerebro;
    public Ball ballScript;
    public GameObject ball;
    public BarraDeVida Barras;
    public Animator ballAnimator;
    public GameObject BG;
    public GameObject objetos;
    public GameObject AcoesPlayer;
    public PlayerJson playerJ;
    public AcoesPlayer acoesPlayer;

    [Header("Atributos")]
    public bool isButtonsActive;
    public string str;
    public bool Ataque = true;
    public bool comeco;
    public float round = 0;
    public float roundPassado;


    void Start()
    {
        AcoesPlayer.SetActive(false);

        playerJ = new PlayerJson();
        playerJ.LoadGame();

        if(playerJ.plataforma == "PC")
        {
            isButtonsActive = false;
            botao.SetActive(false);
        }
        else
        {
            isButtonsActive = true;
            botao.SetActive(true);
        }

        cerebro = FindObjectOfType<Cerebro>();
        if (cerebro == null)
        {
            Debug.LogError("Cerebro não encontrado! Verifique se o script Cerebro está anexado a um GameObject.");
        }

        ballScript = FindObjectOfType<Ball>(); // Encontrar a instância de Ball
        if (ballScript == null)
        {
            Debug.LogError("Ball não encontrado! Verifique se o script Ball está anexado a um GameObject.");
        }

        Lutar.onClick.AddListener(OnLutarClicked);
        Fugir.onClick.AddListener(OnFugirClicked);
    }

    void Update()
    {
        if(comeco == true)
        {
            Instantiate(cerebro, new Vector3(0, 0, 0), Quaternion.identity);
            comeco=false;
        }
        
        if(round < 1)
        {
            AcoesPlayer.SetActive(false);
        }
    }

    void OnLutarClicked()
    {
        if (cerebro != null)
        {
            cerebro.isLuta = true;
            Debug.Log("Luta iniciada");
        }
        if (ballScript != null)
        {
            ballScript.InLUTA = true;
            Debug.Log("Ball nasceu");
        }
    }

    void OnFugirClicked()
    {
        TrocarCena();
    }

    public void TrocarCena()
    {
        SceneManager.LoadScene(str);
        Debug.Log("Fugiu para a cena: " + str);
    }

    public void PodeAtacar()
    {
        if(round == 1)
        {
            AcoesPlayer.SetActive(true);
        }
    }
}

