using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenhadorBranco : MonoBehaviour
{
    public Animator lenhadorAnim;
    public void AplicarDano()
    {
        lenhadorAnim.SetBool("Dano",true);
    }
    
    public void PararDano()
    {
        lenhadorAnim.SetBool("Dano",false);
    }

}
