using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCamFromPlayer : MonoBehaviour
{
    private void OnEnable()
    {
        LifeTotalScript.PlayerDied += RemoveCam;
    }

    private void OnDisable()
    {
        LifeTotalScript.PlayerDied -= RemoveCam;
    }

    private void RemoveCam()
    {
        Camera.main.gameObject.transform.parent = null;
    }
}
