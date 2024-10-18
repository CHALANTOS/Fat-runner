using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao_mochila : MonoBehaviour
{
    public Player player;
    public PlayerJson playerJ;
    public GameObject inventario;
    public GameObject botoesMovi;
    public bool IsActive = false;
    public GameObject OutraMochila;
    //Isso vai dar ruim, não sei quando mas vai

    void Start()
    {
        playerJ = new PlayerJson();
        playerJ.LoadGame();
    }

    public void Mochila1()
    {
        inventario.SetActive(true);
        if(playerJ.plataforma == "PC")
        {
            OutraMochila.SetActive(false);
        }
        else
        {
            OutraMochila.SetActive(true);
        }
        this.gameObject.SetActive(false);
        botoesMovi.SetActive(false);
        player.podeAndar = false;
        IsActive = true;
    }

    public void Mochila2()
    {
        if(playerJ.plataforma == "PC")
        {
            OutraMochila.SetActive(false);
        }
        else
        {
            OutraMochila.SetActive(true);
        }
        inventario.SetActive(false);
        botoesMovi.SetActive(true);
        player.podeAndar = true;
        IsActive = false;
    }
}
