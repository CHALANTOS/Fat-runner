using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cerebro : MonoBehaviour
{
    private Vector3 Startingpos = Vector3.zero;
    private Vector2 MovePos;

    [Header("Atributos")]
    public int life;
    public float speed;
    public float Sensitivity;
    public bool isLuta, noLuta;
    public bool escudoAtivo = false;
    private int MaxX = 2;
    private int MaxY = 2;
    private int MinX = -2;
    private int MinY = -2;

    [Header("Imports")]
    public Animator animator;
    public GameObject InLUTA;
    public GameObject OutLUTA;
    public GameObject Player;
    public GameObject RealLife;
    public Ball bal;
    public BarraDeVida Barra;
    [SerializeField]
    public JoyStick botao;
    public PlayerJson playerJ;
    public GameObject escudo;
    
    void Start()
    {
        escudo.SetActive(false);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0f;
            spriteRenderer.color = newColor;
        }

        playerJ = new PlayerJson();
        playerJ.LoadGame();
        isLuta = false;
        InLUTA.SetActive(false);
        RealLife.SetActive(false);
        OutLUTA.SetActive(true);
        SetBrain();

        bal = FindObjectOfType<Ball>(); // Encontrar a instância de Ball
        if (bal == null)
        {
            Debug.LogError("Ball não encontrado! Verifique se o script Ball está anexado a um GameObject.");
        }

        Barra = RealLife.GetComponent<BarraDeVida>();

        animator = GetComponent<Animator>();
    }

    public void SetBrain()
    {
        transform.position = Startingpos;
        MovePos = Startingpos;
    }

    private void FixedUpdate()
    {
        if (isLuta)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 1;
                spriteRenderer.color = newColor;
            }   
            Movimento();
            Luta();
            Vida();
            bal.InLUTA = true;
            Player.SetActive(true);
        }
        else if (noLuta)
        {
            InLUTA.SetActive(false);
            RealLife.SetActive(false);
            OutLUTA.SetActive(true);
            Player.SetActive(false);
            bal.InLUTA = false;
        }
    }

    public void Movimento()
    {
        
        Player.SetActive(true);

        float horizontal = 0;
        float vertical = 0;

        if (playerJ.plataforma == "PC")
        {
            horizontal = Input.GetAxis("Horizontal") * Sensitivity;
            vertical = Input.GetAxis("Vertical") * Sensitivity;
        }
        else if (playerJ.plataforma == "Celular")
        {
            if (botao.andar_cima)
            {
                vertical += speed * Time.deltaTime;        
            }
            if (botao.andar_baixo)
            {
                vertical -= speed * Time.deltaTime;
            }
            if (botao.andar_esquerda)
            {
                horizontal -= speed * Time.deltaTime;
            }
            if (botao.andar_direita)
            {
                horizontal += speed * Time.deltaTime;
            }
        }

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, speed * Time.deltaTime);
    }

    public void Luta()
    {
        InLUTA.SetActive(true);
        RealLife.SetActive(true);
        OutLUTA.SetActive(false);
    }

    public void Vida()
    {
        Barra.SetarVida();
        if (Barra.RealVida <= 0)
        {
            animator.SetBool("morreu",true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            if(escudoAtivo == false)
            {
                Barra.RealVida -= 1;
                Debug.Log("Colidiu com a Ball! Vida restante: " + Barra.RealVida);
            }
            escudo.SetActive(false);
            escudoAtivo = false;
        }
    }

    public void TrocaCena()
    {
        SceneManager.LoadScene("Jogo");
    }
}
