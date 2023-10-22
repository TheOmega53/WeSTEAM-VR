using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Singleton Class responsible for handling alchemical interactions between objects.
 * As of now only two interactions exist: Pour and Heating.
 */
public class AlchemyInteractionManager : MonoBehaviour
{    
    private static AlchemyInteractionManager instance;

    //Initialize the list of interactables
    private List<AlchemyInteractable> HeldItems = new List<AlchemyInteractable>();
    private List<AlchemyHeater> HeatProviders = new List<AlchemyHeater>();


    //Interactable objects use this class to let the manager know they are being held by the player.
    public void HoldItem(AlchemyInteractable item)
    {
        HeldItems.Add(item);        
    }

    //Initialize Objects able to heat others.
    public void AddHeater(AlchemyHeater item)
    {
        HeatProviders.Add(item);
    }

    //For getting a reference of the AlchemyInteractionManager Singleton.
    public static AlchemyInteractionManager GetInstance()
    {
        return instance;
    }

    /*Simple Method for handling Pouring Interaction.
    *Checks the items in the held list and based on arguements understands which one
    *is pouring and which one is being poured in,
    *then calls the event on the item that is the receiver.
    */
    public void Pour(AlchemyInteractable pourist, Transform pourTransform)
    {
        Debug.Log("Pour Called");
        AlchemyInteractable pour_receiver = null;
        if(HeldItems.Count == 2)
        {
            foreach (AlchemyInteractable item in HeldItems)
            {
                if (item != pourist)
                {
                    pour_receiver = item;
                }
            }

            if(pour_receiver != null)
            {
                pour_receiver.Receive();
            }
        }
    }


    //For when the player releases the item
    internal void ReleaseItem(AlchemyInteractable item)
    {
        HeldItems.Remove(item);
    }


    //Singleton Implementation
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Alchemy Managers in the scene");
        }
        instance = this;
    }
}
