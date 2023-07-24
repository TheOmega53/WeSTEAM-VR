using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SequenceEvent : MonoBehaviour
{
    public string[] SequenceConditions;
    public UnityEvent Event;

    private SequenceManager sequenceManager;

    private void Start()
    {
        sequenceManager = SequenceManager.GetInstance();
    }

    public void PerformCheckedEvent()
    {
        bool allowed = true;
        foreach (string condition in SequenceConditions)
        {
            if (!sequenceManager.GetSequenceFlag(condition))
            {
                allowed = false;
            }
        }

        if (allowed)
        {
            Event.Invoke();
        }
    }
}
