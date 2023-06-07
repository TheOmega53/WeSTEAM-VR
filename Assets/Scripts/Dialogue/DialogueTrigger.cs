using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("End Of Dialogue Event")]
    [SerializeField] private UnityEvent endOfStoryEvent;

    [Header("Talker Icon")]
    [SerializeField] private Sprite TalkerIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void TriggerDialogue()
    {        
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON,endOfStoryEvent,TalkerIcon);
    }
}
