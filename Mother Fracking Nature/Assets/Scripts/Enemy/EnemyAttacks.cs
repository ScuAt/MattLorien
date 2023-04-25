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
        yield return new WaitForSeconds(2f);
        GameController gc = FindObjectOfType<GameController>();
        gc.towerHealth -= enemyDamage;
        
    }

    IEnumerator AttackerAttackCycle()
    {
        yield return new WaitForSeconds(2f);
        GameController gc = FindObjectOfType<GameController>();
        gc.attackerHealth -= enemyDamage;

    }
    IEnumerator DefenderAttackCycle()
    {
        yield return new WaitForSeconds(2f);
        GameController gc = FindObjectOfType<GameController>();
        gc.defenderHealth -= enemyDamage;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower" && attacking == false)
        {
            StartCoroutine(TowerAttackCycle());
        }
        if(collision.tag == "Attacker" && attacking == false)
        {
            StartCoroutine(AttackerAttackCycle());
        }
        if(collision.tag == "Defender" && attacking == false)
        {
            StartCoroutine(DefenderAttackCycle());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tower" && attacking == true)
        {
            StopCoroutine(TowerAttackCycle());
        }
        if (collision.tag == "Attacker" && attacking ==  true)
        {
            StopCoroutine(AttackerAttackCycle());
        }
        if (collision.tag == "Defender" && attacking == true)
        {
            StopCoroutine(DefenderAttackCycle());
        }
    }

}
