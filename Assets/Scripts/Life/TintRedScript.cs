using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintRedScript : MonoBehaviour
{
    [SerializeField] private Renderer renderer;

    private LifeTotalScript _lifeTotalScript;
    
    private void Start()
    {
        renderer.material = Instantiate(renderer.material);
        _lifeTotalScript = GetComponent<LifeTotalScript>();
    }

    private void Update()
    {
        var lifeTotalRatio = _lifeTotalScript.GetLifeRatio();

        renderer.material.color = lifeTotalRatio * Color.white + (1f - lifeTotalRatio) * Color.red;
    }
}
