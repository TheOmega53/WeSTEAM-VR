using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
