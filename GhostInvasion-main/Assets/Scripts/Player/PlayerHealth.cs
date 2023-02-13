using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    public void Damage(int levelOfDamage)
    {
        health -= levelOfDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}