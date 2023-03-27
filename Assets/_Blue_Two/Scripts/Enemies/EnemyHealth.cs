using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    
    public float health = 100;
    //public GameObject deathEffect;
    //public Slider slider;

    //void Start()
    //{
    //    slider.value = health;
    //    slider.maxValue = 100;
    //    slider.minValue = 0;
    //}

    public void TakeDamage (int damage)
    {
        health -= damage;
        //slider.value = health;
        if (health <= 0)
        {
            ZombieScore.scoreValue += 10;  // score 10 for killing each zombie
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
