using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnterEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}
