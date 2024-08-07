using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerJson
{

    public string plataforma;
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
    }

}
