/*****************************************************************************
// File Name :         BottleAbilityBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 20th, 2023
//
// Brief Description : Controls the movment for the bottle ability that is thrown
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleAbilityBehaviour : MonoBehaviour
{

    public GameObject target;

    public float projectileSpeed;
    
    private Quaternion rotation;
    

    


    /// <summary>
    /// finds the bottle target and sets it equal to targets
    /// </summary>
    void Start()
    {

        target = GameObject.Find("BottleTarget");
        



    }

    /// <summary>
    /// moves the bottle with the movement of the right stick
    /// </summary>
    void Update()
    {


        // rb2D.velocity = new Vector2(aB.velocityX, aB.velocityY);
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
        //  Debug.Log("Aim x = " + aB.velocityX + "Aim y = " + aB.velocityY);


    }

    /// <summary>
    /// checks if the bottle collides with an enemy or the barrier and destroys it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Enemy" || collision.tag == "Barrier")
            {
            //destroys the object you are colliding with for this instance the assigning circle
            Destroy(this.gameObject);
            }
    }



}
