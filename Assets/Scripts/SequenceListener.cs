using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class SequenceListener : MonoBehaviour
{
    public string SequenceName;
    public UnityEvent SequenceTriggeredEvent;
    private SequenceManager sequenceManager;

    private void Start()
    {
        sequenceManager = SequenceManager.GetInstance();
        SequenceManager.Sequences[SequenceName] += InvokeEvent;
    }
    private void InvokeEvent()
    {
        Debug.Log("invoking unityevent on listener " + gameObject.name);
        SequenceTriggeredEvent.Invoke();
    }

}
