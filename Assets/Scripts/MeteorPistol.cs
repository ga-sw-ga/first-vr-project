using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    private const float MAX_SHOOT_DISTANCE = 10f;
    
    public LayerMask shootRayLayerMask;
    private ParticleSystem shootParticles;
    private Transform shootSource;
    private BreakableMeteor breakingObject;
    private AudioSource audioSource;
    private bool isShooting = false;

    private void Awake()
    {
        shootParticles = GetComponentInChildren<ParticleSystem>();
        shootSource = shootParticles.transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    private void Update()
    {
        if (isShooting)
        {
            RayCastCheck();
        }
    }

    private void StartShoot()
    {
        shootParticles.Play();
        isShooting = true;
//        AudioManager.instance.Play("Gun");
        audioSource.Play();
    }

    private void StopShoot()
    {
        shootParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        isShooting = false;
        audioSource.Stop();
    }

    private void RayCastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, MAX_SHOOT_DISTANCE, shootRayLayerMask);
        if (hasHit)
        {
            BreakableMeteor breakableMeteor = hit.transform.GetComponent<BreakableMeteor>();
            if (breakableMeteor != null)
            {
                if (breakableMeteor == breakingObject)
                {
                    breakingObject.BreakRayify();
                }
                else
                {
                    if (breakingObject != null)
                    {
                        breakingObject.StopBreaking();
                    }
                    breakingObject = hit.transform.GetComponent<BreakableMeteor>();
                }
            }
        }
    }
}
