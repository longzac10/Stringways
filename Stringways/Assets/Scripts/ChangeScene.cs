using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MovetoScene(int sceneID)
    {
       
        SceneManager.LoadScene(sceneID);
        
    }

    public void MovetoNextScene()
    {
        Debug.Log("Scene increase");
        ScoreHandler.nextSceneNumber += 1;
        SceneManager.LoadScene(ScoreHandler.nextSceneNumber);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
