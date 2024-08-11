using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AcoesPlayer : MonoBehaviour
{
    public GameObject escudo;
    public Cerebro cerebro;
    public LutaController lutaController;
    public LenhadorBranco lenhadorBranco;
    public BarraDeVidaInim BarrasInim;

    public void Ataque()
    {
        BarrasInim.RealVidaInim -= 1;
        lenhadorBranco.AplicarDano();
        lutaController.round = 0;
    }

    public void Defender()
    {
        escudo.SetActive(true);
        cerebro.escudoAtivo = true;
        lutaController.round = 0;
    }
}
