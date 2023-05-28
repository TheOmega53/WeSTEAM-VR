using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
