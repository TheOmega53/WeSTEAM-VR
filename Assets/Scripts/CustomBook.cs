using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CustomBook : MonoBehaviour
{
    [SerializeField]
    private bool isOpen;
    private BoxCollider bookCollider;
    private Animator animator;
    
    private void Start()
    {
        bookCollider = this.transform.GetComponent<BoxCollider>();
        animator = this.transform.GetComponent<Animator>();
        UpdateCollider();
    }
    public void OpenClose()
    {
        if (!isOpen)
        {
            isOpen = true;
            UpdateCollider();
            animator.SetTrigger("Trigger");
            
        } else
        {
            isOpen = false;
            UpdateCollider();
            animator.SetTrigger("Trigger");
        }
    }

    private void UpdateCollider()
    {
        if (this.isOpen)
        {
            bookCollider.center = new Vector3(0, 0.0125f, 0);
            bookCollider.size = new Vector3(0.3076485f, 0.02910475f, 0.2000001f);

        }
        else
        {
            bookCollider.center = new Vector3(0, 0.08f, 0);
            bookCollider.size = new Vector3(0.04f, 0.16f, 0.2f);
        }
    }
}
