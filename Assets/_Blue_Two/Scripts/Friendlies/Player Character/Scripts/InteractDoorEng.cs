using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractDoorEng : MonoBehaviour
{
    private bool enterAllowed;
    
    
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
        
        if (enterAllowed && Input.GetKey(KeyCode.E))
        {
        SceneManager.LoadScene("Menu");
        }
    }
}
