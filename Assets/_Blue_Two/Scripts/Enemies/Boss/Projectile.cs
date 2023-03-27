using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour
{
    public float moveSpead = 7f;
    private Rigidbody2D rb;
    private PlayerHealth target;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerHealth>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpead;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerhealth = collision.GetComponent<PlayerHealth>();
            playerhealth.health -= 15;
            Destroy(gameObject);
        }
        
    }
}
