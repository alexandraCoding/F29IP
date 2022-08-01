using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneViewModel : MonoBehaviour
{
   public void ChnageScene(string name)
    {
        Debug.Log("sceneName to load: " + name);
        SceneManager.LoadScene(name);
    }

    public void ExitApp()
    {
        Debug.Log("exit app");
  
          Application.Quit();
    }
}
