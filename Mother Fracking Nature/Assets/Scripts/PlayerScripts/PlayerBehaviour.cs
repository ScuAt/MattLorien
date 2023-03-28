/*****************************************************************************
// File Name :         PlayerOneBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     March 21st, 2023
//
// Brief Description : Controller for player one which includes the code to 
accompany the controller bindings in the PlayerOneActions action map.

Video on connecting two controllers for local co-op:
https://www.bing.com/videos/search?q=how+to+add+multiple+controllers+in+Unity&docid=603500616588278220&mid=DFAEA9522B82241EB683DFAEA9522B82241EB683&view=detail&FORM=VIRE
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 7;
    private Vector2 movementInput;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        //Translate() function to translate in X and Y coordinates based on the
        //speed variable and delta time, which is how long it has been since last frame.
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
    }

    /// <summary>
    ///  This function takes in a callback context as its only parameter and 
    ///  returns nothing. It's called when something happens on screen like 
    ///  pressing left on the controller.
    ///  
    ///  The InputAction.CallbackContext ctx parameter is used to 
    ///  read the input from the user and update the movementInput variable.
    /// </summary>
    /// <param name="ctx"></param>
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    /// <summary>
    /// When players start game and run into these circles they will be assigned the correct script for their role and the trigger will dissapear
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //enables the correct script for the attacker
        if (collision.tag == "AssignAttacker")
        {
            Debug.Log("You are the attacker");
            gameObject.GetComponent<AttackerBehaviour>().enabled = true;
            //destroys the object you are colliding with for this instance the assigning circle
            Destroy(collision.gameObject);
        }
        //enables the correct script for the defender
        if (collision.tag == "AssignDefender")
        {
            Debug.Log("You are the defender");
            gameObject.GetComponent<DefenderBehaviour>().enabled = true;
            //destroys the object you are colliding with
            Destroy(collision.gameObject);
        }
    }
}
