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
