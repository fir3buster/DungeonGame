using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;

    public GameObject gameOverScreen;

    private void Awake()
    {
        isGameOver = false;
    }
  
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            
        }
        
    }

    // public void MainMenu()
    // {
    //     SceneManager.LoadScene("Menu");
    // }
}
