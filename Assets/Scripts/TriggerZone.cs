using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnterEvent;

    [SerializeField] private string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}
