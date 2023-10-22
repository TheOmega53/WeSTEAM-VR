using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.Events;
using UnityEngine.UI;


/*
 * The Dialogue Manager class is responsible for reading the ink json files,
 * interpreting the dialogue and the choices and display it on a screen, which is normally the players watch.
 * 
 * This class is a singleton.
 */

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;

    private TextMeshProUGUI dialogueText;

    [Header("Default Dialogue UI")]   
    [SerializeField] private TextMeshProUGUI dialogueTextNoChoices;
    [Header("Dialogue UI With Choices")]    
    [SerializeField] private TextMeshProUGUI dialogueTextWithChoices;

    [Header("Talker Image")]
    [SerializeField] private Image TalkerImage;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    //Array of textmeshpro text objects that show on choice buttons
    private TextMeshProUGUI[] choicesText;
        
    [SerializeField] private Image CanContinueSprite;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private TextMeshProUGUI ContinueButtonText;


    //For handling Ink dialogue format.
    private Story currentStory;
    //private List<Text> StoryLog = new List<Text>();
    
    //Unity event for when a story ends
    //This is crucial for the progression of the dialogues in the game.
    private UnityEvent endOfStoryEvent;

    //Flag for whether a dialogue is currently being displayed or not.
    public bool dialogueIsPlaying { get; private set; }
    
    //Singleton Implementation
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
        //initial values
        dialogueIsPlaying = false;
        dialogueText = dialogueTextNoChoices;


        //Get the reference to the text part of the choice gameobjects.
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }


    //Method used by DialogueTrigger to start a dialogue.
    public void EnterDialogueMode(TextAsset inkJSON, UnityEvent EndOfStoryEvent, Sprite TalkerSprite)
    {
        //StoryLog.Clear();

        currentStory = new Story(inkJSON.text); //get the story from the inkJSON file
        endOfStoryEvent = EndOfStoryEvent;      //get the unityevent to be invoked at the end of this dialogue.
        if (TalkerSprite != null)               
        {
            TalkerImage.sprite = TalkerSprite;  //get the sprite for the talking person.
        }
            dialogueIsPlaying = true;           //Set the flag
        dialoguePanel.SetActive(true);          //enable the dialogue UI panel.

        ContinueStory();                        //Start the dialogue.
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
    }

    //Method used for progressing through the dialogue.
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string text = currentStory.Continue();
            dialogueText.text = text;
            DisplayChoices();               //Display choice options (if any)

            //TODO: CREATE A LOG OF THE STORY PROGRESSION
        }
        else
        {
            ExitDialogueMode();             //if no further dialogues exist, exit dialogue mode.
        }
    }

    private void ExitDialogueMode() //cleanup and exiting dialogue mode.
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        endOfStoryEvent.Invoke();
    }

    //Method to change the dialogue box for when there is a switch to dialogue with choices and vice versa.
    //Basically temp = x, y = temp, disable x, enable y.
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

    //check for number of choices, and decide how the dialogue options should be displayed.
    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //Usually there is only one choice, which is a basic response to progress.
        //If there are more than one choice, it means we are at a multiple choice state, and the dialogue box should change.
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


        //After the dialogue is adjusted accordingly, then the choice texts have to be filled out
        //gets the information from the list of choices (which is acquired from ink JSON)
        //sets them as the text on choice gameobjects.

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
            if(currentChoices.Count != 0)
            {
                foreach (Choice choice in currentChoices)
                {
                    ContinueButtonText.text = choice.text;
                }
            } else
            {
                ContinueButtonText.text = "Continue";
            }

        }
    }

    //Method used for making a dialogue choice
    //Called from the choice button UI elements.
    public void MakeChoice(int choiceIndex)
    {
        if(currentStory.currentChoices.Count > 0)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }        
        ContinueStory();

    }
}
