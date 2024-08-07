using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Atributos")]
    public float movimentoHorizontal;
    public float movimentoVertical;
    public float velocidade = 5.0f ;
    public bool podeAndar;
    public bool isInstrucoesActive;
    bool isActive;
    [SerializeField] 
    int vida;

    [Header("Imports")]
    [SerializeField]
    public GameObject inventario;
    public GameObject instrucoes;
    private Inventory inventoryScript;
    public SpriteRenderer SR;
    public Rigidbody2D rig;
    public Animator animator;
    [SerializeField]
    public JoyStick botao;
    public GameController gameController;
    
    void Start()
    {
        Debug.Log("Comecou o jogo");
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        velocidade = 5f;
        podeAndar = true;
        inventoryScript = inventario.GetComponent<Inventory>();

        isInstrucoesActive = true;
        instrucoes.SetActive(true);
    }

    void Update()
    {
        if (podeAndar == true)
        {
            Movimento();
        }

        //InventÃ¡rio
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isInstrucoesActive)
            {
                instrucoes.SetActive(false);
                isInstrucoesActive = false;
            }

            isActive = !inventario.activeSelf;
            inventario.SetActive(isActive);

            podeAndar = !inventario.activeSelf;
        }

        //HUD
        if (Input.GetKeyDown(KeyCode.Z) && podeAndar)
        {
            instrucoes.SetActive(!isInstrucoesActive);
            isInstrucoesActive = !isInstrucoesActive; 
        }
    }

    void Movimento()
    {
        if(!gameController.isCelular)
        {
            movimentoHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
        
            movimentoVertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * velocidade * movimentoVertical);
        }
        if(botao.andar_cima == true)
        {
            Debug.Log("andando_cima");
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);
            animator.SetBool("Cima", true);
            animator.SetBool("Idle", false);
        }
        
        if(botao.andar_baixo == true)
        {
            Debug.Log("andando_baixo");
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Baixo", true);
        }
        
        if(botao.andar_esquerda == true)
        {
            Debug.Log("andando_esquerda");
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
            SR.flipX = true;
            animator.SetBool("Lados", true);
            animator.SetBool("Idle", false);
        }

        if(botao.andar_direita == true)
        {
            Debug.Log("andando_direita");
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
            SR.flipX = false;
            animator.SetBool("Lados", true);
        }
        if(!botao.andar_baixo && movimentoHorizontal == 0 && movimentoVertical == 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Baixo", false);
        }
        if(!botao.andar_esquerda && !botao.andar_direita && movimentoHorizontal == 0 && movimentoVertical == 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Lados", false);
        }
        if(!botao.andar_cima && movimentoHorizontal == 0 && movimentoVertical == 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Cima", false);
            animator.SetBool("Idle", true);
        }
            
        if(!gameController.isCelular)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                SR.flipX = true;
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", true);
                animator.SetBool("Cima", false);
                animator.SetBool("Idle", false);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                SR.flipX = false;
                animator.SetBool("Lados", true);
                animator.SetBool("Cima", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Baixo", false);
            }
            else if (movimentoVertical < 0)
            {
                SR.flipX = false;
                animator.SetBool("Baixo", true);
                animator.SetBool("Cima", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", false);
            }
            else if (movimentoVertical > 0)
            {
                SR.flipX = false;
                animator.SetBool("Cima", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Baixo", false);
                
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("0"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[0].itemImage;    
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("1"))
        {
           Destroy(other.gameObject);
           inventario.SetActive(true);
           podeAndar = false;
           inventoryScript.mouseItem = inventoryScript.item[1].itemImage;
           inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("2"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[2].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("3"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[3].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("4"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[4].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("5"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[5].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("6"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[6].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("7"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[7].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("8"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[8].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("9"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[9].itemImage;
            inventoryScript.aparecer();
        }
    }
}