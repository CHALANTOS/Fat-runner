using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotaoSeparador : MonoBehaviour
{
    public ControladorDeUI controladorDeUI;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Reiniciar()
    {
        controladorDeUI.DeNovo();
    }
}
