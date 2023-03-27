using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractDoor : MonoBehaviour
{
    private bool enterAllowed;
    public static bool hasGunExit;
    
    // [SerializeField]
    // public GameObject Player;
    
    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<EntranceDoor>())
        {
            enterAllowed = true;
        }
    }  
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // [SerializeField]
        hasGunExit = GetComponent<Weapon>().hasGun;
        if (enterAllowed && Input.GetKey(KeyCode.E))
        {
            if (hasGunExit) {
                SceneManager.LoadScene("OverviewMap");
            } else {
                SceneManager.LoadScene("Menu");
            }

        }
    }
}
