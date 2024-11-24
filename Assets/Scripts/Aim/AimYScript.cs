using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimYScript : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;

    private Vector3 _initialEulerRotation;

    private void Start()
    {
        _initialEulerRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        var mouseYInput = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        var curEulerRot = transform.rotation.eulerAngles;

        if (curEulerRot.x > 180)
            curEulerRot.x -= 360f;

        curEulerRot.x -= mouseYInput;

        curEulerRot.x = Mathf.Clamp(curEulerRot.x, _initialEulerRotation.x + minRotation, _initialEulerRotation.x + maxRotation);

        transform.rotation = Quaternion.Euler(curEulerRot);
    }
}
