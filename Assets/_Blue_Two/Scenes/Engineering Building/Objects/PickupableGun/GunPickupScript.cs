using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickupScript : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        // Animator
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.gameObject.CompareTag("Gun"))
       {
           Destroy(collision.gameObject); 
           anim.SetBool("GunOwnership", true);

       }
   } 
}
