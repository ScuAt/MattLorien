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
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    InputActionAsset inputAsset;
    InputActionMap playerControls;
    InputAction move;
    InputAction rotate;
    InputAction startGame;
    InputAction howToGuide;
    
    public float speed = 7;
    public bool isDown = false;
    


    private Vector2 movementInput;
    public Vector2 aim;
    //variable that holds the value of the last known z rotation value for the player
    public Vector3 old_rotation;
    
 
    
  
    /// <summary>
    /// Adds the player controls and actions into the level when loaded
    /// </summary>
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        playerControls = inputAsset.FindActionMap("PlayerActions");
        move = playerControls.FindAction("Move");
        rotate = playerControls.FindAction("Rotate");

        move.performed += contx => movementInput = contx.ReadValue<Vector2>();
        move.canceled += contx => movementInput = Vector2.zero;
        rotate.performed += contx => aim = contx.ReadValue<Vector2>();
        rotate.canceled += contx => aim = Vector2.zero;

        startGame = playerControls.FindAction("StartGame");
        startGame.performed += ctx => playGame();

        howToGuide = playerControls.FindAction("HowToGuide");
        howToGuide.performed += ctx => HowToMenu();

    }


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void FixedUpdate()
    {
        //Translate() function to translate in X and Y coordinates based on the
        //speed variable and delta time, which is how long it has been since last frame.
        //  transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
        Vector2 movementVelocity = new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime;
        transform.Translate(movementVelocity, Space.World);

        //math involved in converting the x and y coordinates to degrees on a circle or radians that can then be modded
        //to find an acceptable number between 0 and 359 for the player to rotate to
        //the degrees is then input into a vector three where x and y are zero so the object rotates on the z axis
        float degrees = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
       // Debug.Log(aim.y + " = Aim y " + aim.x + " = Aim x");
        degrees = (degrees + 360) % 360;
        Vector3 playerRotation = new(0, 0, degrees);
        //Keeps the rotation of the player at the last known z rotation
        if (playerRotation.z != 0)
        {
            //rotates the player to the absolute angle provided by the math above instead of a relative
            transform.eulerAngles = playerRotation;
            old_rotation = playerRotation;
        }
    }
    /// <summary>
    /// enables the input map
    /// </summary>
    private void OnEnable()
    {
        playerControls.Enable();
    }
    /// <summary>
    /// Disables the input map
    /// </summary>
    private void OnDisable()
    {
        playerControls.Disable();
    }
    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        
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
    // public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    //function called when trigger is activated 
    public void Revive()
    {
        
    }

    private void playGame()
    {
        SceneManager.LoadScene("SceneOne");
    }

    private void HowToMenu()
    {

        SceneManager.LoadScene("HowToScene", LoadSceneMode.Additive);

        /*
        Scene scene = SceneManager.GetActiveScene();


        Debug.Log("Active Scene is '" + scene.name + "'.");

        if (scene.name == "HowToScene")
        {
            Debug.Log("Goober");
            SceneManager.GetActiveScene();
        }

        else if (scene.name != "HowToScene")
        {
            Debug.Log("Boobz");
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("HowToScene"));
        }


        Debug.Log("Active Scene is '" + scene.name + "'.");
        */

    }


    /// <summary>
    /// When players start game and run into these circles they will be 
    /// assigned the correct script for their role and the trigger will dissapear
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //enables the correct script for the attacker
        if (collision.tag == "AssignAttacker")
        {
            Debug.Log("You are the attacker");
            Debug.Log(gameObject);
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
        //checks if the player is within revive range
        if (collision.tag == "Player")
        {
            Debug.Log("Ready to Revive");

        }

    }
}
