using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public static int ToiletPaper = 0;
    public static int FinalToiletPaper = 0;
    [SerializeField] private Text ToiletPaper_Text;
    [SerializeField] private Text FinalToiletPaper_Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("ToiletPaper"))
       {
           Destroy(collision.gameObject); 
           ToiletPaper++;
           ToiletPaper_Text.text = "Toilet Paper: " + ToiletPaper;
           FinalToiletPaper++;
           FinalToiletPaper_Text.text = "Toilet Paper: " + FinalToiletPaper;
            
       }

       if(collision.gameObject.CompareTag("GoldenToiletPaper"))
       {
            Destroy(collision.gameObject); 
            ToiletPaper = ToiletPaper + 100000;
            ToiletPaper_Text.text = "Toilet Paper: " + ToiletPaper;
            FinalToiletPaper = FinalToiletPaper + 100000;
            FinalToiletPaper_Text.text = "TOILET PAPER: " + FinalToiletPaper;
            PlayerManager.isGameOver = true;
       }
   }   
}
