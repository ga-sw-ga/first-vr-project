using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetBool("character_nearby", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("character_nearby", false);
    }
    
    public void ToggleDoor()
    {
        animator.SetBool("character_nearby", !animator.GetBool("character_nearby"));
    }
}
