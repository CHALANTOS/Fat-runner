using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Atributos")]
    public bool isCelular;
    public bool isInstucoesActive;
    public bool isBotoesActive;
    public bool isEscolha_plataformActive;

    [Header("Imports")]
    public GameObject Botoes;
    public GameObject Escolha_plataform;
    public GameObject Mochila;
    public Dialogo_Simples Veio;

    public GameObject Instrucoes;
    // public GameObject transicao;
    // public Animator transicaoAnim;
    public PlayerJson playerJ;

    private static bool escolheuPlataforma = false;

    void Start()
    {
        playerJ = new PlayerJson();
        playerJ.LoadGame();

        if (!escolheuPlataforma)
        {
            playerJ.faseAtual = "";
            isEscolha_plataformActive = true;
            Escolha_plataform.SetActive(true);
            Mochila.SetActive(false);
        }
        else
        {
            isEscolha_plataformActive = false;
            Escolha_plataform.SetActive(false);
        }

        isInstucoesActive = true;
        Instrucoes.SetActive(true);

        Botoes.SetActive(true);
        isBotoesActive = true;
    }

    void Update()
    {
        if (playerJ.plataforma == "PC")
        {
            Botoes.SetActive(false);
            isBotoesActive = false;
        }
        if (playerJ.plataforma == "Celular")
        {
            Botoes.SetActive(true);
            isBotoesActive = true;
        }

        if(Veio.conversou)
        {
            playerJ.faseAtual = "veio";
            playerJ.SaveGame();
        }
    }

    public void Celular()
    {
        isCelular = true;
        playerJ.plataforma = "Celular";
        playerJ.SaveGame();
        escolheuPlataforma = true;
        Mochila.SetActive(true);
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
        //transicao.SetActive(true);
    }

    public void PC()
    {
        isCelular = false;
        playerJ.plataforma = "PC";
        playerJ.SaveGame();
        escolheuPlataforma = true;
        Mochila.SetActive(false);
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
        //transicao.SetActive(true);
    }
}
