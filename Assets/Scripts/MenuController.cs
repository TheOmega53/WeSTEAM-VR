using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles the interactions included in the main menu. (Settings, reload, exit)
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingsPanel;
    [SerializeField]
    private GameObject StoryPanel;

    public void ToggleSettings()
    {
        if (StoryPanel.activeSelf) 
        {
            SettingsPanel.SetActive(true);
            StoryPanel.SetActive(false);
        }
        else
        {
            SettingsPanel.SetActive(false);
            StoryPanel.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
