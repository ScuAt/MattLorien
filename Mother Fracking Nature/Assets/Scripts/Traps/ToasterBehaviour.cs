/*****************************************************************************
// File Name :         ToasterBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 11th, 2023
//
// Brief Description : Controls the toasters collison, damage, and destruction.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour
            enemyComponent) && collision.tag == "Enemy")
        {
            enemyComponent.TakeDamage(4);

            enemyComponent.Stunned();

            Destroy(gameObject);
        }
    }
}
