using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : EnemyBehaviour

{
    public bool attackingAttacker = false;
    public bool attackingDefender = false;
    public bool attackingTower = false;
    public bool attacking = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackingAttacker == false)
        {
            StopCoroutine(AttackerAttackCycle()); 
        }
        if(attackingDefender == false)
        {
            StopCoroutine(DefenderAttackCycle());
        }
        if(attackingTower == false)
        {
            StopCoroutine(TowerAttackCycle());
        }
        if(attackingAttacker == true && attacking == false)
        {
            StartCoroutine(AttackerAttackCycle());
        }
        if(attackingDefender == true && attacking == false)
        {
            StartCoroutine(DefenderAttackCycle());
        }
        if(attackingTower == true && attacking == false)
        {
            StartCoroutine(TowerAttackCycle());
        }

    }


    IEnumerator TowerAttackCycle()
    {
        while (attackingTower == true)
        {
            attacking = true;
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.towerHealth -= enemyDamage;

            yield return new WaitForSeconds(1f);

        }

    }

    IEnumerator AttackerAttackCycle()
    {
        while (attackingAttacker == true)
        {
            attacking = true;
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.attackerHealth -= enemyDamage;

            yield return new WaitForSeconds(1f);
        }

    }
    IEnumerator DefenderAttackCycle()
    {
        while (attackingDefender == true)
        {
            attacking = true;
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.defenderHealth -= enemyDamage;

            yield return new WaitForSeconds(1f);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.tag == "Tower")// && attacking == true)
         {
          //   StopCoroutine(TowerAttackCycle());
             attackingTower = false;
            attacking = false;
         }
         if (collision.tag == "Attacker")// && attacking ==  true)
         {
           //  StopCoroutine(AttackerAttackCycle());
             attackingAttacker = false;
            attacking = false;
         }
         if (collision.tag == "Defender")// && attacking == true)
         {
            // StopCoroutine(DefenderAttackCycle());
             attackingDefender = false;
            attacking = false;
         }
         
       // StopCoroutine(TowerAttackCycle());
       // StopCoroutine(AttackerAttackCycle());
       // StopCoroutine(DefenderAttackCycle());
       // attacking = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower")
        {
            attackingTower = true;
            //StartCoroutine(TowerAttackCycle());
            
        }
        if(collision.tag == "Attacker")
        {
            attackingAttacker = true;
            //StartCoroutine(AttackerAttackCycle());
            
        }
        if(collision.tag == "Defender")
        {
            attackingDefender = true;
            //StartCoroutine(DefenderAttackCycle());
            
        }
        
    }

    

}
