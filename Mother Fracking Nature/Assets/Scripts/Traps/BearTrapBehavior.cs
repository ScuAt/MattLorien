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
    private float timer = 20;
    private float countdown;

    /// <summary>
    /// Sets the timers
    /// </summary>
    private void Start()
    {
        countdown = timer;
    }

    /// <summary>
    /// If the trap is around for a while it disappears
    /// </summary>
    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Calls the enemy script and deals damage on collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour
            enemyComponent) && collision.tag == "Enemy")
        {
            enemyComponent.TakeDamage(10);
        }
    }
    
}
