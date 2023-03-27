using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverviewMap : MonoBehaviour
{
    public void ArrivalSquareMap()
    {
        SceneManager.LoadScene("ArrivalSquare");
    }

    public void STVMap()
    {
        SceneManager.LoadScene("STV");
    }

    public void ChancellorsMap()
    {
        SceneManager.LoadScene("Chancellor_Miniboss");
    }

    public void LakeMap()
    {
        SceneManager.LoadScene("Lake");
    }

    public void LibraryMap()
    {
        SceneManager.LoadScene("Library");
    }

    public void PsychologyMap()
    {
        SceneManager.LoadScene("Psychology");
    }

    public void EngineeringMap()
    {
        SceneManager.LoadScene("Level_1");
    }

        public void MainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
    
        public void SampleScene ()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
