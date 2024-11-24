using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBarScript : MonoBehaviour
{
    [SerializeField] private LifeTotalScript lifeTotalScript;

    private TextMeshProUGUI _lifeBarText;

    private void Start()
    {
        _lifeBarText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _lifeBarText.text = "HP: " + Mathf.Max(0f, lifeTotalScript.LifeTotal);
    }
}
