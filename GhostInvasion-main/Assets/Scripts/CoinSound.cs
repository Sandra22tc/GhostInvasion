using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound; //para meter el clip


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //detecta el tag del jugadro
        {
            
            AudioManager.instance.PlayAudio(coinSound, 1);  //instancia el clip con el audio source y el volumen
        }
    }
}
