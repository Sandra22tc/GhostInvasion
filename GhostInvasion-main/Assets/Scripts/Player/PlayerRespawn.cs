using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;


    void Start()
    {
        life = hearts.Length;
    }

    public void Update()
    {
        if(life < 1)
        {
            Destroy(hearts[0].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if(life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }
    public void PlayerDamaged()
    {
        life--;
    }
}
