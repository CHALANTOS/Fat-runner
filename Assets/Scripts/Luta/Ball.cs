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


    void Start()
    {
        animator = GetComponent<Animator>();
        if(transform.position.x == 0 && transform.position.y == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (InLUTA)
        {
            MudarAtaque();
        }
    }

    public void MudarAtaque()
    {
        
        if (Lado == 1)
        {
            animator.SetBool("atk2",false);
            animator.SetBool("atk1",true);
        }
        else if (Lado == 2)
        {
            animator.SetBool("atk1",false);
            animator.SetBool("atk2",true);
        }
    }
}

