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

public class AttackerBehaviour : PlayerBehaviour
{
    //initializes weapondata scriptable object into our attacker
    [SerializeField] private WeaponData weaponData;

    public Sprite Guy;

    InputActionAsset inputAsset2;
    InputActionMap attackerActions;
    InputAction attack;
    InputAction ability;

    private void Awake()
    {
        inputAsset2 = this.GetComponent<PlayerInput>().actions;
        attackerActions = inputAsset2.FindActionMap("AttackerActions");
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        inputAsset2 = this.GetComponent<PlayerInput>().actions;

        attack = attackerActions.FindAction("Attack");
        attack.performed += ctx => weaponData.Attack(); //pulling function from weaponData scriptable object

        ability = attackerActions.FindAction("Ability");
        ability.performed += ctx => weaponData.Ability(); //pulling function from weaponData scriptable object
       

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Guy;
    }

    // Update is called once per frame
    void Update()
    {
        
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

  
}
