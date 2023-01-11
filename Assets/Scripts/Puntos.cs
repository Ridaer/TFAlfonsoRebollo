using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    private float puntos = 20;
    private TextMeshProUGUI textMesh;
    [SerializeField] private GameObject menuPerder;
    public AudioClip SonidoPerder;

    private void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        puntos -= Time.deltaTime;
        textMesh.text = puntos.ToString("0");
        
        if (puntos <= 0)
        {
            menuPerder.SetActive(true);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SonidoPerder);
            Time.timeScale = 0f;
            puntos= 20;
                                  
        }
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
