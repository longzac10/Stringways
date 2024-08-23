using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishButtonHandler : MonoBehaviour
{

    public int numberTownsMissed = 0;
    public int numberNullPathways = 0;
    public float limeStringRemaining = 0.0f;

    
    public void MovetoScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
