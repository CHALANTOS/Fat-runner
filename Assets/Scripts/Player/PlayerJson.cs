using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerJson
{

    public string plataforma;
    public string faseAtual;
    public string VezesJogadasLab;
    public string VezesJogadasSeparador;
    public string VezesJogadasLuta;
    public string VezesConversadas;
    
    private string path = "Assets/Player.txt";


    public void SaveGame()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path, content);
    }

    public void LoadGame()
    {
        var content = File.ReadAllText(path);
        var data = JsonUtility.FromJson<PlayerJson>(content);

        plataforma = data.plataforma;
        faseAtual = data.faseAtual;
        VezesJogadasLab = data.VezesJogadasLab;
        VezesJogadasSeparador = data.VezesJogadasSeparador;
        VezesJogadasLuta = data.VezesJogadasLuta;
        VezesConversadas = data.VezesConversadas;
    }

}
