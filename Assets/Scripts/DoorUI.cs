using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUI : MonoBehaviour
{
    [SerializeField] private GameObject[] OpenButtons;
    [SerializeField] private GameObject[] CloseButtons;

    [SerializeField] private bool isOpen;

    [SerializeField] private Animator animator;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void OpenClose()
    {
        isOpen = !isOpen;

        animator.SetBool("isOpen", isOpen);
        audioSource?.Play();

        foreach (var button in OpenButtons)
        {
            button.gameObject.SetActive(!isOpen);
        }

        foreach (var button in CloseButtons)
        {
            button.gameObject.SetActive(isOpen);
        }           
    }
}
