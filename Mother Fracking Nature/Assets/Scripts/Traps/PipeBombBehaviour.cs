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

    /// <summary>
    /// Sets the timer for the count down
    /// </summary>
    private void Start()
    {
        countdown = timer;
    }

    /// <summary>
    /// Explodes
    /// </summary>
    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Debug.Log("BOOM!");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Deals damage to the enemy
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour
            enemyComponent) && collision.tag == "Enemy")
        {
            enemyComponent.TakeDamage(10);

            Destroy(gameObject);
        }
    }

}
