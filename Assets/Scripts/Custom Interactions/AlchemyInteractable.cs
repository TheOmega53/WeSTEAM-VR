using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlchemyInteractable : MonoBehaviour
{
    private AlchemyInteractionManager alchemyInteractionManager;
    private bool held;
    private bool isPouring;

    [Header("When poured inside it")]
    [SerializeField] private UnityEvent pouredInEvent;

    [Header("When heated")]
    [SerializeField] private UnityEvent heatedEvent;

    [Header("When pouring")]
    [SerializeField] private UnityEvent pouringEvent;

    [Header("When stopped pouring")]
    [SerializeField] private UnityEvent pouringStoppedEvent;


    private void Start()
    {
        alchemyInteractionManager = AlchemyInteractionManager.GetInstance();
    }

    private void Update()
    {                
        if(transform.rotation.eulerAngles.x > 80 & transform.rotation.eulerAngles.x < 280)
        {
            if (!isPouring)
            {
                isPouring = true;
                PourEvent(true);
            }
            
        } else if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 280)
        {
            if (!isPouring)
            {
                isPouring = true;
                PourEvent(true);
            }
        } else
        {
            if (isPouring)
            {
                isPouring = false;
                PourEvent(false);
            }            
        }
    }

    private void PourEvent(bool ispouring)
    {
        if (ispouring)
        {
            alchemyInteractionManager.Pour(this, this.transform);
            pouringEvent.Invoke();
        } else
        {
            pouringStoppedEvent.Invoke();
        }
        
    }

    public void OnItemGrabbed()
    {
        Debug.Log(this.name + " Grabbed");
        if(held != true)
        {
            held = true;
            alchemyInteractionManager.HoldItem(this);
        }
    }

    public void OnGrabExit()
    {        
        held = false;
        alchemyInteractionManager.ReleaseItem(this);
    }

    internal void Receive()
    {
        Debug.Log("Pour Received inside: " + this.name);
        pouredInEvent.Invoke();
    }

    internal void Heat()
    {
        Debug.Log(this.name + "is being Heated");
        heatedEvent.Invoke();
    }
}
