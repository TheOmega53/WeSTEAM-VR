using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Singleton Class for handling game sequences.
//Contains a list of gameplay flags and the respective actions related to them.
//It's messy I know, but it works

public class SequenceManager : MonoBehaviour
{

    private static SequenceManager instance;

    public static event Action intro;
    public static event Action startedRepairs; 
    public static event Action startedAct1;
    public static event Action foundBook1;
    public static event Action foundBook2;
    public static event Action foundBook3;
    public static event Action Solved1;
    public static event Action Solved2;
    public static event Action Solved3;
    public static event Action pouredFlask;
    public static event Action heatedFlask;
    public static event Action finishAct1;
    public static event Action finishedRepair;

    public static Dictionary<string, Action> SequenceEvents = new Dictionary<string, Action>()
    {
        ["intro"] = intro,
        ["startedRepairs"] = startedRepairs,
        ["startedAct1"] = startedAct1,
        ["foundBook1"] = foundBook1,
        ["foundBook2"] = foundBook2,
        ["foundBook3"] = foundBook3,
        ["Solved1"] = Solved1,
        ["Solved2"] = Solved2,
        ["Solved3"] = Solved3,
        ["pouredFlask"] = pouredFlask,
        ["heatedFlask"] = heatedFlask,
        ["finishAct1"] = finishAct1,
        ["finishedRepair"] = finishedRepair
    };

    public Dictionary<String, bool> SequenceFlags = new Dictionary<String, bool>()
    {

        //all should be defaulted to false
        ["intro"] = false,
        ["startedRepairs"] = false,
        ["startedAct1"] = false,
        ["foundBook1"] = false,
        ["foundBook2"] = false,
        ["foundBook3"] = false,
        ["Solved1"] = false,
        ["Solved2"] = false,
        ["Solved3"] = false,
        ["pouredFlask"] = false,
        ["heatedFlask"] = false,
        ["finishAct1"] = false,
        ["finishedRepair"] = false
    };
    

    //Singleton Implementation
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Found more than one Sequence Manager in the scene, destroying: "+ gameObject.name);
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
        

        DontDestroyOnLoad(this.gameObject);
    }
    public static SequenceManager GetInstance()
    {
        return instance;
    }


    //called whenever a sequence flag is triggered,
    //changes the flag to true, and invokes the respective action.
    //objects can subscribe to this action list by using the SequenceListener class.
    public void ActivateSequenceTrigger(string sequenceName)
    {
        if (SequenceEvents.ContainsKey(sequenceName))
        {
            Debug.Log("The sequence called " + sequenceName + " was activated.");
            Action action = SequenceEvents[sequenceName];
            if (action != null) {
                action.Invoke();
            } else
            {
                Debug.LogWarning("the action for sequence " + sequenceName + "was empty, nothing invoked");
            }
            SequenceFlags[sequenceName] = true;

        }
        else
        {
            Debug.LogError("Sequence with name: " + sequenceName + " was not found");
        }
    }


    //for getting the state of a specific flag.
    public bool GetSequenceFlag(string sequenceName)
    {
        if (SequenceFlags.ContainsKey(sequenceName))
        {
            if (SequenceFlags[sequenceName])
            {
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            Debug.LogError("Sequence Flag with name: \"" + sequenceName + "\" does not exist");
            return false;
        }
        
    }

}

