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
    public Sprite BearTrap;
    public Sprite ToasterBomb;
    public Sprite PipeBomb;

    public GameObject Shield;
    public GameObject tower;

    public AudioClip bearTrapPlace;
    public AudioClip toasterPlace;
    public AudioClip pipeBombPlace;

    public AudioClip repairSound;

    public float towerDistance;

    public bool repairable = false;
    public bool repairing = false;
    public int repairFrames = 0;

    InputActionAsset inputAsset3;
    InputActionMap defenderActions;
    InputAction block;
    InputAction place;
    InputAction scroll;
    InputAction repair;
    //InputAction interact;    

    //public float defenderHealth;

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
        //defenderHealth = 250;

        gameObject.tag = "Defender";

        inputAsset3 = this.GetComponent<PlayerInput>().actions;

        block = defenderActions.FindAction("Block");
        block.performed += ctx => Block();
        block.canceled += ctx => DisableBlock();

        place = defenderActions.FindAction("Trap");
        place.performed += ctx => PlaceTrap(); 

        scroll = defenderActions.FindAction("LeftScroll");
        scroll.performed += ctx => LeftScroll();

        scroll = defenderActions.FindAction("RightScroll");
        scroll.performed += ctx => RightsScroll();

        repair = defenderActions.FindAction("Repair");
        repair.performed += ctx => Repair();
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
        GameController gc = FindObjectOfType<GameController>();

        if (gc.defenderHealth <= 0)
        {
            defenderIsDown = true;
            Speed = 0;
            defenderActions.Disable();
            //this.gameObject.GetComponent<SpriteRenderer>().sprite =
        }
        else
        {
            defenderIsDown = false;
            Speed = 7;
            defenderActions.Enable();
            //this.gameObject.GetComponent<SpriteRenderer>().sprite =
        }
        
        
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
        if (repairFrames >= 100)
        {
            
            repairing = false;
            repairFrames = 0;
        }
        if (repairing) repairFrames++;
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
        Shield.SetActive(true);
        Debug.Log("Blocking");
    }

    private void DisableBlock()
    {
        Shield.SetActive(false);
    }

    /// <summary>
    /// Increases the trap number
    /// Will only get to '1' and '2' please help I'm too dumb to figure it out
    /// </summary>
    private void RightsScroll()
    {
        if (trapNumber >= 2)
        {
            trapNumber = 0;
        }

        else
        {
            trapNumber++;
            Debug.Log(trapNumber);
        }

        switch (trapNumber)
        {
            case 0:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = BearTrap;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = PipeBomb;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = ToasterBomb;
                break;

            case 1:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = PipeBomb;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = ToasterBomb;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = BearTrap;
                break;

            case 2:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = ToasterBomb;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = BearTrap;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = PipeBomb;
                break;

            default:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = BearTrap;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = PipeBomb;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = ToasterBomb;
                break;
        }
    }

    /// <summary>
    /// Decreases the trap number
    /// Currently the only way to get to '0' trap :')
    /// </summary>
    private void LeftScroll()
    {
        if (trapNumber <= 0)
        {
            trapNumber = 2;
        }

        else
        {
            trapNumber--;
            Debug.Log(trapNumber);
        }

        switch (trapNumber)
        {
            case 0:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = BearTrap;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = PipeBomb;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = ToasterBomb;
                break;

            case 1:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = PipeBomb;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = ToasterBomb;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = BearTrap;
                break;

            case 2:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = ToasterBomb;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = BearTrap;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = PipeBomb;
                break;

            default:

                GameObject.Find("CurrentTrap").GetComponent<Image>().sprite = BearTrap;
                GameObject.Find("RightTrap").GetComponent<Image>().sprite = PipeBomb;
                GameObject.Find("LeftTrap").GetComponent<Image>().sprite = ToasterBomb;
                break;
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
            AudioSource.PlayClipAtPoint(bearTrapPlace, Camera.main.transform.position);
            canPlaceBearTrap = Time.time + bearTrapTimer;
            //currentTrapNumber.text = "Bear Trap";
        }

        else if (trapNumber == 1 && Time.time > canPlacePipeBomb)
        {
            GameObject newTrap = Instantiate(trapArray[1], transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(pipeBombPlace, Camera.main.transform.position);
            canPlacePipeBomb = Time.time + pipeBombTimer;
            //currentTrapNumber.text = "Pipe Bomb";
        }

        else if (trapNumber == 2 && Time.time > canPlaceToaster)
        {
            GameObject newTrap = Instantiate(trapArray[2], transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(toasterPlace, Camera.main.transform.position);
            canPlaceToaster = Time.time + toasterTimer;
            //currentTrapNumber.text = "Toaster Bomb";
        }       
    }

    /// <summary>
    /// Deals damage to the defender
    /// </summary>
    /// <param name="defenderDamageTaken"></param>
   /* public void DefenderTakeDamage(float defenderDamageTaken)
    {
        defenderHealth = -defenderDamageTaken;
    }
   */
    
    /// <summary>
    /// Gives the oil rig health
    /// </summary>
    private void Repair()
    {
        GameController gc = FindObjectOfType<GameController>();
        towerDistance = Vector2.Distance(transform.position, tower.transform.position);
       
        
            if (towerDistance < 6 && gc.towerHealth < 500 && repairing == false)
            {
            repairing = true;
                gc.towerHealth += 20;
            AudioSource.PlayClipAtPoint(repairSound, Camera.main.transform.position);
            Debug.Log("Repairing");
            
            }
        
    }

    

   

}
