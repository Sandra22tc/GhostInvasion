using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    private float time = 0;
   
    public static GameManager instance;//es una variable que solo puede existir una vez por codigo, tambien es accesible desde cualquier lugar del codigo. Se suele llamar instance porque es una instancia del objeto

    public float timer = 0; //numero para empezar a contar
    public TMPro.TMP_Text timerText; //llama al text mesh pro
    void Awake() //el awake va incluso antes que el start
    {
        if (!instance) //instance != null. Comprueba que instance no tenga ningun tipo de info
        {
            instance = this;  //para inicializar la variable
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //si tiene info, significa que ya existe otro game manager     
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        score = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            score++;
            Debug.Log(score);
        }
    }
    private void Update()
    {
        time = Time.deltaTime;   //esto es para sumar el tiempo que tardar en cargar cada frame

        timer += Time.deltaTime; //para que sume por cada frame
        timerText.text = "" + timer.ToString("f2"); //decimales
    }

    public float GetTime()
    {
            return time;
    }
    

}