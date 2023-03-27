using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverUp : MonoBehaviour
{
    public float speed = 3f;
    public float maxheight = 5f;
    public float minheight = 0f;
    bool moveUp = true;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxheight)
            moveUp = false;
        if (transform.position.y < minheight)
            moveUp = true;

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);

    }
}
