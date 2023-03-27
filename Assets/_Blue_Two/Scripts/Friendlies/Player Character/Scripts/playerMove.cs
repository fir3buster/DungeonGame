using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public int playerSpeed = 8;
    public bool facingRight = true;
    public int playerJumpPower = 1000;
    public float moveX;
    public bool onGround;
    public bool firstJump = true;
    public int jumpCount = 0;

    public int trampolineForce = 2000;
    public Animator anim;

        // // Start is called before the first frame update
    void Start()
    {
        // Animator
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        UpdateAnimaton(); 
    }

    void PlayerMove(){
        // get X direction
        moveX = Input.GetAxis("Horizontal");
        // allows for two jumps only 
        // can jump if on the ground or has only jumped once this time before hitting ground
        if (Input.GetButtonDown("Jump") && (onGround || jumpCount <2)){
                jumpCount +=1;
                Jump();
        }
        // reset count when hit ground
        if (onGround){
            jumpCount = 0;
        }
        // if player faces left and was facing right, flip
        if (moveX < 0.0f && facingRight){
            FlipPlayer();
        }
        // if player face right and was facing left, flip
        else if (moveX > 0.0f && !facingRight) {
            FlipPlayer();
        }
        // set velocity of player based on speed and direction
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    // add upward force to make jump 
    void Jump(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        onGround = false;
    }
    // flips the player image
    void FlipPlayer(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // On collision with ground, reset boolean to true
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Ground") {
            onGround = true;
        } 
        if(col.gameObject.tag == "MovingPlatform"){
            this.transform.parent = col.transform;
            onGround = true;
        }
        if (col.gameObject.tag == "Trampoline")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * trampolineForce);
            onGround = false;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "MovingPlatform"){
            this.transform.parent = null;
             onGround = false;
        }
    }
    void UpdateAnimaton(){
        if (moveX > 0f) {
            anim.SetBool("Running", true); 
        }
        else if (moveX < 0f) {
            anim.SetBool("Running", true);
        }
        else {
            anim.SetBool("Running", false);
        }
    }
}
