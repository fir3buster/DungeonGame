using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    private float fallDelay = 0.5f; // change fall delay here
    private bool touched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player" && touched == false)
        {
            touched = true;
            PlatformManager.Instance.StartCoroutine("SpawnPlatform",
                new Vector2(transform.position.x, transform.position.y));

            Invoke("DropPlatform", fallDelay);
            Destroy(gameObject, 4f); // destroy after 4s
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        col.isTrigger = true;

    }
}
