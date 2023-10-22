using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class responsible for handling all of the watch menu interactions.
//These include adjusting the menu to player position, swapping left and right hand menus,
//toggling the menu by tapping on the watch, and adjusting volume settings
public class WatchMenuInteractions : MonoBehaviour
{

    private bool isMenuActive;
    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Button ContinueDialogueButton;

    [SerializeField] private AudioSource BackgroundMusic;
    [SerializeField] private AudioSource ButtonBlip;

    [SerializeField] private GameObject Watch;
    private DialogueManager dialogueManager;    
    private void Start()
    {
        dialogueManager = DialogueManager.GetInstance();
        ContinueDialogueButton.onClick.AddListener (() => dialogueManager.MakeChoice(0));
        MenuCanvas.gameObject.SetActive(false);        
    }

    private void Update()
    {
        LookAtPlayer();
    }

    //used for adjusting the orientation of the menu so that it's always facing player.
    public void LookAtPlayer()
    {
        transform.parent.LookAt(PlayerCamera);
    }


    //Used for reseting position of the watch when switching hands
    public void SwapWatch(Transform WatchLocation)
    {        

        Watch.transform.parent = WatchLocation;

        Watch.transform.localPosition = Vector3.zero;
        Watch.transform.localEulerAngles = Vector3.zero;
        Watch.transform.localScale = new Vector3(1, 1, 1);

        transform.parent.LookAt(PlayerCamera);
    }

    private void OnEnable()
    {
        transform.parent.LookAt(PlayerCamera);
        Debug.Log("On Enable was called");
        ButtonBlip.Play();
    }


    //called by poke event on the watch, to enable or disable the menu.
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
    

    //used for adjusting the volume slider.
    public void SetVolume(Slider slider)
    {
        BackgroundMusic.volume = slider.value;
    }
}
