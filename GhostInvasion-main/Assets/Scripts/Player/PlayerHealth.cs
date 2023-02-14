using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealth.Damage(1);
        }
    }
    public void Damage(int levelOfDamage)
    {
        health -= levelOfDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
