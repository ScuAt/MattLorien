using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{


    Weapon weapon;

    public float stunTime = 5;
    public float stunEnd;
    public bool stunned = false;

    public float enemyHealth = 35;
    public float speed = 4;
    public int enemyDamage = 10;


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
            speed = 4;
            enemyDamage = 10;
            
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
