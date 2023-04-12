/*****************************************************************************
// File Name :         PipeBombBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 6th, 2023
//
// Brief Description : Controls the pipe bombs collison, damage, and destruction.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBombBehaviour : MonoBehaviour
{
    private float timer = 2;
    private float countdown;

    private void Start()
    {
        countdown = timer;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Debug.Log("BOOM!");
            Destroy(gameObject);
        }
    }
}
