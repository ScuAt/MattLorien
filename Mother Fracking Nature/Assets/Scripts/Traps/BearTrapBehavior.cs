/*****************************************************************************
// File Name :         BearTrapBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 6th, 2023
//
// Brief Description : Controls the bear traps collison, damage, and destruction.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapBehavior : MonoBehaviour
{   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Debug.Log("Bear trap activated");
        }
    }
}
