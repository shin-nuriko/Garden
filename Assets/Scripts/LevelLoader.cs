using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 5f;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitSomeTime());
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameStart()
    {
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options Screen");
    }
    public void LoadGameEnd()
    {
        SceneManager.LoadScene("End Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

 
}
