using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao_mochila : MonoBehaviour
{
    public Player player;
    public GameObject inventario;
    public GameObject botoesMovi;
    public bool IsActive = false;
    public GameObject OutraMochila;
    //Isso vai dar ruim, não sei quando mas vai


    public void Mochila1()
    {
        this.gameObject.SetActive(false);
        inventario.SetActive(true);
        botoesMovi.SetActive(false);
        player.podeAndar = false;
        IsActive = true;
    }

    public void Mochila2()
    {
        inventario.SetActive(false);
        botoesMovi.SetActive(true);
        player.podeAndar = true;
        OutraMochila.SetActive(true);
        IsActive = false;
    }
}
