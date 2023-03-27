using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed = 4;
    // will only move in x so its ok to just have this
    public int XMoveDirection;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection,0) * EnemySpeed;
        // if distance between ray and not player < 0.7 (for movement between boxes)
         //if (hit.distance < 0.7f && !(hit.collider.tag=="Player")) {
        if (hit.distance < 0.7f && ((hit.collider.tag =="Ground") || (hit.collider.tag == "Enemy"))) {
            Flip();
        }
    }

    // Change direction of player 
    void Flip()
    {
        transform.Rotate(0f, 180f, 0f); //flip the image
        if (XMoveDirection > 0){
            XMoveDirection = -1;
        } else {
            XMoveDirection = 1;
        }
    }
}
