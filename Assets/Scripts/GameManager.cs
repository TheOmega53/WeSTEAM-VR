using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Responsible for game state variables
//works in tandem with Sequence Manager.
//Handles player spawn locations and conditional loading scenarios.
//Game Manager is destroyed on load, but sequence manager is not. hence why sequence checks are done on sequence manager.
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

    //Initialize the scene based on what state of the game player is at.
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

    //Called by unityevents to trigger a specific sequence check (e.g. finished act1, foundbook1)
    public void TriggerSequence(string sequenceName)
    {
        sequenceManager.ActivateSequenceTrigger(sequenceName);
    }

    //Used to check if a sequence flag is true or not.
    public bool SequenceCheck(string sequenceName)
    {
        return sequenceManager.GetSequenceFlag(sequenceName);
    }
}
