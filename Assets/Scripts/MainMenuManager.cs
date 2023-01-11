using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void EscenaOpciones()
    {
        Debug.Log("asd2");
        SceneManager.LoadScene("Opciones");
    }

    public void EscenaInicio()
    {
        Debug.Log("asd1");
        SceneManager.LoadScene("1-1");
        Time.timeScale = 1f;
    }

    public void CerrarJuego()
    {
        Debug.Log("asd2");
        Application.Quit();
    }

    public void CerrarSesion()
    {
        SceneManager.LoadScene("Login");
    }
}
