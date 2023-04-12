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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour
            enemyComponent) && collision.tag == "Enemy")
        {
            enemyComponent.TakeDamage(9);

            Destroy(gameObject);
        }
    }
}
