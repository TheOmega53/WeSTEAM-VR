using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchMenuInteractions : MonoBehaviour
{

    private bool isMenuActive;
    public Canvas MenuCanvas;

    private void Start()
    {
        isMenuActive = MenuCanvas.isActiveAndEnabled;
    }
    public void ToggleMenu()
    {
        if (isMenuActive)
        {
            MenuCanvas.gameObject.SetActive(false);
            isMenuActive = false;
        } else
        {
            MenuCanvas.gameObject.SetActive(true);
            isMenuActive = true;
        }
    }
    
}
