/*****************************************************************************
// File Name :         AttackerBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     March 28th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the attacker role, 
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AttackerBehaviour : PlayerBehaviour
{
    //initializes weapondata scriptable object into our attacker
    // [SerializeField] private WeaponData weaponData;

    Weapon weapon;

    

    public GameObject BottleMelee;
    public GameObject SawMelee;
    public GameObject BanjoMelee;
    public GameObject BanjoAbility;
    public GameObject SawAbility;
    public GameObject LandingSpot;
    public GameObject BottleTarget;

    public GameObject BottleProjectile;

    private BottleAbilityBehaviour bB;
    private Rigidbody2D rb2D;

    public Sprite Guy;
    public Sprite Bottle;
    public Sprite Saw;
    public Sprite Banjo;

    InputActionAsset inputAsset2;
    InputActionMap attackerActions;
    InputAction attack;
    InputAction ability;
    InputAction scroll;

  // public float attackerHealth;

    public float velocityX;
    public float velocityY;

    //Array of game objects for the traps
    public GameObject[] weaponArray = new GameObject[3];
    //Trap number to help navigate through the different traps
    private int weaponNumber = 0;
    private int abilityFrames = 0;
    private int attackFrames = 0;
    private bool attacking = false;
    private bool abiliting = false;

    public AudioClip bottleAttack;
    public AudioClip sawAttack;
    public AudioClip banjoAttack;
    public AudioClip bottleAbility;
    public AudioClip sawAbility;
    public AudioClip banjoAbility;

    /// <summary>
    /// Enables controls
    /// </summary>
    private void Awake()
    {
        inputAsset2 = this.GetComponent<PlayerInput>().actions;
        attackerActions = inputAsset2.FindActionMap("AttackerActions");
        

    }

    /// <summary>
    /// Start is called before the first frame update
    /// Stores all the controls and sets default weapon
    /// </summary>
    void Start()
    {
        weapon = new Bottle();

        gameObject.tag = "Attacker";

       // Speed =+ 10f;

       // attackerHealth = 100;


        inputAsset2 = this.GetComponent<PlayerInput>().actions;

        attack = attackerActions.FindAction("Attack");
        attack.performed += ctx => Attack();
        //attack.canceled += ctx => DisableTriggers();

        ability = attackerActions.FindAction("Ability");
        ability.performed += ctx => Ability();
       // ability.canceled += ctx => DisableTriggers();


        scroll = attackerActions.FindAction("LeftScroll");
        scroll.performed += ctx => LeftScroll();

        scroll = attackerActions.FindAction("RightScroll");
        scroll.performed += ctx => RightsScroll();

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Guy;
    }

    /// <summary>
    /// sets whether or not the attacker is downed and can attack or move
    /// </summary>
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();

        if (gc.attackerHealth <= 0)
        {
            attackerIsDown = true;
            //speed = 0;
            gameObject.isStatic = true;
            attackerActions.Disable();
            
            //this.gameObject.GetComponent<SpriteRenderer>().sprite =
        }
        else
        {
            attackerIsDown = false;
            //speed = 10;
            gameObject.isStatic = false;
            attackerActions.Enable();
            //this.gameObject.GetComponent<SpriteRenderer>().sprite =
        }
        
       

    }

    /// <summary>
    /// Checking for the player health to be under a certain amount and adds to it
    /// </summary>
    private void FixedUpdate()
    {
        //player health regen
        /*
        for (; playerHealth < 100; playerHealth += 2)
        {

        }
        */

        if (attackFrames >= 4)
        {
            DisableTriggers();
            attacking = false;
            attackFrames = 0;
        }
        if (attacking) attackFrames++;

        if (abilityFrames >= 4)
        {
            DisableAbilityTriggers();
            abiliting = false;
            abilityFrames = 0;
            if (weapon.WeaponName == "Hand Saw")
            {
                Vector3 player = GameObject.Find("LandingSpot").GetComponent<Transform>().position;
                transform.position = player;
                DisableTargets();
            }
        }

        if(abilityFrames >= 10)
        {
            DisableTargets();
        }
        
        if (abiliting) abilityFrames++;

    }

    /// <summary>
    /// Turns off the attack range objects
    /// </summary>
    public void DisableTriggers()
    {
        BottleMelee.SetActive(false);
        SawMelee.SetActive(false);
        BanjoMelee.SetActive(false);
       
    }

    /// <summary>
    /// Turns off attack range objects
    /// </summary>
    public void DisableAbilityTriggers()
    {
        BanjoAbility.SetActive(false);
        SawAbility.SetActive(false);
        

    }
    /// <summary>
    /// Turns off the dash and bottle targets
    /// </summary>
    public void DisableTargets()
    {
        BottleTarget.SetActive(false);
        LandingSpot.SetActive(false);
    }


    /// <summary>
    /// Checks what weapon you're holding and sets the correct trigger box
    /// </summary>
    public void Attack()
    {
        if (weapon.AttackReady > Time.time)
        {
            Debug.Log("attack on cooldown" + weapon.AttackReady);
            return;
        }

        weapon.AttackReady = weapon.AttackSpeed + Time.time;

        Debug.Log("attacking" + weapon.AttackReady);
        attacking = true;

        Debug.Log(weapon.WeaponName + " deals " + weapon.Damage + " " + weapon.DamageType + " damage!");

        if (weapon.AttackReady >= Time.time)
        {


            if (weapon.WeaponName == "Broken Bottle")
            {
                BottleMelee.SetActive(true);
                AudioSource.PlayClipAtPoint(bottleAttack, Camera.main.transform.position);
            }
            else if (weapon.WeaponName == "Hand Saw")
            {
                SawMelee.SetActive(true);
                AudioSource.PlayClipAtPoint(sawAttack, Camera.main.transform.position);
            }
            else
            {
                BanjoMelee.SetActive(true);
                AudioSource.PlayClipAtPoint(banjoAttack, Camera.main.transform.position);
            }
        }
    }


    /// <summary>
    /// Checks which weapon you're holding and applies the correct ability
    /// </summary>
    public void Ability()
    {

        if (weapon.AbilityReady > Time.time)
        {
            Debug.Log("ability on cooldown" + weapon.AbilityReady);
            return;
        }

        weapon.AbilityReady = weapon.CoolDown + Time.time;
        abiliting = true;

        Debug.Log(weapon.SpecialAbility + " activated!" + weapon.AbilityReady);

        if (weapon.AbilityReady >= Time.time)
        {
            if (weapon.WeaponName == "Broken Bottle")
            {
                GameObject newProjectile = Instantiate(weaponArray[0], transform.position, transform.rotation);

                BottleTarget.SetActive(true);
                AudioSource.PlayClipAtPoint(bottleAbility, Camera.main.transform.position);

            }
            else if (weapon.WeaponName == "Hand Saw")
            {
                SawAbility.SetActive(true);
                LandingSpot.SetActive(true);
                AudioSource.PlayClipAtPoint(sawAbility, Camera.main.transform.position);
            }
            else
            {
                BanjoAbility.SetActive(true);
                AudioSource.PlayClipAtPoint(banjoAbility, Camera.main.transform.position);
            }
        }
    }

    /// <summary>
    /// enables the input map
    /// </summary>
    private void OnEnable()
    {
        attackerActions.Enable();
    }

    /// <summary>
    /// Disables the input map
    /// </summary>
    private void OnDisable()
    {
        attackerActions.Disable();
    }
/*
    public void Attack()
    {
        Debug.Log(WeaponName + " deals " + Damage + " " + DamageType + " damage!");
    }

    public void Ability()
    {
        Debug.Log(SpecialAbility + " activated!");
    }

    */


/// <summary>
/// Selects a new weapon using the right bumper which will 
/// loop back around between three different weapons assigning the right scipt
/// </summary>
    public void RightsScroll()
    {
        if (weaponNumber >= 2)
        {
            weaponNumber = 0;
        }

        else
        {
            weaponNumber++;
            Debug.Log(weaponNumber);
        }


        switch (weaponNumber)
        {
            case 0:
                weapon = new Bottle();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Bottle;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Saw;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Banjo;
                break;

            case 1:
                weapon = new Saw();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Saw;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Banjo;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Bottle;
                break;

            case 2:
                weapon = new Banjo();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Banjo;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Bottle;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Saw;
                break;

            default:
                weapon = new Bottle();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Bottle;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Saw;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Banjo;
                break;
        }
    }

    /// <summary>
    /// Selects a new weapon using the left bumper which will 
    /// loop back around between three different weapons assigning the right scipt
    /// </summary>
    public void LeftScroll()
    {
        if (weaponNumber <= 0)
        {
            weaponNumber = 2;
        }

        else
        {
            weaponNumber--;
            Debug.Log(weaponNumber);
        }


        switch (weaponNumber)
        {
            case 0:
                weapon = new Bottle();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Bottle;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Saw;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Banjo;
                break;

            case 1:
                weapon = new Saw();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Saw;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Banjo;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Bottle;
                break;

            case 2:
                weapon = new Banjo();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Banjo;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Bottle;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Saw;
                break;

            default :
                weapon = new Bottle();
                GameObject.Find("CurrentWeapon").GetComponent<Image>().sprite = Bottle;
                GameObject.Find("RightWeapon").GetComponent<Image>().sprite = Saw;
                GameObject.Find("LeftWeapon").GetComponent<Image>().sprite = Banjo;
                break;
        }
    }

    /// <summary>
    /// Allows other scripts to call this function and deal damage to the attacker
    /// </summary>
    /// <param name="attackerDamageTaken"></param>
   /* public void AttackerTakeDamage(float attackerDamageTaken)
    {
        attackerHealth = -attackerDamageTaken;
    }
   */
}
