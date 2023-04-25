using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : EnemyBehaviour

{
    public bool attacking = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator TowerAttackCycle()
    {
        while (attacking)
        {

            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.towerHealth -= enemyDamage;

            yield return new WaitForSeconds(1f);

        }

    }

    IEnumerator AttackerAttackCycle()
    {
        while (attacking)
        {
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.attackerHealth -= enemyDamage;

            yield return new WaitForSeconds(1f);
        }

    }
    IEnumerator DefenderAttackCycle()
    {
        while (attacking)
        {
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.defenderHealth -= enemyDamage;

            yield return new WaitForSeconds(1f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower")
        {
            attacking = true;
            StartCoroutine(TowerAttackCycle());
            
        }
        if(collision.tag == "Attacker")
        {
            attacking = true;
            StartCoroutine(AttackerAttackCycle());
            
        }
        if(collision.tag == "Defender")
        {
            attacking = true;
            StartCoroutine(DefenderAttackCycle());
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /* if (collision.tag == "Tower")// && attacking == true)
         {
             StopCoroutine(TowerAttackCycle());
             attacking = false;
         }
         if (collision.tag == "Attacker")// && attacking ==  true)
         {
             StopCoroutine(AttackerAttackCycle());
             attacking = false;
         }
         if (collision.tag == "Defender")// && attacking == true)
         {
             StopCoroutine(DefenderAttackCycle());
             attacking = false;
         }
         */
        StopCoroutine(TowerAttackCycle());
        StopCoroutine(AttackerAttackCycle());
        StopCoroutine(DefenderAttackCycle());
        attacking = false;

    }

}
