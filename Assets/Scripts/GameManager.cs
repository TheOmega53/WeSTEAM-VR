using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private SequenceManager sequenceManager;
    public GameObject Player;

    [Header("Possible player spawn locations")]
    public Transform IntroSpawnPoint;
    public Transform ReturnSpawnPoint;

    [Header("Conditional Dialogue Triggers")]
    public GameObject IntroTrigger;
    public GameObject RepairTrigger;

    [Header("Conditional Interactables")]
    public GameObject RepairInteractables;

    [Header("Different Repair Dialogues")]
    public GameObject IntroRepairButton;
    public GameObject ReturnRepairButton;


    private void Start()
    {
        sequenceManager = SequenceManager.GetInstance();
        SetupScene();
    }

    private void SetupScene()
    {
        if (SceneManager.GetActiveScene().name == "SpaceShip")
        {
            SpawnPlayer();
            AdjustRepairDialogue();
        }
            
    }

    private void AdjustRepairDialogue()
    {
        if (!SequenceCheck("finishAct1"))
        {
            IntroRepairButton.SetActive(true);
            ReturnRepairButton.SetActive(false);
        } else
        {
            IntroRepairButton.SetActive(false);
            ReturnRepairButton.SetActive(true);
        }
    }

    private void SpawnPlayer()
    {        
        if (SequenceCheck("startedRepairs"))
        {
            Player.transform.position = ReturnSpawnPoint.position;
            Player.transform.rotation = ReturnSpawnPoint.rotation;

            RepairTrigger.SetActive(true);
            IntroTrigger.SetActive(false);
            RepairInteractables.SetActive(true);
        }
        else
        {                           
            Player.transform.position = IntroSpawnPoint.position;
            Player.transform.rotation = IntroSpawnPoint.rotation;

            RepairTrigger.SetActive(false);
            IntroTrigger.SetActive(true);
            RepairInteractables.SetActive(false);

        }        
    }

    public void TriggerSequence(string sequenceName)
    {
        sequenceManager.ActivateSequenceTrigger(sequenceName);
    }

    public bool SequenceCheck(string sequenceName)
    {
        return sequenceManager.GetSequenceFlag(sequenceName);
    }
}
