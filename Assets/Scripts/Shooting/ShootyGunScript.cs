using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed;
    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonUp(0))
            Shoot();
    }

    private void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab, spawnPoint.position, bulletPrefab.transform.rotation);
        newBullet.transform.rotation *= transform.rotation;
        var newBulletRigidBody = newBullet.GetComponent<Rigidbody>();
        
        newBullet.SetActive(true);
        
        var velocityDir = transform.forward;
        newBulletRigidBody.velocity = velocityDir * bulletSpeed;
    }
}
