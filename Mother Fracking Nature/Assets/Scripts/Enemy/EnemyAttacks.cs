/*****************************************************************************
// File Name :         EnemyAttacks.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 24th, 2023
//
// Brief Description : Checks who is in collision range and starts attack coroutines based on that. Stops them when they leave
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : EnemyBehaviour

{
    public bool attackingAttacker = false;
    public bool attackingDefender = false;
    public bool attackingTower = false;
    public bool attacking = false;

    public AudioClip attackerTakeDamage;
    public AudioClip defenderTakeDamage;
    public AudioClip towerTakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Checks who is in attack range and activates or stops coroutines based on that
    /// </summary>
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

    /// <summary>
    /// Deals damage every 2 seconds to the tower
    /// </summary>
    /// <returns></returns>
    IEnumerator TowerAttackCycle()
    {
        while (attackingTower == true)
        {
            attacking = true;
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.towerHealth -= enemyDamage;
            AudioSource.PlayClipAtPoint(towerTakeDamage, Camera.main.transform.position);
            yield return new WaitForSeconds(1f);

        }

    }

    /// <summary>
    /// deals damage every 2 seconds to the attacker
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackerAttackCycle()
    {
        while (attackingAttacker == true)
        {
            attacking = true;
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.attackerHealth -= enemyDamage;
            AudioSource.PlayClipAtPoint(attackerTakeDamage, Camera.main.transform.position);
            yield return new WaitForSeconds(1f);
        }

    }
    /// <summary>
    /// deals damage every 2 seconds to the defender
    /// </summary>
    /// <returns></returns>
    IEnumerator DefenderAttackCycle()
    {
        while (attackingDefender == true)
        {
            attacking = true;
            yield return new WaitForSeconds(1f);
            GameController gc = FindObjectOfType<GameController>();
            gc.defenderHealth -= enemyDamage;
            AudioSource.PlayClipAtPoint(defenderTakeDamage, Camera.main.transform.position);
            yield return new WaitForSeconds(1f);

        }

    }

    /// <summary>
    /// checks what enters trigger range and changes bool based on that
    /// </summary>
    /// <param name="collision"></param>
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
    /// <summary>
    /// checks who exits trigger range and changes bool accordingly
    /// </summary>
    /// <param name="collision"></param>
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
