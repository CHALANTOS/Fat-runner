using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Atributos")]
    public float speed = 3;
    public float movimentoHorizontal;
    public float movimentoVertical;
    public float velocidade = 5.0f ;
    public bool podeAndar;
    public bool isHUDActive;
    bool isActive;

    [Header("Imports")]
    [SerializeField]
    public GameObject inventario;
    public GameObject HUD;
    private Inventory inventoryScript;
    public SpriteRenderer SR;
    public Rigidbody2D rig;
    public Animator animator;
    
    void Start()
    {
        Debug.Log("Comecou o jogo");
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        podeAndar = true;
        inventoryScript = inventario.GetComponent<Inventory>();

        isHUDActive = true;
        HUD.SetActive(true);
    }
    void Update()
    {
        if (podeAndar == true)
        {
            Movimento();
        }

        EsconderCanvas();        
    }
    void EsconderCanvas()
    {
        //Inventário
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isHUDActive)
            {
                // AJUDA DESATIVAR
                HUD.SetActive(false);
                isHUDActive = false;
            }
             // INV ATIVAR
                isActive = !inventario.activeSelf;
                inventario.SetActive(isActive);

                podeAndar = !inventario.activeSelf;
        }
 
        // MOSTRAR AJUDA
        if (Input.GetKeyDown(KeyCode.Z) && podeAndar)
        {
           HUD.SetActive(!isHUDActive);
            isHUDActive = !isHUDActive; 
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            velocidade = velocidade * 2;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            velocidade = velocidade / 2;
        }
    }

    void Movimento()
    {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
    
        movimentoVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * movimentoVertical);

        // Descer
        if (movimentoVertical < 0)
        {
            SR.flipX = false;
            animator.SetBool("Baixo", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Cima", false);
            animator.SetBool("Lados", false);
        }

        // Subir
        else if (movimentoVertical > 0)
        {
            SR.flipX = false;
            animator.SetBool("Cima", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Baixo", false);
            animator.SetBool("Lados", false);
            
        }

        // Direita
        else if(movimentoHorizontal > 0)
        {
            SR.flipX = false;
            animator.SetBool("Lados", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Baixo", false);
            animator.SetBool("Cima", false);
        }

        // Esquerda
        else if (movimentoHorizontal < 0)
        {
            SR.flipX = true;
            animator.SetBool("Lados", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Baixo", false);
            animator.SetBool("Cima", false);
        }

        // Parado
        else if(movimentoHorizontal == 0 && movimentoVertical == 0)
            {
                SR.flipX = false;
                animator.SetBool("Cima", false);
                animator.SetBool("Baixo", false);
                animator.SetBool("Lados", false);
                animator.SetBool("Idle", true);
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