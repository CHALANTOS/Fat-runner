using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LutaController : MonoBehaviour
{
    [SerializeField]
    public GameObject cerebroObject;
    public FixPosition fix; 
    public Button Lutar;
    public Button Fugir;
    public GameObject botao;
    public bool isButtonsActive;
    public string str;
    public Cerebro cerebro;
    public Ball ballScript;
    public BarraDeVida Barras;
    public GameObject ball;
    public Animator ballAnimator;
    public bool Ataque = true;
    private bool isCoroutineRunning = false;
    public bool comeco;
    public PlayerJson playerJ;
    public GameObject BG;
    public GameObject objetos;


    void Start()
    {


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
        if (!isCoroutineRunning)
        {
            StartCoroutine(MudarAtaque());
        }
    }

    IEnumerator MudarAtaque()
    {
        fix.trocandoPosicao = true;
        isCoroutineRunning = true;
        Ataque = true;
        if (Ataque)
        {
            ballScript.Lado = Random.Range(1, 3);
            Debug.Log(ballScript.Lado);

            Vector3 position = Vector3.zero;

            if (ballAnimator.GetBool("atk1"))
            {
                position = new Vector3(fix.initialX, 4.49f, 0f);
                
            }
            else if (ballAnimator.GetBool("atk2"))
            {
                position = new Vector3(-13.11f,fix.initialY , 0f);
            }
            Instantiate(ball, position, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);

            Ataque = false;
        }
        isCoroutineRunning = false;
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
        SceneManager.LoadScene(str);
        Debug.Log("Fugiu para a cena: " + str);
    }

}
