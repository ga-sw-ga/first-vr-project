using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GiantMeteor : MonoBehaviour
{
    private const float INITIAL_TORQUE_INTENSITY = 0.075f,
                        NOISE_RANGE = 0.025f;
    
    private void Start()
    {
        GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere.normalized * (INITIAL_TORQUE_INTENSITY +
            (Random.value - 0.5f) * NOISE_RANGE), ForceMode.VelocityChange);
    }
}
