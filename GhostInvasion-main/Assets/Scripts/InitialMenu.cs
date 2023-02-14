using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{

    public void Play() //boton de start
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void Exit() //boton exit
    {
        Debug.Log("Exit...");
        Application.Quit();
    }
    public void Return() //boton para volver al menu
    {
       SceneManager.LoadScene("InitialMenu");
    }
   
}
