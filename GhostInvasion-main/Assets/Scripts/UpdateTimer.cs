using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTimer : MonoBehaviour
{
    public float timer = 0; //numero para empezar a contar
    public TMPro.TMP_Text timerText; //llama al text mesh pro

 void Update()
    {
        timer += Time.deltaTime; //para que sume por cada frame
        timerText.text = "" + timer.ToString("f2"); //decimales

    }


}
