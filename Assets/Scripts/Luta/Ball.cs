using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Imports")]
    public SpriteRenderer sprt;
    public GameObject ball1;
    [SerializeField]
    Animator animator;
    public int Lado = 0;
    public bool InLUTA;
    public LutaController lutaController;

    void Start()
    {
        Lado = Random.Range(1, 3);
        animator = GetComponent<Animator>();
        if(transform.position.x == 0 && transform.position.y == 0)
        {
            Destruir();
        }
    }

    void Update()
    {
        if (InLUTA)
        {
            Atacar();
            if (lutaController.round == 1)
            {
                animator.SetBool("atk1",false);
                animator.SetBool("atk2",false);
            }
        }
    }

    public void Atacar()
    {
        if(lutaController.round != 1)
        {

            if (Lado == 1)
            {
                animator.SetBool("atk1",true);
                animator.SetBool("atk2",false);
            }
            else if (Lado == 2)
            {
                animator.SetBool("atk1",false);
                animator.SetBool("atk2",true);
            }
        }
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    public void TrocarAtaque()
    {
        if(lutaController.round != 1)
        {
            Lado = Random.Range(1, 3);
            lutaController.round = lutaController.round + 0.5f;
        }
        lutaController.PodeAtacar();
    }
}


