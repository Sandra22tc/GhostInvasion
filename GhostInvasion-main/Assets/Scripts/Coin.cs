using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    public int score = 0;
    
    public TMPro.TMP_Text scoreText; //llama al text mesh pro


    private void Start()
    {
        score = 0;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }

}
