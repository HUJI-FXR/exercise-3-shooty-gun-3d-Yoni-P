using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTracker : MonoBehaviour
{
    public static Action AllEnemiesDead;
    private static int _numEnemies = 0;

    private void Start()
    {
        _numEnemies++;
    }

    private void OnDestroy()
    {
        _numEnemies--;
        if (_numEnemies <= 0)
            AllEnemiesDead?.Invoke();
    }
}
