using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LixoController : MonoBehaviour
{
    public int pontos;    
    public TMPro.TextMeshProUGUI NumPontos;

    void start()
    {
        pontos = 0;
    }
    
    void Update()
    {
        NumPontos.text = pontos.ToString();
    }
}
