
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoyStick : MonoBehaviour
{  
    public bool andar_cima;
    public bool andar_baixo;
    public bool andar_esquerda;
    public bool andar_direita;

    public void MovimentoBotaoCima()
    {
        andar_cima = true;
    }

    public void MovimentoBotaoBaixo()
    {
        andar_baixo = true;
    }

    public void MovimentoBotaoEsquerda()
    {
        andar_esquerda = true;
    }
    public void MovimentoBotaoDireita()
    {
        andar_direita = true;
    }

    public void pararMovimento()
    {
        andar_cima = false;
        andar_baixo = false;
        andar_esquerda = false;
        andar_direita = false;
    }
}
