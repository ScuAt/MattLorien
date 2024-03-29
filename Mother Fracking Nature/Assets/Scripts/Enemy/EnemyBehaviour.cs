/*****************************************************************************
// File Name :         EnemyBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 11th, 2023
//
// Brief Description : Controls the enemy collision, movement, health, and attack. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //public GameObject player;
    public GameObject tower;
    public GameObject bleed;

    //public GameObject barrier;

    public AudioClip enemyDeath;
    public AudioClip enemyTakeDamage;
    public AudioClip enemyNoises;

    public AudioClip bottleDamage;
    public AudioClip sawDamage;
    public AudioClip banjoDamage;
    public AudioClip bottleAbilityDamage;
   // public AudioClip sawAbilityDamage;
   // public AudioClip banjoAbilityStun;

    Weapon weapon;

    public float stunTime = 5;
    public float stunEnd;
    public bool stunned = false;

    public float enemyHealth = 10;
    public float speed = 1;
    public int enemyDamage = 5;
    public float attackPlayerDistance;
    public float defensePlayerDistance;
    public float towerDistance;

    private void Start()
    {
        //IgnoreCollision(barrier.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject barrier = GameObject.FindGameObjectWithTag("Barrier");
        Physics2D.IgnoreCollision(barrier.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        StartCoroutine(Squeaks());
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();

        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy has died");
            Bleed();
            AudioSource.PlayClipAtPoint(enemyDeath, Camera.main.transform.position);
            Destroy(this.gameObject);
        }


        //Keeps track of when enemy is stunned and able to move again
        if(stunEnd > Time.time)
        {
            speed = 0;
            enemyDamage = 0;
            

        }
        else
        {
            speed = 1;
            enemyDamage = 5;
            
        }
       

        AttackerBehaviour att = FindObjectOfType<AttackerBehaviour>();
        DefenderBehaviour def = FindObjectOfType<DefenderBehaviour>();

        if (!def && !att)
        {
            return;
        }

        Vector3 defPosition = def.transform.position;
        Vector3 attPosition = att.transform.position;

        

        attackPlayerDistance = Vector2.Distance(transform.position, attPosition);
        defensePlayerDistance = Vector2.Distance(transform.position, defPosition);
        towerDistance = Vector2.Distance(transform.position, tower.transform.position);

        //finding the direction the enemy is heading towards the players and normalizes it and simplifies it to a simple number
        Vector2 attackerDirection = attPosition - transform.position;
        attackerDirection.Normalize();
        float attackAngle = Mathf.Atan2(attackerDirection.y, attackerDirection.x) * Mathf.Rad2Deg;

        //
        Vector2 defenderDirection = defPosition - transform.position;
        defenderDirection.Normalize();
        float defendAngle = Mathf.Atan2(defenderDirection.y, defenderDirection.x) * Mathf.Rad2Deg;

        //
        Vector2 towerDirection = tower.transform.position - transform.position;
        towerDirection.Normalize();
        float towerAngle = Mathf.Atan2(towerDirection.y, towerDirection.x) * Mathf.Rad2Deg;

        if (attackPlayerDistance < 3 && gc.attackerHealth > 0 && gc.defenderHealth > 0)// && attackPlayerDistance) //< defensePlayerDistance && gc.attackerHealth > 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, attPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * attackAngle);

        }
       /* else if (defensePlayerDistance < 6  && defensePlayerDistance < attackPlayerDistance && gc.defenderHealth > 0)
         {
             transform.position = Vector2.MoveTowards(this.transform.position, defPosition, speed * Time.deltaTime);
             transform.rotation = Quaternion.Euler(Vector3.forward * defendAngle);

         } */
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, tower.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * towerAngle);
        }

        /*
        if (towerDistance <= 3)
        {
            StartCoroutine(EnemyAttackCycle());            
        }
        */

    }


    /// <summary>
    /// Stuns the enemy for a breif amount of time
    /// </summary>
    public void Stunned()
    {
        stunEnd = stunTime + Time.time;
    }

    public void Bleed()
    {
        Instantiate(bleed, transform.position, Quaternion.identity);
       
    }

    public static void IgnoreCollision(Collider2D collider, Collider2D collider2, bool ignore = true)
    {

    }

    /// <summary>
    /// This is for the trap scripts to call when the enemy walks into said trap
    /// It deals damage to the enemy
    /// </summary>
    /// <param name="damageAmount"></param>
    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
        Bleed();
    }
    /// <summary>
    /// every 5 seconds there is a 1 in 5 chance that the enemy will squeak
    /// </summary>
    /// <returns></returns>
    public IEnumerator Squeaks()
    {
        while (true)
        {
            var rand = Random.Range(0, 4);
            if(rand == 0)
            {
                AudioSource.PlayClipAtPoint(enemyNoises, Camera.main.transform.position);
            }
            yield return new WaitForSeconds(5f);
        }
        
    }


    /// <summary>
    /// This is for collision with the weapons/ special attacks. It also 
    /// deals damage to players/ the rig
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BottleMelee")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 4;
            Debug.Log("Health remaining: " + enemyHealth);
            AudioSource.PlayClipAtPoint(bottleDamage, Camera.main.transform.position);
            Bleed();
            
        }
        if (collision.tag == "SawMelee")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 12;
            Debug.Log("Health remaining: " + enemyHealth);
            AudioSource.PlayClipAtPoint(sawDamage, Camera.main.transform.position);


        }
        if (collision.tag == "BanjoMelee")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 3;
            Debug.Log("Health remaining: " + enemyHealth);
            AudioSource.PlayClipAtPoint(banjoDamage, Camera.main.transform.position);
            Bleed();

        }
        if (collision.tag == "BanjoAbility")
        {
            Stunned();
            //AudioSource.PlayClipAtPoint(banjoAbilityStun, Camera.main.transform.position);
        }
        if (collision.tag == "BottleAbility")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 15;
            Debug.Log("Health remaining: " + enemyHealth);
            AudioSource.PlayClipAtPoint(bottleAbilityDamage, Camera.main.transform.position);

        }
        if (collision.tag == "SawAbility")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 12;
            Debug.Log("Health remaining: " + enemyHealth);
           // AudioSource.PlayClipAtPoint(sawAbilityDamage, Camera.main.transform.position);

        }

        /*
        //Deals damage to players
        if (collision.gameObject.TryGetComponent<AttackerBehaviour>(out AttackerBehaviour attackerComponent) && attackPlayerDistance <= 2)
        {
            attackerComponent.AttackerTakeDamage(10);
        }

        if (collision.gameObject.TryGetComponent<DefenderBehaviour>(out DefenderBehaviour defenderComponent) && defensePlayerDistance <= 2)
        {
            defenderComponent.DefenderTakeDamage(10);
        }
        */
    }

}
