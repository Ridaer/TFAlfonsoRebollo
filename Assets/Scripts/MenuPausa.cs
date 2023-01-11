using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
  

    private bool juegoPausado = false;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (juegoPausado)
        {
            Reanudar();
        }
        else
        {
            Pausa();   
        }
    }
  }
  
  public void Pausa(){
    Time.timeScale = 0f;
    juegoPausado = true;
    botonPausa.SetActive(false);
    menuPausa.SetActive(true);
  }

  public void Reanudar(){
    juegoPausado = false;
    Time.timeScale = 1f;
    botonPausa.SetActive(true);
    menuPausa.SetActive(false);
  }

  public void Reinciar(){
    juegoPausado = false;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Time.timeScale = 1f;
  }

  public void Cerrar(){
    SceneManager.LoadScene(1);
  }

  public void NextLevel(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Time.timeScale = 1f;
  }
}
