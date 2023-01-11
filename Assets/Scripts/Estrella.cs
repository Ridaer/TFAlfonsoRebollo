using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour
{
[SerializeField] private GameObject menuGanar;
public AudioClip SonidoGanar;

private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
           menuGanar.SetActive(true);
           Camera.main.GetComponent<AudioSource>().PlayOneShot(SonidoGanar);
           Time.timeScale = 0f;
        }
    }


}
