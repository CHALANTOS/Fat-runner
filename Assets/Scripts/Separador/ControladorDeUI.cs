using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    void Start()
    { 
        lixoSpawner.inJogo = true;
        tempoEmSegundos = 60f;
        tempoRestante = tempoEmSegundos;
        StartCoroutine(ContarTempo());
        foreach (GameObject objeto in itensJogo)
        {
            objeto.SetActive(true);
        }
        GameOver.SetActive(false);
    }

    void Update()
    {
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
