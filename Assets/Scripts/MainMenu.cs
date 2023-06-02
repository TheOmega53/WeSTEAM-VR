using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform PlayerCamera;

    
    private void OnEnable()
    {
        transform.parent.LookAt(PlayerCamera);
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
