using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



//Simple class for creating collider trigger events.
//Invokes a unityevent on collision with player.
[RequireComponent(typeof(Collider))]
public class CollisionTrigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TriggerEvent.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
