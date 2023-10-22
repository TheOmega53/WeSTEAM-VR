using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


//Class used by gameobjects to listen to a sequence.
//can Invoke an event if that sequence flag was changed to true.
public class SequenceListener : MonoBehaviour
{
    public string SequenceName;
    public UnityEvent SequenceTriggeredEvent;
    private SequenceManager sequenceManager;
    
    private void Start()
    {
        //Get reference to sequencemanager singleton.
        sequenceManager = SequenceManager.GetInstance();
        //subscribe to the sequence action.
        SequenceManager.SequenceEvents[SequenceName] += InvokeEvent;

        //if flag is already true, then invoke the event immediately.
        if (sequenceManager.GetSequenceFlag(SequenceName))
        {
            InvokeEvent();
        }
    }
    private void InvokeEvent()
    {
        Debug.Log("invoking unityevent on listener " + gameObject.name);
        SequenceTriggeredEvent.Invoke();
    }

    private void OnDestroy()
    {
        SequenceManager.SequenceEvents[SequenceName] -= InvokeEvent;
    }
}
