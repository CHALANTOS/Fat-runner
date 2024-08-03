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

    [Header("Imports")]
    public SpriteRenderer SR;
    public Animator animator;
    public Rigidbody2D rig;

    void Start()
    {
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
        movimentoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);

        movimentoVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * movimentoVertical);

        // Idle
        if (movimentoHorizontal == 0 && movimentoVertical == 0 )
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Lados", false);
            animator.SetBool("Baixo", false);
            animator.SetBool("Cima", false);

            SR.flipX = false;
        }

        // Cima
        else if (movimentoVertical > 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", false);
            animator.SetBool("Baixo", false);
            animator.SetBool("Cima", true);

            SR.flipX = false;
        }

        //Baixo
        else if (movimentoVertical < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", false);
            animator.SetBool("Baixo", true);
            animator.SetBool("Cima", false);

            SR.flipX = false;
        }

        // Esquerda
        else if(movimentoHorizontal < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", true);
            animator.SetBool("Baixo", false);
            animator.SetBool("Cima", true);

            SR.flipX = false;
        }

        // Direita
        else if(movimentoHorizontal > 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", true);
            animator.SetBool("Baixo", false);
            animator.SetBool("Cima", true);

            SR.flipX = true;
        }
    }

    IEnumerator Comeco()
    {
        yield return new WaitForSeconds(2);
        Iniciou = true;
        Debug.Log("Começou Lab");
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("TROCA"))
        {
            SceneManager.LoadScene("Jogo");
        }
    }
}