using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class ControladorDeUI : MonoBehaviour
{
    public GameObject[] itensJogo;
    public GameObject GameOver;
    public GameObject Venceu;
    public LixoController lixoController;
    public LixoSpawner lixoSpawner;
    public TMPro.TextMeshProUGUI Tempo;
    private float tempoEmSegundos;
    private string tempoFormatado;
    private float tempoRestante;
    public PlayerJson playerJ;

    void Start()
    { 
        playerJ = new PlayerJson();
        playerJ.LoadGame();
        lixoSpawner.inJogo = true;
        tempoEmSegundos = 60f;
        tempoRestante = tempoEmSegundos;
        StartCoroutine(ContarTempo());
        foreach (GameObject objeto in itensJogo)
        {
            objeto.SetActive(true);
        }
        GameOver.SetActive(false);
        Venceu.SetActive(false);
    }

    void Update()
    {
        playerJ.LoadGame();
        if(lixoController.pontos < 0)
        {
            FimDeJogo();
            lixoSpawner.inJogo = false;
        }
        tempoRestante = tempoEmSegundos;
    }

    public void FimDeJogo()
    {
        GameOver.SetActive(true);
        foreach (GameObject objeto in itensJogo)
        {
            objeto.SetActive(false);
        }
    }

    public void VenceuJogo()
    {
        if(playerJ.VezesJogadasSeparador == "0")
        {
            playerJ.VezesJogadasSeparador = "1";
            playerJ.faseAtual = "separador";
            playerJ.SaveGame();
        }

        lixoSpawner.inJogo = false;
        Venceu.SetActive(true);
        foreach (GameObject objeto in itensJogo)
        {
            objeto.SetActive(false);
        }
    }

    public void DeNovo()
    {
        foreach (GameObject objeto in itensJogo)
        {
            objeto.SetActive(true);
        }        
        GameOver.SetActive(false);
        Venceu.SetActive(false);
        lixoSpawner.inJogo = true;
        lixoController.pontos = 0;
    }

    public string FormatTempo(float tempo)
    {
        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);

        return string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    IEnumerator ContarTempo()
    {
        while(tempoRestante >= 0)
        {
            Tempo.text = tempoFormatado;
            tempoFormatado = FormatTempo(tempoEmSegundos);
            yield return new WaitForSeconds(1f);
            tempoEmSegundos -= 1;
        }
        if(tempoRestante <= 0)
        {
            Tempo.text = "00:00";
            VenceuJogo();
            lixoSpawner.inJogo = false;
        }
    }
}
