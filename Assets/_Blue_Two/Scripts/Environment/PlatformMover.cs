using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed = 3f;
    public float maxleft = -2f;
    public float maxright = 5f;
    bool moveRight = true;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxright)
            moveRight = false;
        if(transform.position.x < maxleft)
            moveRight = true;

        if (moveRight)  
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

    }
}
