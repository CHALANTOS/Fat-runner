using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isCelular;
    public bool isInstucoesActive;
    public bool isBotoesActive;
    public bool isEscolha_plataformActive;
    public GameObject Botoes;
    public GameObject Escolha_plataform;
    public GameObject Instrucoes;
    void Start()
    {
        isEscolha_plataformActive = true;
        Escolha_plataform.SetActive(true);
        
        isInstucoesActive = true;
        Instrucoes.SetActive(true);

        Botoes.SetActive(true);
        isBotoesActive = true;

    }
    public void Celular()
    {
        if (isInstucoesActive)
        {
            Instrucoes.SetActive(false);
            isInstucoesActive = false;
        }
        if (isEscolha_plataformActive)
        {
            Escolha_plataform.SetActive(false);
            isEscolha_plataformActive = false;
        }
        isCelular = true;
    }

    public void PC()
    {
        if (isBotoesActive)
        {
            Botoes.SetActive(false);
            isBotoesActive = false;
        }
        if (isEscolha_plataformActive)
        {
            Escolha_plataform.SetActive(false);
            isEscolha_plataformActive = false;
        }
        isCelular = false;
    }
}
