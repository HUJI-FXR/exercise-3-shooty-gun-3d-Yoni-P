using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    [SerializeField] private String targetTag;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag) &&
            other.gameObject.TryGetComponent<LifeTotalScript>(out var lifeTotalScript))
        {
            lifeTotalScript.ReduceLife(Random.Range(minDamage, maxDamage));
            
            Destroy(gameObject);
        }
    }
}
