using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private int sceneNumber = 1;
    public void MovetoScene(int sceneID)
    {
        sceneNumber++;
        Debug.Log("Scene increase");
        SceneManager.LoadScene(ScoreHandler.nextSceneNumber);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
