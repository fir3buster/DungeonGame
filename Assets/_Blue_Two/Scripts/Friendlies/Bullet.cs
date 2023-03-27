using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        BossHealth boss = hitInfo.GetComponent<BossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        

        Destroy(gameObject);
        
    }

    private void Update()
    {
        Destroy(gameObject, 4f);
    }

}
