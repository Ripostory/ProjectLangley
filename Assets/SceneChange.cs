using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public void RestartScene()
    {
        print("Restarting Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;

        //try to get next scene
        
        if (SceneIndex < SceneManager.sceneCount)
        {
            Scene nextScene = SceneManager.GetSceneAt(SceneIndex + 1);
            SceneManager.LoadScene(nextScene.name);
        } else
        {
            print("No scenes after this one.");
        }
    }
}
