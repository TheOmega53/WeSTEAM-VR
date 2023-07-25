using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyHeater : MonoBehaviour
{
    private AlchemyInteractionManager alchemyInteractionManager;
    private AlchemyInteractable HeatedItem;

    public ParticleSystem heatParticles;
    // Start is called before the first frame update
    void Start()
    {
        alchemyInteractionManager = AlchemyInteractionManager.GetInstance();
        alchemyInteractionManager.AddHeater(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        HeatedItem = other.gameObject.GetComponent<AlchemyInteractable>();
        if (HeatedItem != null)
        {
            Debug.Log("heating started");
            StartCoroutine(Heat());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (HeatedItem == other)
        {
            Debug.Log("heating stopped");
            StopCoroutine(Heat());
            HeatedItem = null;
        }
    }

    private IEnumerator Heat()
    {
        heatParticles.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        heatParticles.gameObject.SetActive(false);
        HeatedItem.Heat();
    }
}
