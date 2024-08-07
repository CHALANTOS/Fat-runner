using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    public GameObject botao;
    public PlayerJson playerJ;
    public bool isButtonsActive;

    void Start()
    {
        playerJ = new PlayerJson();
        playerJ.LoadGame();
        
        if(playerJ.plataforma == "PC")
        {
            isButtonsActive = false;
            botao.SetActive(false);
        }
        else
        {
            isButtonsActive = true;
            botao.SetActive(true);
        }
    }
}