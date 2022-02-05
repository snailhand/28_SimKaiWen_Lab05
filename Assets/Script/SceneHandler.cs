using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler inst;

    private void Start()
    {
        inst = this;
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Additive);
    }

    public void WinScene()
    {
        SceneManager.LoadScene("WinScene", LoadSceneMode.Additive);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
