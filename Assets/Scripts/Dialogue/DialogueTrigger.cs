using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Responsible for initiating Dialogues.
//Contains initialization information and reference to the respective inkJSON file.
public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("End Of Dialogue Event")]
    [SerializeField] private UnityEvent endOfStoryEvent;

    [Header("Talker Icon")]
    [SerializeField] private Sprite TalkerIcon;


    //Usually called by other unity events. e.g. end of dialogue events.
    public void TriggerDialogue()
    {        
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON,endOfStoryEvent,TalkerIcon);
    }
}
