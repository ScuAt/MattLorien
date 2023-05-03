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
    /*
    private float timer = 20;
    private float countdown;
    */

    public AudioClip toasterDamage;
    /// <summary>
    /// Sets timer for count down
    /// </summary>
    private void Start()
    {
        //countdown = timer;
    }

    //If the trap is around for a long time is disappears
    private void Update()
    {
        /*
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
        */
    }

    /// <summary>
    /// Deals damage to the enemy and stuns enemy as well
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour
            enemyComponent) && collision.tag == "Enemy")
        {
            enemyComponent.TakeDamage(5);
            AudioSource.PlayClipAtPoint(toasterDamage, Camera.main.transform.position);
            enemyComponent.Stunned();

            Destroy(gameObject);
        }
    }
}
