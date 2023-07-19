using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CustomBook : MonoBehaviour
{
    [SerializeField]
    private bool isOpen;
    private BoxCollider collider;
    private Animator animator;
    private Canvas content;
    
    private void Start()
    {
        collider = this.transform.GetComponent<BoxCollider>();
        animator = this.transform.GetComponent<Animator>();
        content = this.transform.GetComponentInChildren<Canvas>();
        UpdateCollider();
        ToggleContent();
    }
    public void OpenClose()
    {
        if (!isOpen)
        {
            UpdateCollider();
            isOpen = true;
            animator.SetTrigger("Trigger");
            
        } else
        {
            UpdateCollider();
            isOpen = false;
            animator.SetTrigger("Trigger");
        }
    }

    private void UpdateCollider()
    {
        if (this.isOpen)
        {
            collider.center = new Vector3(0, 0.0125f, 0);
            collider.size = new Vector3(0.3076485f, 0.02910475f, 0.2000001f);

        }
        else
        {
            collider.center = new Vector3(0, 0.08f, 0);
            collider.size = new Vector3(0.04f, 0.16f, 0.2f);
        }
    }

    public void ToggleContent()
    {
        Debug.Log("Toggling Content");
        if (isOpen)
        {
            content.gameObject.SetActive(true);
        } else
        {
            content.gameObject.SetActive(false);
        }
    }
}
