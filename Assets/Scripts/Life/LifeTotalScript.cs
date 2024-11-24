using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTotalScript : MonoBehaviour
{
    [SerializeField] private float initialLifeTotal = 100f;

    private float _lifeTotal;

    private void Start()
    {
        _lifeTotal = initialLifeTotal;
    }

    public void ReduceLife(float amount)
    {
        _lifeTotal -= amount;

        if (_lifeTotal < 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetLifeRatio()
    {
        return _lifeTotal / initialLifeTotal;
    }
}
