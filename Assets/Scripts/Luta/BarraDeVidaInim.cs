using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaInim : MonoBehaviour
{
    public LutaController lutaController;
    public Slider sliderInim;
    public int RealVidaInim = 10;
    
    void Start()
    {
        sliderInim.maxValue = 10;
    }
    void Update()
    {
        sliderInim.value = RealVidaInim;
        if(sliderInim.value <= 0)
        {
            lutaController.TrocarCena();
        }
    }
}
