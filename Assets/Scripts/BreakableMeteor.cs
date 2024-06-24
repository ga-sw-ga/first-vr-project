using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableMeteor : MonoBehaviour
{
    private const float BREAK_TIME = 2f;
    
    private List<GameObject> pieces;
    private Material material;
    private Color emissionColor = Color.black;
    private float timer = BREAK_TIME;
    private bool isBreaking;

    private void Awake()
    {
        pieces = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            pieces.Add(transform.GetChild(i).gameObject);
        }

        material = new Material(GetComponent<MeshRenderer>().material);
        GetComponent<MeshRenderer>().material = material;
    }

    void Start()
    {
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isBreaking)
        {
            timer = Mathf.Min(timer + Time.deltaTime, BREAK_TIME);
        }
        else
        {
            timer = Mathf.Max(timer - Time.deltaTime, 0f);
        }

        emissionColor = new Color(1f - (timer / BREAK_TIME), 0f, 0f, 1f);
        // print(material.GetColor("_EmissionColor").r);
        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", emissionColor);

        isBreaking = false;
    }

    public void BreakRayify()
    {
        isBreaking = true;
        timer = Mathf.Max(timer - Time.deltaTime, 0f);
        if (timer == 0f)
        {
            Break();
        }
    }

    public void StopBreaking()
    {
        isBreaking = false;
    }

    private void Break()
    {
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true);
            piece.transform.parent = transform.parent;
        }
        
        gameObject.SetActive(false);
    }
}
