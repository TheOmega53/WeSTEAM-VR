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

    [SerializeField] private AudioSource BackgroundMusic;

    [SerializeField] private GameObject Watch;
    private DialogueManager dialogueManager;    
    private void Start()
    {
        dialogueManager = DialogueManager.GetInstance();
        ContinueDialogueButton.onClick.AddListener (() => dialogueManager.MakeChoice(0));
        MenuCanvas.gameObject.SetActive(false);        
    }


    public void LookAtPlayer()
    {
        StartCoroutine(timeWaster());
    }

    public IEnumerator timeWaster()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("looking at player");
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
    
    public void SetVolume(Slider slider)
    {
        BackgroundMusic.volume = slider.value;
    }
}
