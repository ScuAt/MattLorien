using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   

    //public GameObject player;
    public GameObject tower;
    


    Weapon weapon;

    public float stunTime = 5;
    public float stunEnd;
    public bool stunned = false;

    public float enemyHealth = 35;
    public float speed = 1;
    public int enemyDamage = 10;
    public float attackPlayerDistance;
    public float defensePlayerDistance;
    public float towerDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Debug.Log("Enemy has died");
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
            enemyDamage = 10;
            
        }

        AttackerBehaviour att = FindObjectOfType<AttackerBehaviour>();
        DefenderBehaviour def = FindObjectOfType<DefenderBehaviour>();

        Vector3 defPosition = def.transform.position;
        Vector3 attPosition = att.transform.position;

        

        attackPlayerDistance = Vector2.Distance(transform.position, attPosition);
        defensePlayerDistance = Vector2.Distance(transform.position, defPosition);
        towerDistance = Vector2.Distance(transform.position, tower.transform.position);
        //finding the direction the enemy is heading towards the players and normalizes it and simplifies it to a simple number
        Vector2 attackerDirection = attPosition - transform.position;
        attackerDirection.Normalize();
        float attackAngle = Mathf.Atan2(attackerDirection.y, attackerDirection.x) * Mathf.Rad2Deg;
        Vector2 defenderDirection = defPosition - transform.position;
        defenderDirection.Normalize();
        float defendAngle = Mathf.Atan2(defenderDirection.y, defenderDirection.x) * Mathf.Rad2Deg;
        Vector2 towerDirection = tower.transform.position - transform.position;
        towerDirection.Normalize();
        float towerAngle = Mathf.Atan2(towerDirection.y, towerDirection.x) * Mathf.Rad2Deg;

        if (attackPlayerDistance < 4 ) //&& attackPlayerDistance < defensePlayerDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, attPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * attackAngle);

        }
        /* else if (defensePlayerDistance < 4  && defensePlayerDistance < attackPlayerDistance)
         {
             transform.position = Vector2.MoveTowards(this.transform.position, defPosition, speed * Time.deltaTime);
             transform.rotation = Quaternion.Euler(Vector3.forward * defenseAngle);

         } */
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, tower.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * towerAngle);
        }






        


    }

    public void Stunned()
    {
        stunEnd = stunTime + Time.time;
    }


    /// <summary>
    /// This is for the trap scripts to call when the enemy walks into said trap
    /// </summary>
    /// <param name="damageAmount"></param>
    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BottleMelee")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 6;
            Debug.Log("Health remaining: " + enemyHealth);
            
        }
        if (collision.tag == "SawMelee")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 9;
            Debug.Log("Health remaining: " + enemyHealth);

        }
        if (collision.tag == "BanjoMelee")
        {
            Debug.Log("Enemy took damage");
            enemyHealth -= 4;
            Debug.Log("Health remaining: " + enemyHealth);

        }
        if (collision.tag == "BanjoAbility")
        {
            Stunned();
        }

    }
}
