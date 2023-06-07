using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.Events;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image TalkerImage;

    private Story currentStory;
    private UnityEvent endOfStoryEvent;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    public void EnterDialogueMode(TextAsset inkJSON, UnityEvent EndOfStoryEvent, Sprite TalkerSprite)
    {
        currentStory = new Story(inkJSON.text);
        endOfStoryEvent = EndOfStoryEvent;
        TalkerImage.sprite = TalkerSprite;
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        endOfStoryEvent.Invoke();
    }
}
