using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OutsideSpace : MonoBehaviour
{
    private const float DEFAULT_FORWARD_SPEED = 2f,
                        MAX_BOOST_SPEED = 6f,
                        SIDE_SPEED = 2f,
                        FORWARD_ACCELERATION = 1f,
                        SIDE_ACCELERATION = 2f;
    
    public XRLever lever;
    public XRKnob knob;
    public XRSlider slider;

    private float forwardVelocity, sideVelocity;

    private void Update()
    {
        float targetForwardVelocity = (lever.value ? 1 : 0) * (slider.value * (MAX_BOOST_SPEED - DEFAULT_FORWARD_SPEED) + DEFAULT_FORWARD_SPEED);
        float targetSideVelocity = SIDE_SPEED * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        float forwardVelocityStep = Mathf.Min(Mathf.Max(-1f * FORWARD_ACCELERATION, targetForwardVelocity - forwardVelocity), FORWARD_ACCELERATION) * Time.deltaTime;
        float sideVelocityStep = Mathf.Min(Mathf.Max(-1f * SIDE_ACCELERATION, targetSideVelocity - sideVelocity), SIDE_ACCELERATION) * Time.deltaTime;
        
        forwardVelocity = Mathf.Min(Mathf.Max(0f, forwardVelocity + forwardVelocityStep), MAX_BOOST_SPEED);
        sideVelocity = Mathf.Min(Mathf.Max(-1f * SIDE_SPEED, sideVelocity + sideVelocityStep), SIDE_SPEED);

        Vector3 velocity = new Vector3(sideVelocity, 0f, forwardVelocity);
        transform.position += velocity * Time.deltaTime;
    }
}
