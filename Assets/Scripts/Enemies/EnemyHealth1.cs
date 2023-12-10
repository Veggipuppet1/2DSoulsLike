using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth1 : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3;
    private float currentHealth;

    

    private void Start() {
        currentHealth = maxHealth;    
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0){
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
