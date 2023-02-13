using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int puntuacion = 0;

    private float time = 0;
   
    public static GameManager instance;//es una variable que solo puede existir una vez por codigo, tambien es accesible desde cualquier lugar del codigo. Se suele llamar instance porque es una instancia del objeto

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
    private void Update()
    {
        time = Time.deltaTime;   //esto es para sumar el tiempo que tardar en cargar cada frame
    }
    public void AddPunt(int value)
    {
        puntuacion += value;
    }

    public int GetPunt()
    {
       return puntuacion;
    }

    public float GetTime()
    {
            return time;
    }
    
}