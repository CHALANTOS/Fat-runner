using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab_Andar : MonoBehaviour
{
    [Header("Atributos")]
    public float velocidade;
    public bool Iniciou;
    public float movimentoHorizontal;
    public float movimentoVertical;
    public AudioClip[] footstepSoundsGrass;
    private float stepTimer = 0f;
    [SerializeField]
    public float stepInterval = 0.5f; 


    [Header("Imports")]
    public SpriteRenderer SR;
    public Animator animator;
    public Rigidbody2D rig;
    public GameObject CutScene;
    public AudioSource audioSource;

    public JoyStick botao;
    public PlayerJson playerJ;
    public CanvasController CanvasController;

    void Start()
    {
        playerJ = new PlayerJson();
        playerJ.LoadGame();
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        StartCoroutine(Comeco());
        Iniciou = false;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        if (Iniciou)
        {
            Movimento();
        }
    }

    void Movimento()
    {
        if(playerJ.plataforma == "PC")
        {
            movimentoHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);

            movimentoVertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * velocidade * movimentoVertical);
        }
        
        if(movimentoHorizontal == 0 && movimentoVertical == 0)
        {
            if(!botao.andar_cima && !botao.andar_baixo && !botao.andar_esquerda && !botao.andar_direita)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                SR.flipX = false;
                animator.SetBool("Baixo", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Cima", false);
                animator.SetBool("Idle", true);
            }
        }
        if(playerJ.plataforma == "Celular")
        {
            if(botao.andar_cima == true)
            {
                transform.Translate(Vector3.up * velocidade * Time.deltaTime);
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Baixo", false);
                animator.SetBool("Cima", true);
                TocarSomDePasso();

                SR.flipX = false;
            }
            
            if(botao.andar_baixo == true)
            {
                transform.Translate(Vector3.down * velocidade * Time.deltaTime);
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Baixo", true);
                animator.SetBool("Cima", false);
                TocarSomDePasso();

                SR.flipX = false;
            }
            
            if(botao.andar_esquerda == true)
            {
                transform.Translate(Vector3.left * velocidade * Time.deltaTime);
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", true);
                animator.SetBool("Baixo", false);
                animator.SetBool("Cima", false);
                TocarSomDePasso();

                SR.flipX = false;
            }
            
            if(botao.andar_direita == true)
            {
                transform.Translate(Vector3.right * velocidade * Time.deltaTime);
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", true);
                animator.SetBool("Baixo", false);
                animator.SetBool("Cima", false);
                TocarSomDePasso();

                SR.flipX = true;
            }
        }
        
        if(playerJ.plataforma == "PC")
        {
            // Cima
            if (movimentoVertical > 0)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Baixo", false);
                animator.SetBool("Cima", true);
                TocarSomDePasso();

                SR.flipX = false;
            }

            //Baixo
            else if (movimentoVertical < 0)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Baixo", true);
                animator.SetBool("Cima", false);
                TocarSomDePasso();

                SR.flipX = false;
            }

            // Esquerda
            else if(movimentoHorizontal < 0)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", true);
                animator.SetBool("Baixo", false);
                animator.SetBool("Cima", false);
                TocarSomDePasso();

                SR.flipX = false;
            }

            // Direita
            else if(movimentoHorizontal > 0)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", true);
                animator.SetBool("Baixo", false);
                animator.SetBool("Cima", false);
                TocarSomDePasso();

                SR.flipX = true;
            }
        }
    }

    void TocarSomDePasso()
    {
        stepTimer += Time.deltaTime;

        if (stepTimer > stepInterval)
        {
            if (footstepSoundsGrass.Length > 0)
            {
                int randomIndex = Random.Range(0, footstepSoundsGrass.Length);
                audioSource.PlayOneShot(footstepSoundsGrass[randomIndex]);
            }
            stepTimer = 0f;
        }
    }

    IEnumerator Comeco()
    {
        yield return new WaitForSeconds(1.5f);
        Iniciou = true;
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("TROCA"))
        {
            playerJ.faseAtual = "labirinto";
            playerJ.SaveGame();
            SceneManager.LoadScene("Jogo");
        }
    }
}