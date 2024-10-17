using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao_mochila : MonoBehaviour
{
    public GameObject inventario;
    public bool IsActive = false;
    public GameObject OutraMochila;
    //Isso vai dar ruim, não sei quando mas vai

    public void Mochila2()
    {
        inventario.SetActive(false);
        OutraMochila.SetActive(true);
        IsActive = false;
    }
    public void Mochila1()
    {
        this.gameObject.SetActive(false);
        inventario.SetActive(true);
        IsActive = true;
    }
}
