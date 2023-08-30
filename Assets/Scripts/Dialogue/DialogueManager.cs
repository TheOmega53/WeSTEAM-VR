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

    private TextMeshProUGUI dialogueText;
    [Header("Default Dialogue UI")]   
    [SerializeField] private TextMeshProUGUI dialogueTextNoChoices;
    [Header("Dialogue UI With Choices")]    
    [SerializeField] private TextMeshProUGUI dialogueTextWithChoices;
    [SerializeField] private Image TalkerImage;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [SerializeField] private Image CanContinueSprite;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private TextMeshProUGUI ContinueButtonText;

    private Story currentStory;
    private List<Text> StoryLog = new List<Text>();
    private UnityEvent endOfStoryEvent;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene, I am:" + name + "but existing instance is: " + instance.name);
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

        dialogueText = dialogueTextNoChoices;

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, UnityEvent EndOfStoryEvent, Sprite TalkerSprite)
    {
        StoryLog.Clear();

        currentStory = new Story(inkJSON.text);
        endOfStoryEvent = EndOfStoryEvent;
        if (TalkerSprite != null)
        {
            TalkerImage.sprite = TalkerSprite;
        }
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
            string text = currentStory.Continue();
            dialogueText.text = text;
            DisplayChoices();

            //TODO: CREATE A LOG OF THE STORY PROGRESSION
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

    private void ChangeDialogueBox(TextMeshProUGUI DialogueBox)
    {
        TextMeshProUGUI temp = null;
        if (dialogueText) {
            temp = dialogueText;            
        }              
        dialogueText = DialogueBox;
        dialogueText.text = temp.text;

        temp?.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(true);

        temp = null;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentStory.currentChoices.Count > 1)
        {
            if (continueButton != null) continueButton?.gameObject.SetActive(false);
            if (CanContinueSprite != null) CanContinueSprite?.gameObject.SetActive(false);
            ChangeDialogueBox(dialogueTextWithChoices);
        }
        else
        {
            if(continueButton != null) continueButton?.gameObject.SetActive(true);
            if(CanContinueSprite != null) CanContinueSprite?.gameObject.SetActive(true);            
            ChangeDialogueBox(dialogueTextNoChoices);
        }

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support.");
        }


        if(currentChoices.Count > 1)
        {
            int index = 0;

            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }

            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        } else
        {
            foreach (Choice choice in currentChoices)
            {
                ContinueButtonText.text = choice.text;
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        if(currentStory.currentChoices.Count > 0)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }        
        ContinueStory();

    }
}
