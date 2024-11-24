using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Collider groundCollider;
    [SerializeField] private int numEnemiesToSpawn;
    public int NumMonstersSpawned => numEnemiesToSpawn;

    private void Start()
    {
        for (int i = 0; i < numEnemiesToSpawn; i++)
        {
            float randX = Random.Range(groundCollider.bounds.min.x, groundCollider.bounds.max.x);
            float randZ = Random.Range(groundCollider.bounds.min.z, groundCollider.bounds.max.z);
            float height = enemyPrefab.GetComponent<Collider>().bounds.extents.y;
            Instantiate(enemyPrefab, new Vector3(randX, height, randZ), Quaternion.identity);
        }
    }
}
