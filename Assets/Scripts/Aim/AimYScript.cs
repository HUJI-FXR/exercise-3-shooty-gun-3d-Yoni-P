using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimYScript : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;

    private void Update()
    {
        var mouseYInput = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mouseYInput = Mathf.Clamp(mouseYInput, minRotation, maxRotation);

        transform.rotation = Quaternion.Euler(-mouseYInput, 0, 0);
    }
}
