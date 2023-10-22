using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * This class is used for any objects in the alchemy lab that can act as a heater.
 * The Interaction is controlled by the AlchemyInteractionManager Singleton
 */
public class AlchemyHeater : MonoBehaviour
{
    //Reference to AlchemyInteractionManager.
    private AlchemyInteractionManager alchemyInteractionManager;
    //Reference to the item that is being heated.
    private AlchemyInteractable HeatedItem;
    //Particle System for Smoke or other effects.
    public ParticleSystem heatParticles;
    
    void Start()
    {
        alchemyInteractionManager = AlchemyInteractionManager.GetInstance();
        alchemyInteractionManager.AddHeater(this);
    }

    //When another AlchemyInteractable gameobject enters this collider.
    private void OnTriggerEnter(Collider other)
    {
        HeatedItem = other.gameObject.GetComponent<AlchemyInteractable>();
        if (HeatedItem != null)
        {
            StartCoroutine(Heat());  //Start heating procedure
        }
    }

    //When the AlchemyInteractable gameobject leaves this collider.
    private void OnTriggerExit(Collider other)
    {
        if (HeatedItem == other)
        {            
            StopCoroutine(Heat());
            HeatedItem = null;
        }
    }

    private IEnumerator Heat()
    {
        heatParticles.gameObject.SetActive(true); //Start the smoke
        yield return new WaitForSeconds(3);       //Wait for an arbitrary amount of time
        HeatedItem.Heat();                        //Invoke the Heat event on the object
    }
}
