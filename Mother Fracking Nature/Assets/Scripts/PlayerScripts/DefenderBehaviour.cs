/*****************************************************************************
// File Name :         DefenderBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     March 28th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the defender role,
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DefenderBehaviour : PlayerBehaviour
{
    public Sprite Lady;

    InputActionAsset inputAsset3;
    InputActionMap defenderActions;
    InputAction block;
    InputAction place;
    InputAction scroll;
    //InputAction interact;    

    public float defenderHealth;

    //Array of game objects for the traps
    public GameObject[] trapArray = new GameObject[3];
    //Trap number to help navigate through the different traps
    private int trapNumber = 0;

    //Timers
    private float bearTrapTimer = 3f;
    private float canPlaceBearTrap;

    private float pipeBombTimer = 5f;
    private float canPlacePipeBomb;

    private float toasterTimer = 6f;
    private float canPlaceToaster;
    
    //Calls the health bar script
    //public HealthBarBehaviour healthBar;

    //temp holder for player to tell which trap they have
    //public Text currentTrapNumber;
    
    /// <summary>
    /// Enables controls
    /// </summary>
    private void Awake()
    {
        inputAsset3 = this.GetComponent<PlayerInput>().actions;
        defenderActions = inputAsset3.FindActionMap("DefenderActions");
    }

    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        defenderHealth = 250;

        inputAsset3 = this.GetComponent<PlayerInput>().actions;

        block = defenderActions.FindAction("Block");
        block.performed += ctx => Block();

        place = defenderActions.FindAction("Trap");
        place.performed += ctx => PlaceTrap(); 

        scroll = defenderActions.FindAction("LeftScroll");
        scroll.performed += ctx => LeftScroll();

        scroll = defenderActions.FindAction("RightScroll");
        scroll.performed += ctx => RightsScroll();

        /*
        interact = defenderActions.FindAction("Interact");
        interact.performed += ctx => RepairRig();
        */
        
        
        
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Lady;

    }    

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        /*
        if (playerHealth <= 0)
        {
            isDown = true;
            speed = 0;
            defenderActions.Disable();
            //this.gameObject.GetComponent<SpriteRenderer>().sprite =
        }
        else
        {
            isDown = false;
            defenderActions.Enable();
            //this.gameObject.GetComponent<SpriteRenderer>().sprite =
        }
        */
        
    }

    /// <summary>
    /// Health stuff
    /// </summary>
    private void FixedUpdate()
    {
        /*
        //player health regen
        for (; playerHealth < 250; playerHealth++)
        {

        }
        */

        //Updates the healthbar with current health
        //healthBar.SetHealth((int)playerHealth);

    }

    /// <summary>
    /// enables the input map
    /// </summary>
    private void OnEnable()
    {
        defenderActions.Enable();
    }
    /// <summary>
    /// Disables the input map
    /// </summary>
    private void OnDisable()
    {
        defenderActions.Disable();
    }

    /// <summary>
    /// Blocks enemies, obviously
    /// </summary>
    private void Block()
    {
        Debug.Log("Blocking");
    }

    /// <summary>
    /// Increases the trap number
    /// Will only get to '1' and '2' please help I'm too dumb to figure it out
    /// </summary>
    private void RightsScroll()
    {
        if (trapNumber == 2)
        {
            trapNumber = 0;
        }

        else
        {
            trapNumber++;
            Debug.Log(trapNumber);
        }
    }

    /// <summary>
    /// Decreases the trap number
    /// Currently the only way to get to '0' trap :')
    /// </summary>
    private void LeftScroll()
    {
        if (trapNumber == 0)
        {
            trapNumber = 2;
        }

        else
        {
            trapNumber--;
            Debug.Log(trapNumber);
        }
    }

    /// <summary>
    /// Creats a new trap based on the current trap number and position of player
    /// </summary>
    private void PlaceTrap()
    {
        if (trapNumber == 0 && Time.time > canPlaceBearTrap)
        {
            GameObject newTrap = Instantiate(trapArray[0], transform.position, Quaternion.identity);
            canPlaceBearTrap = Time.time + bearTrapTimer;
            //currentTrapNumber.text = "Bear Trap";
        }

        else if (trapNumber == 1 && Time.time > canPlacePipeBomb)
        {
            GameObject newTrap = Instantiate(trapArray[1], transform.position, Quaternion.identity);
            canPlacePipeBomb = Time.time + pipeBombTimer;
            //currentTrapNumber.text = "Pipe Bomb";
        }

        else if (trapNumber == 2 && Time.time > canPlaceToaster)
        {
            GameObject newTrap = Instantiate(trapArray[2], transform.position, Quaternion.identity);
            canPlaceToaster = Time.time + toasterTimer;
            //currentTrapNumber.text = "Toaster Bomb";
        }       
    }

    /// <summary>
    /// Deals damage to the defender
    /// </summary>
    /// <param name="defenderDamageTaken"></param>
    public void DefenderTakeDamage(float defenderDamageTaken)
    {
        defenderHealth = -defenderDamageTaken;
    }

    /*
    /// <summary>
    /// Gives the oil rig health
    /// </summary>
    private void RepairRig()
    {
        TryGetComponent<OilRigBehaviour>(out OilRigBehaviour oilRigComponent);

        oilRigComponent.getHealth(10);
    }
    */
}
