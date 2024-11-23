using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimXScript : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;

    private void Update()
    {
        var mouseXInput = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        var curEulerRot = transform.rotation.eulerAngles;

        curEulerRot.y += mouseXInput;
        
        transform.rotation = Quaternion.Euler(curEulerRot);
    }
}
