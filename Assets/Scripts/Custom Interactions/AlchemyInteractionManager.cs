using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyInteractionManager : MonoBehaviour
{

    private static AlchemyInteractionManager instance;

    private List<AlchemyInteractable> HeldItems = new List<AlchemyInteractable>();
    private List<AlchemyHeater> HeatProviders = new List<AlchemyHeater>();

    public void HoldItem(AlchemyInteractable item)
    {
        HeldItems.Add(item);
        Debug.Log("item added" + item.name);
    }

    public void AddHeater(AlchemyHeater item)
    {
        HeatProviders.Add(item);
    }
    public static AlchemyInteractionManager GetInstance()
    {
        return instance;
    }

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

    internal void ReleaseItem(AlchemyInteractable item)
    {
        HeldItems.Remove(item);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }
}
