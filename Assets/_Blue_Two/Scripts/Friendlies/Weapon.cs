using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator anim;
    public bool hasGun;
    


    void Start()
    {
        anim = GetComponent<Animator>();
        if (hasGun)
        {
            // InteractDoor.hasGunExit = hasGun;
            anim.SetBool("GunOwnership", true);
        } else {
            // InteractDoor.hasGunExit = hasGun;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (hasGun)
            {
                Shoot();
            }
            
        }
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            Destroy(collision.gameObject);
            anim.SetBool("GunOwnership", true);
            hasGun = true;
        }
    }
}
