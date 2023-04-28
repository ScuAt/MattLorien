/*****************************************************************************
// File Name :         DestroyBlood.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 25th, 2023
//
// Brief Description : Destroys particles
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlood : MonoBehaviour
{
    

    // Destroys blood after 2 seconds
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
