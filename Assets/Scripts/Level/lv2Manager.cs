using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lv2Manager : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            LoadNextScene(); 
        }
    }

    private void LoadNextScene()
    {
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene(nextSceneIndex); 
        }
        else
        {
            Debug.Log("no more levels"); 
        }
    }
}
