using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SequenceManager : MonoBehaviour
{

    private static SequenceManager instance;

    public static event Action intro;
    public static event Action startedRepairs; 
    public static event Action startedAct1;
    public static event Action foundBook;
    public static event Action pouredFlask;
    public static event Action heatedFlask;
    public static event Action finishAct1;
    public static event Action finishedRepair;

    public static Dictionary<string, Action> SequenceEvents = new Dictionary<string, Action>()
    {
        ["intro"] = intro,
        ["startedRepairs"] = startedRepairs,
        ["startedAct1"] = startedAct1,
        ["foundBook"] = foundBook,
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
        ["foundBook"] = false,
        ["pouredFlask"] = false,
        ["heatedFlask"] = false,
        ["finishAct1"] = false,
        ["finishedRepair"] = false
    };

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

