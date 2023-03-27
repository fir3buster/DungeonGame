using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float levelDepth = -6;
    public Slider slider;


    private Renderer rd;
    private float current_health;
    void Start()
    {
        slider.value = health;
        slider.maxValue = health;
        slider.minValue = 0;
        rd = GetComponent<Renderer>();
        current_health = health;
        InvokeRepeating("EnemySearch", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        // if player falls further than the ground
        if (gameObject.transform.position.y < levelDepth){
            Die();
            ZombieScore.scoreValue = 0; // score to return 0 upon death
        }
        if (health <= 0){
            Die();
            ZombieScore.scoreValue = 0; // score to return 0 upon death
        }

        if (health < current_health)
        {
            hurt();
            current_health = health;
        }

    }
    // If player collides with enemy, player dies
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Enemy")
        {
            Die();
            ZombieScore.scoreValue = 0; // score to return 0 upon death
        }
    }
    // Check if enemy is within certain distance and decrease health
    // Can change this easily to make a progressively closer damaging aura with if statements
    void EnemySearch(){
        var enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            float m = 1;
            float n = 1;
            
            if (enemy.name == "FRANK")
            {
                m = 1.5f; n = 2;
            }
            if (Vector2.Distance(transform.position, enemy.transform.position) < 3*n)
            {
                health -= 5*m;
            }
        }

    }
    // Reload scene on death 
    void Die(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void hurt()
    {
        rd.material.SetColor("_Color", Color.red);
        Invoke("recover", 0.5f);

    }

    void recover()
    {
        rd.material.SetColor("_Color", Color.white);
    }
}
