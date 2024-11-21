using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] FloatingHealthBar healthbar;
    private void Awake()
    {
       healthbar = GetComponentInChildren<FloatingHealthBar>();
    }
    void Start()
        {
        health = maxHealth;
        healthbar.UpdateHealthBar(health,maxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthbar.UpdateHealthBar(health,maxHealth);
        
        if(health<=0 )
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
}
