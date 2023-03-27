using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScore : MonoBehaviour
{
    public static int scoreValue = 0;
    
    [SerializeField] private Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "ZOMBIE: " + scoreValue;
    }
}
