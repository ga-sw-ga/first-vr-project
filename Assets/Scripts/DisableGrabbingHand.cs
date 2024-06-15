using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
    
public class DisableGrabbingHand : MonoBehaviour
{
    private GameObject leftHandModel;
    private GameObject rightHandModel;

    private void Awake()
    {
        leftHandModel = GameObject.FindGameObjectWithTag("LeftHand").transform.GetChild(0).gameObject;
        rightHandModel = GameObject.FindGameObjectWithTag("RightHand").transform.GetChild(0).gameObject;
    }

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.parent.CompareTag("LeftHand"))
        {
            leftHandModel.SetActive(false);
        }
        else if (args.interactorObject.transform.parent.CompareTag("RightHand"))
        {
            rightHandModel.SetActive(false);
        }
    }

    void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            leftHandModel.SetActive(true);
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            rightHandModel.SetActive(true);
        }
    }
}
