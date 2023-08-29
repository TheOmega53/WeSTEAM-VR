using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SequenceEvent : MonoBehaviour
{
    public string[] DisallowingSequenceConditions;
    public string[] AllowingSequenceConditions;
    public UnityEvent Event;

    private SequenceManager sequenceManager;

    private void Start()
    {
        sequenceManager = SequenceManager.GetInstance();
    }

    public void PerformCheckedEvent()
    {
        bool allowed = true;
        foreach (string condition in AllowingSequenceConditions)
        {
            if (!sequenceManager.GetSequenceFlag(condition))
            {
                Debug.Log("event not allowed");
                allowed = false;
            }
        }

        foreach (string condition in DisallowingSequenceConditions)
        {
            if (sequenceManager.GetSequenceFlag(condition))
            {
                Debug.Log("event disallowed");
                allowed = false;
            }
        }

        if (allowed)
        {
            Debug.Log("event allowed, invoking");
            Event.Invoke();
        }
    }
}
