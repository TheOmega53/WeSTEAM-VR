using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchMenuInteractions : MonoBehaviour
{

    private bool isMenuActive;
    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private Transform PlayerCamera;

    [SerializeField] private Button ContinueDialogueButton;
    private DialogueManager dialogueManager;
    private void Start()
    {
        dialogueManager = DialogueManager.GetInstance();
        ContinueDialogueButton.onClick.AddListener (() => dialogueManager.ContinueStory());
    }

    private void OnEnable()
    {
        transform.parent.LookAt(PlayerCamera);
    }
    public void ToggleMenu()
    {
        isMenuActive = MenuCanvas.isActiveAndEnabled;
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
