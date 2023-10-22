using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/* 
 * This class handles all the interactable objects in the lab.
 * functionality is mostly intended for potions.
 * there are two interactions as of now: pouring and heated.
 * All interactions are handled by unity events, and set up within the editor.
 */
public class AlchemyInteractable : MonoBehaviour
{
    //Reference to interaction manager singleton.
    private AlchemyInteractionManager alchemyInteractionManager;

    //these flags determine the state of the object in players hand
    private bool held;
    private bool isPouring;

    //Following unity events handle the interactions as mentioned in their headers
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
        //Check if object is rotated enough to trigger pouring flag.
        //Check along the x axis
        if(transform.rotation.eulerAngles.x > 80 & transform.rotation.eulerAngles.x < 280)
        {
            if (!isPouring)
            {
                isPouring = true;
                PourEvent(true);
            }
        } //Else check along the z axis   
        else if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 280)
        {
            if (!isPouring)
            {
                isPouring = true;
                PourEvent(true);
            }
        } else //if x and z rotations are not in the threshhold, then it's not pouring.
        {
            if (isPouring)
            {
                isPouring = false;
                PourEvent(false);
            }            
        }
    }

    //note that this code is very simple and the most basic functionality was intended.
    //feel free to change as needed.


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

    //Called by the GrabInteractable Unity Events
    public void OnItemGrabbed()
    {
        Debug.Log(this.name + " Grabbed");
        if(held != true)
        {
            held = true;
            alchemyInteractionManager.HoldItem(this);
        }
    }

    //Called by the GrabInteractable Unity Events
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
