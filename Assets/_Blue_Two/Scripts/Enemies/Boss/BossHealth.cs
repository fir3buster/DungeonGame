using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health = 100;
    public float attackTime = 3f;
    public float invincibleTime = 5f;
    public GameObject toiletPaper;
    public Slider Bslider;
    private float current_health;
    private bool invincible = true;
    private Renderer rd;

    void Start()
    {
        rd = GetComponent<Renderer>();
        Bslider.value = health;
        Bslider.maxValue = health;
        Bslider.minValue = 0;
        current_health = health;
        Invincible();
    }

    void Update()
    {
        Bslider.value = health;
        if (health < current_health)
        {
            current_health = health;
        }

    }

    public void Invincible()
    {
        rd.material.SetColor("_Color", Color.white);
        invincible = true;
        Invoke("Vincible", invincibleTime);
    }

    public void Vincible()
    {
        invincible = false;
        rd.material.SetColor("_Color", Color.red);
        Invoke("Invincible", attackTime);
    }

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= damage;
            Bslider.value = health;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        ZombieScore.scoreValue += 100;
        Destroy(gameObject);
        Instantiate(toiletPaper, transform.position, transform.rotation);
    }
}

