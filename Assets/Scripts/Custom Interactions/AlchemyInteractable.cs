using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlchemyInteractable : MonoBehaviour
{
    private AlchemyInteractionManager alchemyInteractionManager;
    private bool held;

    [Header("When poured inside it")]
    [SerializeField] private UnityEvent pouredInEvent;

    [Header("When heated")]
    [SerializeField] private UnityEvent heatedEvent;


    private void Start()
    {
        alchemyInteractionManager = AlchemyInteractionManager.GetInstance();
    }

    private void Update()
    {                
        if(transform.rotation.eulerAngles.x > 80 & transform.rotation.eulerAngles.x < 280)
        {
            alchemyInteractionManager.Pour(this, this.transform);
        } else if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 280)
        {
            alchemyInteractionManager.Pour(this, this.transform);
        }
    }

    public void OnItemGrabbed()
    {
        Debug.Log("Item Grabbed");
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
        Debug.Log("Pour Received");
        pouredInEvent.Invoke();
    }

    internal void Heat()
    {
        Debug.Log("Being Heated");
        heatedEvent.Invoke();
    }
}
