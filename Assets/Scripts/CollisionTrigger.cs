using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionTrigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;

    private void OnCollisionEnter(Collision collision)
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
